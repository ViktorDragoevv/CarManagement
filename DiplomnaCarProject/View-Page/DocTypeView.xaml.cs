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
    /// Interaction logic for DocTypeView.xaml
    /// </summary>
    public partial class DocTypeView : Page
    {
        SQL sql = new SQL();
        public DocTypeView()
        {
            InitializeComponent();
        }

        public void UpdateDataGrid()
        {
            DiplomnaCarProject.DataSet1TableAdapters.doctypeTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.doctypeTableAdapter();
            doctypeDataGrid.ItemsSource = null;
            doctypeDataGrid.ItemsSource = tableAdapter.GetData();
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            DiplomnaCarProject.DataSet1 data = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.doctypeTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.doctypeTableAdapter();
            tableAdapter.Fill(data.doctype);
            System.Windows.Data.CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(this.FindResource("doctypeViewSource")));
            source.View.MoveCurrentToFirst();

        }

        private void AddDocType_Click(object sender, RoutedEventArgs e)
        {
            AddEditDocType addTypeDialog = new AddEditDocType(0);
            addTypeDialog.ShowDialog();

            if (addTypeDialog.DialogResult.HasValue && addTypeDialog.DialogResult.Value)
            {
                UpdateDataGrid();
            }
            //CollectionViewSource.GetDefaultView(this.modelDataGrid).Refresh();



        }

        private void DeleteDocType_Click(object sender, RoutedEventArgs e)
        {

            DataRowView rowview = doctypeDataGrid.SelectedItem as DataRowView;
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
                        sql.deleteDocType(int.Parse(rowview.Row[0].ToString()));
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

        private void EditDocType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = doctypeDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {
                AddEditDocType addTypeDialog = new AddEditDocType(1, int.Parse(rowview.Row[0].ToString()), rowview.Row[1].ToString());
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
