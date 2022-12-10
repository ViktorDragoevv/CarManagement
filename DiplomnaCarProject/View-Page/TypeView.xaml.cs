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
    /// Interaction logic for TypeView.xaml
    /// </summary>
    public partial class TypeView : Page
    {
        SQL sql = new SQL();

        public TypeView()
        {
            InitializeComponent();
        }

        public void UpdateDataGrid()
        {
            DiplomnaCarProject.DataSet1TableAdapters.typeTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.typeTableAdapter();
            typeDataGrid.ItemsSource = null;
            typeDataGrid.ItemsSource = tableAdapter.GetData();
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            DiplomnaCarProject.DataSet1 data = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.typeTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.typeTableAdapter();
            tableAdapter.Fill(data.type);
            System.Windows.Data.CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(this.FindResource("typeViewSource")));
            source.View.MoveCurrentToFirst();

        }

        private void AddMeasure_Click(object sender, RoutedEventArgs e)
        {
            AddEditType addTypeDialog = new AddEditType(0);
            addTypeDialog.ShowDialog();

            if (addTypeDialog.DialogResult.HasValue && addTypeDialog.DialogResult.Value)
            {
                UpdateDataGrid();
            }
            //CollectionViewSource.GetDefaultView(this.modelDataGrid).Refresh();



        }

        private void deleteMeasure_Click(object sender, RoutedEventArgs e)
        {

            DataRowView rowview = typeDataGrid.SelectedItem as DataRowView;
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
                        sql.deleteType(int.Parse(rowview.Row[0].ToString()));
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
            DataRowView rowview = typeDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {
                AddEditType addTypeDialog = new AddEditType(1, int.Parse(rowview.Row[0].ToString()), rowview.Row[1].ToString());
                addTypeDialog.ShowDialog();



                if (addTypeDialog.DialogResult.HasValue && addTypeDialog.DialogResult.Value)
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
