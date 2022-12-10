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
    /// Interaction logic for ConsumableView.xaml
    /// </summary>
    public partial class ConsumableView : Page
    {
        SQL sql = new SQL();

        public ConsumableView()
        {
            InitializeComponent();
        }

        public void UpdateDataGrid()
        {
            DiplomnaCarProject.DataSet1TableAdapters.ConsumablesJoinTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.ConsumablesJoinTableAdapter();
            consumablesJoinDataGrid.ItemsSource = null;
            consumablesJoinDataGrid.ItemsSource = tableAdapter.GetData();
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            DiplomnaCarProject.DataSet1 data = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.ConsumablesJoinTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.ConsumablesJoinTableAdapter();
            tableAdapter.Fill(data.ConsumablesJoin);
            System.Windows.Data.CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(this.FindResource("consumablesJoinViewSource")));
            source.View.MoveCurrentToFirst();

        }

        private void AddMeasure_Click(object sender, RoutedEventArgs e)
        {
            AddEditConsumable addConsumableDialog = new AddEditConsumable(0);
            addConsumableDialog.ShowDialog();

            if (addConsumableDialog.DialogResult.HasValue && addConsumableDialog.DialogResult.Value)
            {
                UpdateDataGrid();
            }
            //CollectionViewSource.GetDefaultView(this.modelDataGrid).Refresh();



        }

        private void deleteMeasure_Click(object sender, RoutedEventArgs e)
        {

            DataRowView rowview = consumablesJoinDataGrid.SelectedItem as DataRowView;
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
                        sql.deleteConsumable(int.Parse(rowview.Row[0].ToString()));
                        UpdateDataGrid();
                        MessageBox.Show("Успешно изтрита мярка");
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

        private void editMeasure_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = consumablesJoinDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {
                AddEditConsumable addConsumableDialog = new AddEditConsumable(1, rowview.Row[2].ToString(), int.Parse(rowview.Row[5].ToString()), int.Parse(rowview.Row[6].ToString()), rowview.Row[1].ToString(), int.Parse(rowview.Row[0].ToString()));
                addConsumableDialog.ShowDialog();



                if (addConsumableDialog.DialogResult.HasValue && addConsumableDialog.DialogResult.Value)
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
