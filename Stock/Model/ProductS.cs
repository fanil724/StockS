using System;

namespace Stock.Model
{
    internal class ProductS
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string Types { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public DateTime DiliveryDate { get; set; }

    }


    public class Supplier
    {
        public int ID { get; set; }
        public string City { get; set; }
        public Int64 Phone { get; set; }
    }

    public class Typess {
        public int ID { get; set; } 
        public string ProductType { get; set; }            
    }
}
