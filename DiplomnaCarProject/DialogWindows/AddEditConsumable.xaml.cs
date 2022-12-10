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
    /// Interaction logic for AddEditConsumable.xaml
    /// </summary>
    public partial class AddEditConsumable : Window
    {
        SQL sql = new SQL();
        private int mode;
        private string consumable;
        private int idedit;
        int type;
        int measure;
        string notify;

        public AddEditConsumable(int mode , string consumable = "" , int type = 0, int measure = 0 ,string notify="",int idedit =0)
        {
            InitializeComponent();

            this.mode = mode;
            this.consumable = consumable;
            this.type = type;
            this.measure = measure;
            this.notify = notify;
            this.idedit = idedit;




        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            // Load data into the table typeCbView. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.typeCbViewTableAdapter dataSet1typeCbViewTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.typeCbViewTableAdapter();
            dataSet1typeCbViewTableAdapter.Fill(dataSet1.typeCbView);
            System.Windows.Data.CollectionViewSource typeCbViewViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("typeCbViewViewSource")));
            typeCbViewViewSource.View.MoveCurrentToFirst();
            // Load data into the table measuresCbView. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.measuresCbViewTableAdapter dataSet1measuresCbViewTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.measuresCbViewTableAdapter();
            dataSet1measuresCbViewTableAdapter.Fill(dataSet1.measuresCbView);
            System.Windows.Data.CollectionViewSource measuresCbViewViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("measuresCbViewViewSource")));
            measuresCbViewViewSource.View.MoveCurrentToFirst();
            this.Title = "Добавяне на консуматив";

            if (mode == 1)
            {
               
                if (notify == "0")
                {
                    
                    checkBOXnotify.IsChecked = false;
                }
                else if (notify == "1")
                {
                    checkBOXnotify.IsChecked = true;
                }

                textBoxConsumable.Text = consumable;
                cbMeasure.SelectedValue = measure;
                cbType.SelectedValue = type;



                /*//DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
                DiplomnaCarProject.DataSet1TableAdapters.modelSortTableAdapter dsds = new DiplomnaCarProject.DataSet1TableAdapters.modelSortTableAdapter();
                dsds.FillBy(dataSet1.modelSort);
                cbBrand.SelectedValue = brand;
                cbModel.SelectedValue = model;
                cbFuel.SelectedValue = fuel;
                textBoxRegNum.Text = regNum;
                textBoxVIN.Text = VIN;
                textBoxColor.Text = color;
                textBoxEngineNum.Text = engineNum;*/




            }
            else if (mode == 0)
            {
                /*cbBrand.SelectedIndex = -1;
                cbModel.IsEnabled = false;*/
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (mode == 0)
            {
                if (cbMeasure.SelectedIndex == -1 || cbType.SelectedIndex == -1  || textBoxConsumable.Text == "" )
                {
                    MessageBox.Show("Populnete poletata");
                }
                else
                {
                    bool notifyy = false;
                    if (checkBOXnotify.IsChecked==true)
                    {
                        notifyy = true;
                    }
                    sql.addConsumable(int.Parse(cbType.SelectedValue.ToString()), int.Parse(cbMeasure.SelectedValue.ToString()),textBoxConsumable.Text.ToString(), notifyy);
                    
                    DialogResult = true;
                    this.Close();
                }
            }
            else if (mode == 1)
            {
                if (cbMeasure.SelectedIndex == -1 || cbType.SelectedIndex == -1 || textBoxConsumable.Text == "")
                {
                    MessageBox.Show("Populnete poletata");
                }
                else
                {
                    bool notifyy = false;
                    if (checkBOXnotify.IsChecked == true)
                    {
                        notifyy = true;
                    }
                    
                    sql.editConsumable(int.Parse(cbType.SelectedValue.ToString()), int.Parse(cbMeasure.SelectedValue.ToString()), textBoxConsumable.Text.ToString(), notifyy , idedit);

                    DialogResult = true;
                    this.Close();

                }
            }
        }
    }
}
