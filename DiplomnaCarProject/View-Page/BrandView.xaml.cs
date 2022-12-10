
using DiplomnaCarProject.DataSet1TableAdapters;
using MaterialDesignThemes.Wpf;
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


namespace DiplomnaCarProject
{
    /// <summary>
    /// Interaction logic for BrandView.xaml
    /// </summary>
    public partial class BrandView : Page
    {
        SQL sql = new SQL();
        
        public BrandView()
        {
            InitializeComponent();
            //BrandGridView();
            modelDataGrid.UnselectAll();





           



        }

        public void UpdateDataGrid()
        {
            DiplomnaCarProject.DataSet1TableAdapters.BrandViewTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.BrandViewTableAdapter();
            modelDataGrid.ItemsSource = null;
            modelDataGrid.ItemsSource = tableAdapter.GetData();
        }

        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            DiplomnaCarProject.DataSet1 bloodlabDataSet = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.BrandViewTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.BrandViewTableAdapter();
            tableAdapter.Fill(bloodlabDataSet.BrandView);
            System.Windows.Data.CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(this.FindResource("brandViewViewSource")));
            source.View.MoveCurrentToFirst();

        }

        private void AddBrand_Click(object sender, RoutedEventArgs e)
        {
            AddEditBrand addBrandDialog = new AddEditBrand(0);
            addBrandDialog.ShowDialog();

            if (addBrandDialog.DialogResult.HasValue && addBrandDialog.DialogResult.Value)
            {
                UpdateDataGrid();
            }
                //CollectionViewSource.GetDefaultView(this.modelDataGrid).Refresh();
            
                

        }

        private void deleteBrand_Click(object sender, RoutedEventArgs e)
        {
            
            DataRowView rowview = modelDataGrid.SelectedItem as DataRowView;
            if (rowview==null)
            {

            }
            else
            {

                var Result = MessageBox.Show( "Сигурни ли сте , че искате да изтриете този запис ?", "Изтриване на марка", MessageBoxButton.YesNo, MessageBoxImage.Question);
                DialogHost.Show("Сигурни ли сте , че искате да изтриете този запис ?", "Изтриване на марка");
                if (Result == MessageBoxResult.Yes)
                {




                    try
                    {
                        sql.deleteBrand(int.Parse(rowview.Row[0].ToString()));
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

        private void editBrand_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = modelDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {
                AddEditBrand addBrandDialog = new AddEditBrand(1, int.Parse(rowview.Row[0].ToString()), rowview.Row[1].ToString());
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
