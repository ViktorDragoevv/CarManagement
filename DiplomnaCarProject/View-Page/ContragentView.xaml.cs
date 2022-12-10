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
    /// Interaction logic for ContragentView.xaml
    /// </summary>
    public partial class ContragentView : Page
    {
        SQL sql = new SQL();

        public ContragentView()
        {
            InitializeComponent();
        }


        public void UpdateDataGrid()
        {
            DiplomnaCarProject.DataSet1TableAdapters.contractorsTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.contractorsTableAdapter();
            contractorsDataGrid.ItemsSource = null;
            contractorsDataGrid.ItemsSource = tableAdapter.GetData();
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            DiplomnaCarProject.DataSet1 data = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.contractorsTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.contractorsTableAdapter();
            tableAdapter.Fill(data.contractors);
            System.Windows.Data.CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contractorsViewSource")));
            source.View.MoveCurrentToFirst();

        }

        private void AddContragent_Click(object sender, RoutedEventArgs e)
        {
            AddEditContragent addContragentDialog = new AddEditContragent(0);
            addContragentDialog.ShowDialog();

            if (addContragentDialog.DialogResult.HasValue && addContragentDialog.DialogResult.Value)
            {
                UpdateDataGrid();
            }
            //CollectionViewSource.GetDefaultView(this.modelDataGrid).Refresh();



        }

        private void deleteContragent_Click(object sender, RoutedEventArgs e)
        {

            DataRowView rowview = contractorsDataGrid.SelectedItem as DataRowView;
            if (rowview == null)
            {

            }
            else
            {

                var Result = MessageBox.Show("Сигурни ли сте , че искате да изтриете този запис ?", "Изтриване на марка", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (Result == MessageBoxResult.Yes)
                {




                    try
                    {
                        sql.deleteContragent(int.Parse(rowview.Row[0].ToString()));
                        UpdateDataGrid();
                        MessageBox.Show("Успешно изтрит контрагент");
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

        private void editContragent_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = contractorsDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {
                AddEditContragent addContragentDialog = new AddEditContragent(1, rowview.Row[1].ToString(), rowview.Row[2].ToString(), rowview.Row[3].ToString(), rowview.Row[4].ToString(), rowview.Row[5].ToString(), rowview.Row[6].ToString(), int.Parse(rowview.Row[0].ToString()));
                addContragentDialog.ShowDialog();



                if (addContragentDialog.DialogResult.HasValue && addContragentDialog.DialogResult.Value)
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
