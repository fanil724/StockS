using Stock.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Stock
{
    internal class StockDBClient
    {
        private DBManager dbManager = new DBManager();


        public bool DeleteProductID(int ID)
        {
            SqlConnection conn = null;
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"DELETE FROM Product WHERE @ID=id";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                int rowsAffevt = cmd.ExecuteNonQuery();
                return rowsAffevt == 1;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn?.Close();
            }
        }
        public bool DeleteTypesID(int ID)
        {
            SqlConnection conn = null;
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"DELETE FROM Typess WHERE @ID=id";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                int rowsAffevt = cmd.ExecuteNonQuery();
                return rowsAffevt == 1;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn?.Close();
            }
        }
        public bool DeleteSupplierID(int ID)
        {
            SqlConnection conn = null;
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"DELETE FROM Supplier WHERE @ID=id";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@ID", ID);
                int rowsAffevt = cmd.ExecuteNonQuery();
                return rowsAffevt == 1;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn?.Close();
            }
        }


        public bool InsertProduct(ProductS product, int SID, int TID)
        {
            SqlConnection conn = null;
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"INSERT INTO Product VALUES(@PN, @SID, @TID, @Q, @C, @D)";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@PN", product.ProductName);
                cmd.Parameters.AddWithValue("@SID", SID);
                cmd.Parameters.AddWithValue("@TID", TID);
                cmd.Parameters.AddWithValue("@Q", product.Quantity);
                cmd.Parameters.AddWithValue("@C", product.Cost);
                cmd.Parameters.AddWithValue("@D", product.DiliveryDate);
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect == 1;
            }
            finally
            {
                conn?.Close();
            }

        }
        public bool InsertTypes(Typess typess)
        {
            SqlConnection conn = null;
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"INSERT INTO Typess VALUES(@PN)";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@PN", typess.ProductType);
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect == 1;

            }
            finally { conn?.Close(); }
        }
        public bool InsertSupplier(Supplier supplier)
        {
            SqlConnection conn = null;
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"INSERT INTO Supplier VALUES(@C,@PH)";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@C", supplier.City);
                cmd.Parameters.AddWithValue("@PH", supplier.Phone);

                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect == 1;

            }
            finally
            {
                conn?.Close();
            }
        }

        public bool UpdateProduct(ProductS product, int SID, int TID)
        {
            SqlConnection conn = null;
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"UPDATE Product
                                      SET ProdName=@PN,SupplierID=@SID, TypeID=@TID,
                                      Quantity=@Q,Cost=@C,DiliveryDate=@D
                                      WHERE id=@ID";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@PN", product.ProductName);
                cmd.Parameters.AddWithValue("@SID", SID);
                cmd.Parameters.AddWithValue("@TID", TID);
                cmd.Parameters.AddWithValue("@Q", product.Quantity);
                cmd.Parameters.AddWithValue("@C", product.Cost);
                cmd.Parameters.AddWithValue("@D", product.DiliveryDate);
                cmd.Parameters.AddWithValue("@ID", product.Id);
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect == 1;
            }
            catch { 
                return false;
            }
            finally
            {
                conn?.Close();
            }

        }
        public bool UpdateTypes(Typess typess)
        {
            SqlConnection conn = null;
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = "UPDATE Typess SET ProductType=@PN  WHERE id=@ID";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@PN", typess.ProductType);
                cmd.Parameters.AddWithValue("@ID", typess.ID);
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect == 1;
            }
            finally { conn?.Close(); }
        }
        public bool UpdateSupplier(Supplier supplier)
        {
            SqlConnection conn = null;
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = "UPDATE Supplier SET City=@C, Phone=@P  WHERE id=@ID";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@C", supplier.City);
                cmd.Parameters.AddWithValue("@P", supplier.Phone);
                cmd.Parameters.AddWithValue("ID", supplier.ID);
                int rowsAffect = cmd.ExecuteNonQuery();
                return rowsAffect == 1;
            }
            finally
            {
                conn?.Close();
            }
        }


        public int SelectedIDTypess(string name)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"SELECT id FROM Typess WHERE ProductType like @N";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@N", name);
                reader = cmd.ExecuteReader();
                reader.Read();
                return reader.GetInt32(0);
            }
            finally
            {
                reader?.Close();
                conn?.Close();
            }

        }

        public int SelectedIDSupplier(string name)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"SELECT id FROM Supplier WHERE City like @N";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@N", name);
                reader = cmd.ExecuteReader();
                reader.Read();
                return reader.GetInt32(0);
            }
            finally
            {
                reader?.Close();
                conn?.Close();
            }

        }

        public List<ProductS> SelectedALLDAY()
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            List<ProductS> prod = new List<ProductS>();
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"SELECT pc.id, pc.ProdName, s.City, t.ProductType, pc.Quantity, pc.Cost, pc.DiliveryDate
                FROM Product pc join Typess t on t.id=pc.TypeID join Supplier s on s.id=pc.SupplierID 
                WHERE pc.DiliveryDate>(GETDATE()-7)";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prod.Add(new ProductS()
                    {
                        Id = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        SupplierName = reader.GetString(2),
                        Types = reader.GetString(3),
                        Quantity = reader.GetInt32(4),
                        Cost = Convert.ToDouble(reader.GetValue(5)),
                        DiliveryDate = reader.GetDateTime(6)
                    });
                }
                return prod;
            }
            finally
            {
                conn?.Close();
                reader?.Close();
            }
        }
        public List<ProductS> SelectedALL()
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            List<ProductS> prod = new List<ProductS>();
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"SELECT pc.id, pc.ProdName, s.City, t.ProductType, pc.Quantity, pc.Cost, pc.DiliveryDate
                FROM Product pc join Typess t on t.id=pc.TypeID join Supplier s on s.id=pc.SupplierID";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prod.Add(new ProductS()
                    {
                        Id = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        SupplierName = reader.GetString(2),
                        Types = reader.GetString(3),
                        Quantity = reader.GetInt32(4),
                        Cost = Convert.ToDouble(reader.GetValue(5)),
                        DiliveryDate = reader.GetDateTime(6)
                    });
                }
                return prod;
            }
            finally
            {
                conn?.Close();
                reader?.Close();
            }
        }
        public List<Typess> SelectedALLTypes()
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            List<Typess> prod = new List<Typess>();
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"SELECT * FROM Typess ";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prod.Add(new Typess()
                    {
                        ID = reader.GetInt32(0),
                        ProductType = reader.GetString(1),
                    });
                }
                return prod;
            }
            finally
            {
                conn?.Close();
                reader?.Close();
            }
        }
        public List<Supplier> SelectedALLSuppl()
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            List<Supplier> prod = new List<Supplier>();
            try
            {
                conn = dbManager.OpenDbConnection();
                string queryString = @"SELECT * FROM Supplier ";
                SqlCommand cmd = new SqlCommand(queryString, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prod.Add(new Supplier()
                    {
                        ID = reader.GetInt32(0),
                        City = reader.GetString(1),
                        Phone = reader.GetInt64(2)
                    });
                }
                return prod;
            }
            finally
            {
                conn?.Close();
                reader?.Close();
            }
        }
        public List<Supplier> SelectedPRODUCT(string queryString)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            List<Supplier> prod = new List<Supplier>();
            try
            {
                conn = dbManager.OpenDbConnection();
                SqlCommand cmd = new SqlCommand(queryString, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prod.Add(new Supplier()
                    {
                        ID = reader.GetInt32(0),
                        City = reader.GetString(1),
                        Phone = reader.GetInt64(2)
                    });
                }
                return prod;
            }
            finally
            {
                conn?.Close();
                reader?.Close();
            }
        }
        public List<Typess> SelectedType(string queryString)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            List<Typess> prod = new List<Typess>();
            try
            {
                conn = dbManager.OpenDbConnection();
                SqlCommand cmd = new SqlCommand(queryString, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    prod.Add(new Typess()
                    {
                        ID = reader.GetInt32(0),
                        ProductType = reader.GetString(1)
                    });
                }
                return prod;
            }
            finally
            {
                conn?.Close();
                reader?.Close();
            }
        }
    }
}