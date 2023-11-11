using Stock.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Stock
{
    public partial class Update : Window
    {
        private StockDBClient stock = new StockDBClient();
        private ProductS productS = null;
        private Supplier suppliers = null;
        private Typess typesses = null;
        int SelectID { get; set; }
        int Selec { get; set; }
        public Update(int id, int sel)
        {
            this.SelectID = id;
            this.Selec = sel;
            InitializeComponent();
            ProductSupplier.ItemsSource = stock.SelectedALLSuppl().Select(sup => sup.City);
            ProductType.ItemsSource = stock.SelectedALLTypes().Select(t => t.ProductType);
            switch (sel)
            {
                case 0:
                    {
                        productS = stock.SelectedALL().FirstOrDefault(x => x.Id == id);
                        ProductSupplier.SelectedValue = productS.SupplierName;
                        ProductType.SelectedValue = productS.Types;
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
                        suppliers = stock.SelectedALLSuppl().FirstOrDefault(x => x.ID == id);
                        nameSup.Visibility = Visibility.Visible;
                        SuppliersName.Visibility = Visibility.Visible;
                        PhoneSupplier.Visibility = Visibility.Visible;
                        PhoneSup.Visibility = Visibility.Visible;
                        DataContext = suppliers;
                    }
                    break;
                case 2:
                    {
                        typesses = stock.SelectedALLTypes().FirstOrDefault(x => x.ID == id);
                        ProductTypess.Visibility = Visibility.Visible;
                        nameTyp.Visibility = Visibility.Visible;
                        DataContext = typesses;
                    }
                    break;

            }
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            switch (Selec)
            {
                case 0:
                    {

                        if (stock.UpdateProduct(productS,
                           stock.SelectedIDSupplier(ProductSupplier.SelectedItem.ToString()),
                           stock.SelectedIDTypess(ProductType.SelectedItem.ToString())))
                        {
                            MessageBox.Show("Запсиь обновлена", "info", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Запсиь  не обновлена", "info", MessageBoxButton.OK);
                        }
                    }
                    break;
                case 1:
                    {
                        if (stock.UpdateSupplier(suppliers))
                        {
                            MessageBox.Show("Запсиь обновлена", "info", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Запсиь  не обновлена", "info", MessageBoxButton.OK);
                        }
                    }
                    break;
                case 2:
                    {
                        if (stock.UpdateTypes(typesses))
                        {
                            MessageBox.Show("Запсиь обновлена", "info", MessageBoxButton.OK);
                        }
                        else
                        {
                            MessageBox.Show("Запсиь  не обновлена", "info", MessageBoxButton.OK);
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


    }
}
