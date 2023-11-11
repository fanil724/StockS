using Stock.Model;
using System.Collections.Generic;
using System.Windows;

namespace Stock
{
    public partial class Opens : Window
    {
        private StockDBClient stock = new StockDBClient();
        private List<ProductS> productS = null;
        private List<Supplier> suppliers = null;
        private List<Typess> typesses = null;
        public Opens()
        {
            InitializeComponent();
            OpenList.ItemsSource = new List<string>() { "Открыть товар", "Открыть поставщика", "Открыть тип товара" };
            OpenList.SelectedIndex = 0;
        }

        private void OpenList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (OpenList.SelectedIndex)
            {
                case 0:
                    {
                        productS = stock.SelectedALL();
                        OpenTable.ItemsSource = productS;
                    }
                    break;
                case 1:
                    {
                        suppliers = stock.SelectedALLSuppl();
                        OpenTable.ItemsSource = suppliers;
                    }
                    break;
                case 2:
                    {
                        typesses = stock.SelectedALLTypes();
                        OpenTable.ItemsSource = typesses;
                    }
                    break;
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (OpenTable.SelectedIndex == -1)
            {
                MessageBox.Show("Выбирите из списка для открытия", "info", MessageBoxButton.OK);
                return;
            }


            switch (OpenList.SelectedIndex)
            {
                case 0:
                    {
                        Update update = new Update(productS[OpenTable.SelectedIndex].Id, OpenList.SelectedIndex);
                        Close();
                        update.Show();
                    }
                    break;
                case 1:
                    {
                        Update update = new Update(suppliers[OpenTable.SelectedIndex].ID, OpenList.SelectedIndex);
                        Close();
                        update.Show();
                    }
                    break;
                case 2:
                    {
                        Update update = new Update(typesses[OpenTable.SelectedIndex].ID, OpenList.SelectedIndex);
                        Close();
                        update.Show();
                    }
                    break;
            }
        }
    }
}
