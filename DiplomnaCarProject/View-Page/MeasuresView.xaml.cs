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
    /// Interaction logic for MeasuresView.xaml
    /// </summary>
    public partial class MeasuresView : Page
    {
        SQL sql = new SQL();

        public MeasuresView()
        {
            InitializeComponent();
        }


        public void UpdateDataGrid()
        {
            DiplomnaCarProject.DataSet1TableAdapters.measuresTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.measuresTableAdapter();
            measuresDataGrid.ItemsSource = null;
            measuresDataGrid.ItemsSource = tableAdapter.GetData();
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            DiplomnaCarProject.DataSet1 data = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.measuresTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.measuresTableAdapter();
            tableAdapter.Fill(data.measures);
            System.Windows.Data.CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(this.FindResource("measuresViewSource")));
            source.View.MoveCurrentToFirst();

        }

        private void AddMeasure_Click(object sender, RoutedEventArgs e)
        {
            AddEditMeasure addMeasureDialog = new AddEditMeasure(0);
            addMeasureDialog.ShowDialog();

            if (addMeasureDialog.DialogResult.HasValue && addMeasureDialog.DialogResult.Value)
            {
                UpdateDataGrid();
            }
            //CollectionViewSource.GetDefaultView(this.modelDataGrid).Refresh();



        }

        private void deleteMeasure_Click(object sender, RoutedEventArgs e)
        {

            DataRowView rowview = measuresDataGrid.SelectedItem as DataRowView;
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
                        sql.deleteMeasure(int.Parse(rowview.Row[0].ToString()));
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
            DataRowView rowview = measuresDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {
                AddEditMeasure addMeasureDialog = new AddEditMeasure(1, int.Parse(rowview.Row[0].ToString()), rowview.Row[1].ToString());
                addMeasureDialog.ShowDialog();



                if (addMeasureDialog.DialogResult.HasValue && addMeasureDialog.DialogResult.Value)
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
