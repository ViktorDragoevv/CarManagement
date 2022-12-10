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
    /// Interaction logic for ModelViewPage.xaml
    /// </summary>
    public partial class ModelViewPage : Page
    {
        SQL sql = new SQL();
        public ModelViewPage()
        {
            InitializeComponent();
            //modelDataGrid.UnselectAll();
        }

        public void UpdateDataGrid()
        {
            DiplomnaCarProject.DataSet1TableAdapters.modelTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.modelTableAdapter();
            modelDataGrid.ItemsSource = null;
            modelDataGrid.ItemsSource = tableAdapter.GetData();
        }

        private void AddModel_Click(object sender, RoutedEventArgs e)
        {
            AddEditModel addBrandDialog = new AddEditModel(0);
            addBrandDialog.ShowDialog();

            if (addBrandDialog.DialogResult.HasValue && addBrandDialog.DialogResult.Value)
            {
                UpdateDataGrid();
            }
            



        }

        private void deleteModel_Click(object sender, RoutedEventArgs e)
        {

            DataRowView rowview = modelDataGrid.SelectedItem as DataRowView;
            if (rowview == null)
            {

                MessageBox.Show("Изберете ред за изтриване !");


            }
            else
            {
                


                var Result = MessageBox.Show("Сигурни ли сте , че искате да изтриете този запис ?", "Изтриване на модел", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (Result == MessageBoxResult.Yes)
                {




                    try
                    {
                        sql.deleteModel(int.Parse(rowview.Row[0].ToString()));
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

        private void editModel_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = modelDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {
                
                AddEditModel addeditModelDialog = new AddEditModel(1, int.Parse(rowview.Row[1].ToString()), rowview.Row[2].ToString(), int.Parse(rowview.Row[0].ToString()));
                addeditModelDialog.ShowDialog();



                if (addeditModelDialog.DialogResult.HasValue && addeditModelDialog.DialogResult.Value)
                {
                    UpdateDataGrid();
                }





            }
            else
            {
                MessageBox.Show("Изберете елемент");
            }




        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DiplomnaCarProject.DataSet1 data = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.modelTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.modelTableAdapter();
            tableAdapter.Fill(data.model);
            System.Windows.Data.CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(this.FindResource("modelViewSource")));
            source.View.MoveCurrentToFirst();
        }

        
    }
}
