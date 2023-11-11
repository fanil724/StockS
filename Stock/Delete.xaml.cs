using Stock.Model;
using System.Collections.Generic;
using System.Windows;

namespace Stock
{   
    public partial class Delete : Window
    {
        private StockDBClient stock = new StockDBClient();
        private List<ProductS> productS = null;
        private List<Supplier> suppliers = null;
        private List<Typess> typesses = null;
        public Delete()
        {
            InitializeComponent();
            DeleteList.ItemsSource = new List<string>() { "Удаление товаров", "Удаление поставщиков", "Удаление типов товаров" };
            DeleteList.SelectedIndex = 0;
        }

        private void DeleteList_Selected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           // DeleteTable.DataContext = DeleteList;
            switch (DeleteList.SelectedIndex)
            {
                case 0:
                    {
                        productS = stock.SelectedALL();
                        DeleteTable.ItemsSource = productS;
                    }
                    break;
                case 1:
                    {
                        suppliers = stock.SelectedALLSuppl();
                        DeleteTable.ItemsSource = suppliers;
                    }
                    break;
                case 2:
                    {
                        typesses = stock.SelectedALLTypes();
                        DeleteTable.ItemsSource = typesses;
                    }
                    break;
            }
        }

        private void Delet_Click(object sender, RoutedEventArgs e)
        {
            bool deletingentry = false;
            switch (DeleteList.SelectedIndex)
            {
                case 0:
                    {
                        MessageBox.Show(productS[DeleteTable.SelectedIndex].Id.ToString(), "info", MessageBoxButton.OK);
                        //deletingentry = stock.DeleteProductID(productS[DeleteTable.SelectedIndex].Id);
                    }
                    break;
                case 1:
                    {
                       // deletingentry = stock.DeleteSupplierID(suppliers[DeleteTable.SelectedIndex].ID);
                    }
                    break;
                case 2:
                    {
                      //  deletingentry = stock.DeleteTypesID(typesses[DeleteTable.SelectedIndex].ID);
                    }
                    break;
            }
            if (deletingentry)
                MessageBox.Show("Запсиь удалена", "info",MessageBoxButton.OK);
            MessageBox.Show("Запсиь  не удалена", "info", MessageBoxButton.OK);

            Close();
        }
    }
}
