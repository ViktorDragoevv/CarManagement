using DiplomnaCarProject.DialogWindows;
using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiplomnaCarProject.View_Page
{
    /// <summary>
    /// Interaction logic for FuelView.xaml
    /// </summary>
    public partial class FuelView : Page
    {
        SQL sql = new SQL();
        public FuelView()
        {
            InitializeComponent();
            fuelDataGrid.UnselectAll();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DiplomnaCarProject.DataSet1 data = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.fuelTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.fuelTableAdapter();
            tableAdapter.Fill(data.fuel);
            System.Windows.Data.CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(this.FindResource("fuelViewSource")));
            source.View.MoveCurrentToFirst();
        }


        public void UpdateDataGrid()
        {
            DiplomnaCarProject.DataSet1TableAdapters.fuelTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.fuelTableAdapter();
            fuelDataGrid.ItemsSource = null;
            fuelDataGrid.ItemsSource = tableAdapter.GetData();
        }

        private void AddFuel_Click(object sender, RoutedEventArgs e)
        {
            AddEditFuel addFuelDialog = new AddEditFuel(0);
            addFuelDialog.ShowDialog();

            if (addFuelDialog.DialogResult.HasValue && addFuelDialog.DialogResult.Value)
            {
                UpdateDataGrid();
            }




        }

        private void deleteFuel_Click(object sender, RoutedEventArgs e)
        {

            DataRowView rowview = fuelDataGrid.SelectedItem as DataRowView;
            if (rowview == null)
            {

                MessageBox.Show("Изберете ред за изтриване !");


            }
            else
            {
                


                var Result = MessageBox.Show("Сигурни ли сте , че искате да изтриете този запис ?", "Изтриване на тип гориво", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (Result == MessageBoxResult.Yes)
                {




                    try
                    {
                        sql.deleteFuel(int.Parse(rowview.Row[0].ToString()));
                        UpdateDataGrid();
                        MessageBox.Show("Успешно изтрито МПС");
                    }
                    catch (MySqlException ex) when (ex.Number == 1451)
                    {
                        MessageBox.Show("Не може да изтриете запис , който се използва");
                    }


                }
                else if (Result == MessageBoxResult.No)
                {
                    Environment.Exit(0);
                }




            }



        }

        private void editFuel_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = fuelDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {

                AddEditFuel addeditFuelDialog = new AddEditFuel(1, int.Parse(rowview.Row[0].ToString()), rowview.Row[1].ToString());
                addeditFuelDialog.ShowDialog();



                if (addeditFuelDialog.DialogResult.HasValue && addeditFuelDialog.DialogResult.Value)
                {
                    UpdateDataGrid();
                }





            }
            else
            {
                MessageBox.Show("Изберете елемент");
            }




        }


    }
}
