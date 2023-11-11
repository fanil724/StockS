using Stock.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Stock
{

    public partial class ADD : Window
    {
        private StockDBClient stock = new StockDBClient();
        private ProductS productS = new ProductS();
        private Supplier suppliers = new Supplier();
        private Typess typesses = new Typess();
        public ADD()
        {
            InitializeComponent();
            ADDList.ItemsSource = new List<string>() { "Вставка новых товаров", "Вставка новых поставщиков", "Вставка новых типов товаров" };
            ADDList.SelectedIndex = 0;
            ProductSupplier.ItemsSource = stock.SelectedALLSuppl().Select(sup => sup.City);
            ProductType.ItemsSource = stock.SelectedALLTypes().Select(t => t.ProductType);

        }

        private void ADDList_Selected(object sender, RoutedEventArgs e)
        {
            
            ProductName.Visibility = Visibility.Hidden;
            prod.Visibility = Visibility.Hidden;
            supl.Visibility = Visibility.Hidden;
            ProductSupplier.Visibility = Visibility.Hidden;
            typs.Visibility = Visibility.Hidden;
            ProductType.Visibility = Visibility.Hidden;
            cnt.Visibility = Visibility.Hidden;
            QuantityOfGoods.Visibility = Visibility.Hidden;
            seb.Visibility = Visibility.Hidden;
            Cost.Visibility = Visibility.Hidden;
            dat.Visibility = Visibility.Hidden;
            DeliveryDate.Visibility = Visibility.Hidden;
            nameSup.Visibility = Visibility.Hidden;
            SuppliersName.Visibility = Visibility.Hidden;
            PhoneSupplier.Visibility = Visibility.Hidden;
            PhoneSup.Visibility = Visibility.Hidden;
            ProductTypess.Visibility = Visibility.Hidden;
            nameTyp.Visibility = Visibility.Hidden;
            switch (ADDList.SelectedIndex)
            {

                case 0:
                    {
                        ProductName.Visibility = Visibility.Visible;
                        prod.Visibility = Visibility.Visible;
                        supl.Visibility = Visibility.Visible;
                        ProductSupplier.Visibility = Visibility.Visible;
                        typs.Visibility = Visibility.Visible;
                        ProductType.Visibility = Visibility.Visible;
                        cnt.Visibility = Visibility.Visible;
                        QuantityOfGoods.Visibility = Visibility.Visible;
                        seb.Visibility = Visibility.Visible;
                        Cost.Visibility = Visibility.Visible;
                        dat.Visibility = Visibility.Visible;
                        DeliveryDate.Visibility = Visibility.Visible;
                        DataContext = productS;
                    }
                    break;
                case 1:
                    {
                        nameSup.Visibility = Visibility.Visible;
                        SuppliersName.Visibility = Visibility.Visible;
                        PhoneSupplier.Visibility = Visibility.Visible;
                        PhoneSup.Visibility = Visibility.Visible;
                        DataContext = suppliers;
                    }
                    break;
                case 2:
                    {
                        ProductTypess.Visibility = Visibility.Visible;
                        nameTyp.Visibility = Visibility.Visible;
                        DataContext = typesses;
                    }
                    break;
            }
            ProductSupplier.ItemsSource = stock.SelectedALLSuppl().Select(sup => sup.City);
            ProductType.ItemsSource = stock.SelectedALLTypes().Select(t => t.ProductType);

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            switch (ADDList.SelectedIndex)
            {
                case 0:
                    {
                        if (stock.InsertProduct(productS,
                           stock.SelectedIDSupplier(ProductSupplier.SelectedItem.ToString()),
                           stock.SelectedIDTypess(ProductType.SelectedItem.ToString())))
                        {
                            MessageBox.Show("Запсиь добавлена", "info", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Запсиь  не добавлена", "info", MessageBoxButton.OK);
                        }
                    }
                    break;
                case 1:
                    {
                        if (stock.InsertSupplier(suppliers))
                        {
                            MessageBox.Show("Запсиь добавлена", "info", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Запсиь  не добавлена", "info", MessageBoxButton.OK);
                        }
                    }
                    break;
                case 2:
                    {
                        if (stock.InsertTypes(typesses))
                        {
                            MessageBox.Show("Запсиь добавлена", "info", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Запсиь  не добавлена", "info", MessageBoxButton.OK);
                        }

                    }
                    break;
            }
            Close();
        }

        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(IsGood);
        }

        private void OnPasting(object sender, DataObjectPastingEventArgs e)
        {
            var stringData = (string)e.DataObject.GetData(typeof(string));
            if (stringData == null || !stringData.All(IsGood))
                e.CancelCommand();
        }

        bool IsGood(char c)
        {
            if (c >= '0' && c <= '9')
                return true;

            if (c == '.') return true;

            return false;
        }
    }
}
