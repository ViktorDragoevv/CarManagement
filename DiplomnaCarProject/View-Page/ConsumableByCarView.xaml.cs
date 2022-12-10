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
    /// Interaction logic for ConsumableByCarView.xaml
    /// </summary>
    public partial class ConsumableByCarView : Page
    {
        SQL sql = new SQL();

        public ConsumableByCarView()
        {
            InitializeComponent();
        }

        public void UpdateDataGrid()
        {
            DiplomnaCarProject.DataSet1TableAdapters.ConsumableByCarViewTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.ConsumableByCarViewTableAdapter();
            consumableByCarViewDataGrid.ItemsSource = null;
            consumableByCarViewDataGrid.ItemsSource = tableAdapter.GetData();
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            DiplomnaCarProject.DataSet1 bloodlabDataSet = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.ConsumableByCarViewTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.ConsumableByCarViewTableAdapter();
            tableAdapter.Fill(bloodlabDataSet.ConsumableByCarView);
            System.Windows.Data.CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(this.FindResource("consumableByCarViewViewSource")));
            source.View.MoveCurrentToFirst();

        }

        private void AddCBYC_Click(object sender, RoutedEventArgs e)
        {
            AddEditConsumableByCar addEditCBYC = new AddEditConsumableByCar(0);
            addEditCBYC.ShowDialog();

            if (addEditCBYC.DialogResult.HasValue && addEditCBYC.DialogResult.Value)
            {
                UpdateDataGrid();
            }
            //CollectionViewSource.GetDefaultView(this.modelDataGrid).Refresh();



        }

        private void deleteCBYC_Click(object sender, RoutedEventArgs e)
        {

            DataRowView rowview = consumableByCarViewDataGrid.SelectedItem as DataRowView;
            if (rowview == null)
            {

            }
            else
            {

                var Result = MessageBox.Show("Сигурни ли сте , че искате да изтриете този запис ?", "Изтриване на марка", MessageBoxButton.YesNo, MessageBoxImage.Question);
                //DialogHost.Show("Сигурни ли сте , че искате да изтриете този запис ?", "Изтриване на марка");
                if (Result == MessageBoxResult.Yes)
                {




                    try
                    {
                        sql.deleteconsumableBycarQuerry(int.Parse(rowview.Row[0].ToString()));
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

        private void editCBYC_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = consumableByCarViewDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {
                AddEditConsumableByCar addBrandDialog = new AddEditConsumableByCar(1, int.Parse(rowview.Row[1].ToString()), int.Parse(rowview.Row[2].ToString()), decimal.Parse(rowview.Row[5].ToString()), int.Parse(rowview.Row[0].ToString()));
                addBrandDialog.ShowDialog();



                if (addBrandDialog.DialogResult.HasValue && addBrandDialog.DialogResult.Value)
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
