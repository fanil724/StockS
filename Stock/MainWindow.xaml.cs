using Stock.Model;
using System.Collections.Generic;
using System.Windows;

namespace Stock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private StockDBClient stock = new StockDBClient();
        private List<ProductS> productS = null;
        private List<Supplier> suppliers = null;
        private List<Typess> typesses = null;
        public MainWindow()
        {
            InitializeComponent();
            Query.ItemsSource = new List<string>() {"Показать все товары",
                                                    "Показать информацию о поставщике с наибольшим количеством товаров на складе",
                                                    "Показать информацию о поставщике с наименьшим количеством товаров на складе",
                                                    "Показать информацию о типе товаров с наибольшим количеством товаров на складе",
                                                    "Показать информацию о типе товаров с наименьшим количеством товаров на складе",
                                                    "Показать товары с поставки, которых прошло заданное количество дней" };
            Query.SelectedIndex = 0;
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            ADD ad = new ADD();
            ad.Show();
        }

        private void QueryDone_Click(object sender, RoutedEventArgs e)
        {

            switch (Query.SelectedIndex)
            {
                case 0:
                    {
                        productS = stock.SelectedALL();
                        QueryTable.ItemsSource = productS;
                    }
                    break;
                case 1:
                    {
                        string queryString = @"SELECT DISTINCT s.id, s.City,s.Phone
                                        FROM Product pc join Typess t on t.id=pc.TypeID join Supplier s on s.id=pc.SupplierID
                                        WHERE s.City like (
                                        SELECT s.City FROM Supplier s
                                        join Product p on p.SupplierID=s.id
                                        GROUP BY s.City
                                        HAVING SUM(p.Quantity) =(SELECT MAX(t.QUN) FROM
                                        (SELECT SUM(p.Quantity) as QUN FROM Supplier s
                                        join Product p on p.SupplierID=s.id
                                        GROUP BY City) t)
                                        )";
                        suppliers = stock.SelectedPRODUCT(queryString);
                        QueryTable.ItemsSource = suppliers;
                    }
                    break;
                case 2:
                    {
                        string queryString = @"SELECT s.id, s.City,s.Phone
                                        FROM Product pc join Typess t on t.id=pc.TypeID join Supplier s on s.id=pc.SupplierID
                                        WHERE s.City like (
                                        SELECT s.City FROM Supplier s
                                        join Product p on p.SupplierID=s.id
                                        GROUP BY s.City
                                        HAVING SUM(p.Quantity) =(SELECT MIN(t.QUN) FROM
                                        (SELECT SUM(p.Quantity) as QUN FROM Supplier s
                                        join Product p on p.SupplierID=s.id
                                        GROUP BY City) t)
                                        )";
                        suppliers = stock.SelectedPRODUCT(queryString);
                        QueryTable.ItemsSource = suppliers;
                    }
                    break;
                case 3:
                    {
                        string queryString = @"SELECT t.id, t.ProductType
                                        FROM Product pc join Typess t on t.id=pc.TypeID join Supplier s on s.id=pc.SupplierID
                                        WHERE s.City like (
                                        SELECT s.City FROM Supplier s
                                        join Product p on p.SupplierID=s.id
                                        GROUP BY s.City
                                        HAVING SUM(p.Quantity) =(SELECT MAX(t.QUN) FROM
                                        (SELECT SUM(p.Quantity) as QUN FROM Supplier s
                                        join Product p on p.SupplierID=s.id
                                        GROUP BY City) t)
                                        )";
                        typesses = stock.SelectedType(queryString);
                        QueryTable.ItemsSource = typesses;
                    }
                    break;
                case 4:
                    {
                        string queryString = @"SELECT t.id, t.ProductType
                                        FROM Product pc join Typess t on t.id=pc.TypeID join Supplier s on s.id=pc.SupplierID
                                        WHERE s.City like (
                                        SELECT s.City FROM Supplier s
                                        join Product p on p.SupplierID=s.id
                                        GROUP BY s.City
                                        HAVING SUM(p.Quantity) =(SELECT MIN(t.QUN) FROM
                                        (SELECT SUM(p.Quantity) as QUN FROM Supplier s
                                        join Product p on p.SupplierID=s.id
                                        GROUP BY City) t)
                                        )";
                        typesses = stock.SelectedType(queryString);
                        QueryTable.ItemsSource = typesses;
                    }
                    break;
                case 5:
                    {
                        productS = stock.SelectedALLDAY();
                        QueryTable.ItemsSource = productS;
                    }
                    break;

            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Delete del = new Delete();
            del.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Opens open = new Opens();
            open.Show();
        }
    }
}
