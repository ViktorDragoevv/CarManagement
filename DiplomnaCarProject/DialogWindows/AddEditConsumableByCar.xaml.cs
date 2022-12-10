using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AddEditConsumableByCar.xaml
    /// </summary>
    public partial class AddEditConsumableByCar : Window
    {
        SQL sql = new SQL();
        int mode = 0;
        int car = 0;
        int consumable = 0;
        decimal quantity = 0;
        int editId;
        decimal maxQuantity = 0;

        public AddEditConsumableByCar(int mode, int car = 0, int consumable = 0, decimal quantity = 0, int editId = 0)
        {
            InitializeComponent();
            
            CBConsumable.IsEnabled = false;
            this.mode = mode;
            this.car = car;
            this.consumable = consumable;
            this.quantity = quantity;
            this.editId = editId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            // Load data into the table carsCBConsumableByCar. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.carsCBConsumableByCarTableAdapter dataSet1carsCBConsumableByCarTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.carsCBConsumableByCarTableAdapter();
            dataSet1carsCBConsumableByCarTableAdapter.Fill(dataSet1.carsCBConsumableByCar);
            System.Windows.Data.CollectionViewSource carsCBConsumableByCarViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("carsCBConsumableByCarViewSource")));
            carsCBConsumableByCarViewSource.View.MoveCurrentToFirst();
            // Load data into the table DocDetilsComboBoxView. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.DocDetilsComboBoxViewTableAdapter dataSet1DocDetilsComboBoxViewTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.DocDetilsComboBoxViewTableAdapter();
            dataSet1DocDetilsComboBoxViewTableAdapter.Fill(dataSet1.DocDetilsComboBoxView);
            System.Windows.Data.CollectionViewSource docDetilsComboBoxViewViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("docDetilsComboBoxViewViewSource")));
            docDetilsComboBoxViewViewSource.View.MoveCurrentToFirst();
            


            if (mode == 1)
            {
                /*//MessageBox.Show(consumable.ToString());
                Singletone.docDetails = consumable;
                DataTable dt;
                dt = sql.ConsumableByCarComboboxClick();
                comboBox2.DisplayMember = "concat";
                comboBox2.ValueMember = "idDetails";
                comboBox2.DataSource = dt;
                comboBox2.SelectedValue = consumable;
                comboBox1.SelectedValue = car;
                textBox1.Text = quantity.ToString();*/

                CBConsumable.SelectedValue = consumable;
                textBoxQuantity.Text = quantity.ToString();

                this.Title = "Редактиране на разпределена стока";
                b1.Content = "Редактиране";
            }
            else
            {
                CBConsumable.SelectedIndex = -1;
                this.Title = "Разпределяне на стока";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConsumableByCarDocDetails CBYCDocDetails = new ConsumableByCarDocDetails();
            CBYCDocDetails.ShowDialog();

            if (CBYCDocDetails.DialogResult.HasValue && CBYCDocDetails.DialogResult.Value)
            {
                /*DataTable dt;
                dt = sql.ConsumableByCarComboboxClick();
                CBConsumable.DisplayMemberPath = "concat";
                CBConsumable.SelectedValuePath = "idDetails";
                CBConsumable.DataContext = dt;*/
                CBConsumable.SelectedValue = Singletone.docDetails;
                //comboBox2.DropDownStyle = ComboBoxStyle.Simple;
                //MessageBox.Show(comboBox2.SelectedValue.ToString());
                //maxQuantity = Singletone.docQuantity;
                //this.docDetilsComboBoxViewTableAdapter.Fill(this.carprojectDataSet.DocDetilsComboBoxView);
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CBCar.SelectedIndex != -1 && CBConsumable.SelectedIndex != -1 && textBoxQuantity.Text != "")
            {
                if (mode == 0)
                {
                    decimal usedQantity = 0;
                    int doc = Convert.ToInt32(CBConsumable.SelectedValue.ToString());
                    decimal maxQ = sql.checkMaxQuantity(doc);
                    usedQantity = sql.checkUsedQuantity(doc);

                    decimal compareUsedMax = 0;
                    compareUsedMax = maxQ - usedQantity;
                    if (textBoxQuantity.Text == "")
                    {
                        MessageBox.Show("Vuvedete kolichestvo!");
                    }
                    else 
                    { 

                        if (Convert.ToDecimal(textBoxQuantity.Text.ToString()) > compareUsedMax || Convert.ToDecimal(textBoxQuantity.Text.ToString()) == 0)
                        {
                            MessageBox.Show("Не може да надвишите максималното количество!");
                        }
                        else
                        {
                            int cars = int.Parse(CBCar.SelectedValue.ToString());
                            //int doc = int.Parse(comboBox2.SelectedValue.ToString());
                            sql.addConsumableByCar(cars, doc, Convert.ToDecimal(textBoxQuantity.Text.ToString()));
                            DialogResult = true;
                        }
                    }

                }
                else if (mode == 1)
                {
                    decimal usedQantity = 0;
                    int doc = Convert.ToInt32(CBConsumable.SelectedValue.ToString());
                    decimal maxQ = sql.checkMaxQuantity(doc);
                    usedQantity = sql.checkUsedQuantity(doc);

                    decimal compareUsedMax = 0;
                    compareUsedMax = maxQ - usedQantity + quantity;
                    if (textBoxQuantity.Text == "")
                    {
                        MessageBox.Show("Vuvedete kolichestvo!");
                    }
                    else
                    {
                        if (Convert.ToDecimal(textBoxQuantity.Text.ToString()) > compareUsedMax || Convert.ToDecimal(textBoxQuantity.Text.ToString()) == 0)
                        {
                            MessageBox.Show("Не може да надвишите максималното количество!");
                        }
                        else
                        {
                            int cars = int.Parse(CBCar.SelectedValue.ToString());
                            //int doc = int.Parse(comboBox2.SelectedValue.ToString());
                            sql.editConsumableByCar(cars, doc, Convert.ToDecimal(textBoxQuantity.Text.ToString()), editId);
                            DialogResult = true;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("populnete vsichki poleta !");
            }
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
