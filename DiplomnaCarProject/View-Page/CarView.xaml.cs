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
    /// Interaction logic for CarView.xaml
    /// </summary>
    public partial class CarView : Page
    {
        SQL sql = new SQL();
        Logger log = new Logger();
        public CarView()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DiplomnaCarProject.DataSet1 data = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.carViewJoinTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.carViewJoinTableAdapter();
            tableAdapter.Fill(data.carViewJoin);
            System.Windows.Data.CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(this.FindResource("carViewJoinViewSource")));
            source.View.MoveCurrentToFirst();
        }


        public void UpdateDataGrid()
        {
            DiplomnaCarProject.DataSet1TableAdapters.carViewJoinTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.carViewJoinTableAdapter();
            carsDataGrid.ItemsSource = null;
            carsDataGrid.ItemsSource = tableAdapter.GetData();
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            AddEditCar addeditCarDialog = new AddEditCar(0);
            addeditCarDialog.ShowDialog();

            if (addeditCarDialog.DialogResult.HasValue && addeditCarDialog.DialogResult.Value)
            {
                UpdateDataGrid();
            }




        }

        private void deleteCar_Click(object sender, RoutedEventArgs e)
        {

            DataRowView rowview = carsDataGrid.SelectedItem as DataRowView;
            if (rowview == null)
            {
                MessageBox.Show("Изберете ред за изтриване !");
            }
            else
            {
                

                var Result = MessageBox.Show("Сигурни ли сте , че искате да изтриете този запис ?", "Изтриване на МПС", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (Result == MessageBoxResult.Yes)
                {
                    
                    try
                    {
                        sql.deleteCar(int.Parse(rowview.Row[0].ToString()));
                        UpdateDataGrid();
                        MessageBox.Show("Успешно изтрито МПС");
                    }
                    catch (MySqlException ex)
                    {
                        log.Log(ex.ToString());
                        
                        if (ex.Number == 1451)
                        {
                            MessageBox.Show("Не може да изтриете запис , който се използва");
                        }

                    }

                }
                else if (Result == MessageBoxResult.No)
                {
                    Environment.Exit(0);
                }

            }



        }

        private void editCar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = carsDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {

                AddEditCar addeditCarDialog = new AddEditCar(1,int.Parse(rowview.Row[12].ToString()), int.Parse(rowview.Row[11].ToString()), int.Parse(rowview.Row[13].ToString()), rowview.Row[3].ToString(), rowview.Row[6].ToString(), rowview.Row[5].ToString(), rowview.Row[7].ToString(),int.Parse(rowview.Row[0].ToString()));
                addeditCarDialog.ShowDialog();



                if (addeditCarDialog.DialogResult.HasValue && addeditCarDialog.DialogResult.Value)
                {
                    UpdateDataGrid();
                }





            }
            else
            {
                MessageBox.Show("Изберете елемент");
            }




        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = carsDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {

                AddEditCar addeditCarDialog = new AddEditCar(3, int.Parse(rowview.Row[12].ToString()), int.Parse(rowview.Row[11].ToString()), int.Parse(rowview.Row[13].ToString()), rowview.Row[3].ToString(), rowview.Row[6].ToString(), rowview.Row[5].ToString(), rowview.Row[7].ToString(), int.Parse(rowview.Row[0].ToString()));
                addeditCarDialog.ShowDialog();



                if (addeditCarDialog.DialogResult.HasValue && addeditCarDialog.DialogResult.Value)
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
