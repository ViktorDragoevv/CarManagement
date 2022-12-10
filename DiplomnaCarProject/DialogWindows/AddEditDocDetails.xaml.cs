using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DiplomnaCarProject.DialogWindows
{
    /// <summary>
    /// Interaction logic for AddEditDocDetails.xaml
    /// </summary>
    public partial class AddEditDocDetails : Window
    {
        int mode = 0;
        int idEdit = 0;
        int consumable = 0;
        decimal bruto = 0;
        decimal neto = 0;
        decimal quantity = 0;
        int editnumber = 0;
        List<ClassDocumentDetails> list = new List<ClassDocumentDetails>();
        List<ClassDocumentDetails> editList = new List<ClassDocumentDetails>();
        bool flag = false;

        public AddEditDocDetails(int mode, int idEdit = 0, int consumable = 0, decimal bruto = 0, decimal neto = 0, decimal quantity = 0, int editnumber = 0)
        {
            InitializeComponent();
            this.mode = mode;
            this.idEdit = idEdit;
            this.consumable = consumable;
            this.bruto = bruto;
            this.neto = neto;
            this.quantity = quantity;
            this.editnumber = editnumber;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassDocumentDetails doc = new ClassDocumentDetails();
            doc.bruto = Convert.ToDecimal(textBoxPrice.Text.ToString());
            doc.neto = Convert.ToDecimal(textBoxPriceDDS.Text.ToString());
            doc.quantity = Convert.ToDecimal(textBoxQuantity.Text.ToString());
            doc.consumable = int.Parse(CBconsumable.SelectedValue.ToString());
            doc.userConsumable = CBconsumable.Text.ToString();
            doc.editnumber = editnumber;
            if (idEdit != 0)
            {
                doc.id = idEdit;
            }
            DialogResult = true;
            Singletone.classDoc = doc;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            


            if (mode == 1)
            {
                DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
                // Load data into the table consumablesCB. You can modify this code as needed.
                DiplomnaCarProject.DataSet1TableAdapters.consumablesCBTableAdapter dataSet1consumablesCBTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.consumablesCBTableAdapter();
                dataSet1consumablesCBTableAdapter.FillBy(dataSet1.consumablesCB);
                System.Windows.Data.CollectionViewSource consumablesCBViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("consumablesCBViewSource")));
                consumablesCBViewSource.View.MoveCurrentToFirst();
            }
            else if(mode == 0)
            {
                DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
                // Load data into the table consumablesCB. You can modify this code as needed.
                DiplomnaCarProject.DataSet1TableAdapters.consumablesCBTableAdapter dataSet1consumablesCBTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.consumablesCBTableAdapter();
                dataSet1consumablesCBTableAdapter.Fill(dataSet1.consumablesCB);
                System.Windows.Data.CollectionViewSource consumablesCBViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("consumablesCBViewSource")));
                consumablesCBViewSource.View.MoveCurrentToFirst();
            }
            this.Title = "Добавяне на консуматив";
        }

        private void textBoxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxPrice.IsFocused)
            {
                if (textBoxPrice.Text != "")
                {
                    decimal buff = Convert.ToDecimal(textBoxPrice.Text.ToString());
                    decimal multi = 1.20m;
                    decimal res = buff * multi;
                    textBoxPriceDDS.Text = Math.Round(res, 2).ToString();
                }
                else if (textBoxPrice.Text == "")
                {
                    textBoxPriceDDS.Text = "";
                }
            }
            else
            {

            }

        }

        private void textBoxPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
              e.Key == Key.Delete || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.OemComma)
            {
                //Pressed Alt, ctrl, shift and other modifier keys
                if (e.KeyboardDevice.Modifiers != ModifierKeys.None)
                {
                    e.Handled = true;
                }
                else
                {
                    //return true;
                }

            }
            else//Press other function keys such as characters
            {
                e.Handled = true;
            }
            //return false;


        }

        private void textBoxPriceDDS_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxPriceDDS.IsFocused)
            {
                if (textBoxPriceDDS.Text != "")
                {
                    decimal buff = Convert.ToDecimal(textBoxPriceDDS.Text.ToString());
                    decimal multi = 5 / 6m;
                    decimal res = buff * multi;


                    textBoxPrice.Text = Math.Round(res, 2).ToString();
                }
                else if (textBoxPriceDDS.Text == "")
                {
                    textBoxPrice.Text = "";
                }
            }
            else
            {

            }
        }

        private void textBoxPriceDDS_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
              e.Key == Key.Delete || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.OemComma)
            {
                //Pressed Alt, ctrl, shift and other modifier keys
                if (e.KeyboardDevice.Modifiers != ModifierKeys.None)
                {
                    e.Handled = true;
                }
                else
                {
                    //return true;
                }

            }
            else//Press other function keys such as characters
            {
                e.Handled = true;
            }
            //return false;
        }

        private void textBoxQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
              e.Key == Key.Delete || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.OemComma)
            {
                //Pressed Alt, ctrl, shift and other modifier keys
                if (e.KeyboardDevice.Modifiers != ModifierKeys.None)
                {
                    e.Handled = true;
                }
                else
                {
                    //return true;
                }

            }
            else//Press other function keys such as characters
            {
                e.Handled = true;
            }
        }
    }
}
