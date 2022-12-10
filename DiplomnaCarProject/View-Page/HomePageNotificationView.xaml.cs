using DiplomnaCarProject.DialogWindows;
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
    /// Interaction logic for HomePageNotificationView.xaml
    /// </summary>
    public partial class HomePageNotificationView : Page
    {
        public HomePageNotificationView()
        {
            InitializeComponent();
            
        }
        public void UpdateDataGrid()
        {
            DiplomnaCarProject.DataSet1TableAdapters.homeDebugTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.homeDebugTableAdapter();
            homeDebugDataGrid.ItemsSource = null;
            homeDebugDataGrid.ItemsSource = tableAdapter.GetData();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.homeDebugTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.homeDebugTableAdapter();
            tableAdapter.Fill(dataSet1.homeDebug);
            System.Windows.Data.CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(this.FindResource("homeDebugViewSource")));
            source.View.MoveCurrentToFirst();
            foreach (var column in homeDebugDataGrid.Columns)
            {
                if (column.Header == "Снимка")
                {
                    
                }
            }
            
        }

        private void funk()
        {/*
            foreach (DataGridViewRow row in DataGridViewRow1.Rows)
            {
                var now = DateTime.Now;
                var cellDate = DateTime.Parse(row.Cells[14].Value.ToString());
                var forTenDays = now.AddDays(+10);

                if (now > cellDate)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else if ((now < cellDate) && (cellDate < forTenDays))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }*/
        }

        private void ShowProfile_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = homeDebugDataGrid.SelectedItem as DataRowView;

            AddEditCar carListForm = new AddEditCar(3,0,0,0,"","","","", int.Parse(rowview.Row[0].ToString()));

            carListForm.ShowDialog();

        }

        private void AddGrajdanska_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = homeDebugDataGrid.SelectedItem as DataRowView;

            HomeInsertDDD homeInsertDDD = new HomeInsertDDD(1, int.Parse(rowview.Row[0].ToString()));
            homeInsertDDD.ShowDialog();
            //this.Visibility = Visibility.Hidden;
            if (homeInsertDDD.DialogResult.HasValue && homeInsertDDD.DialogResult.Value)
            {
                UpdateDataGrid();
                //this.Visibility = Visibility.Visible;

            }

        }

        private void AddVinetka_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = homeDebugDataGrid.SelectedItem as DataRowView;

            HomeInsertDDD homeInsertDDD = new HomeInsertDDD(2, int.Parse(rowview.Row[0].ToString()));
            homeInsertDDD.ShowDialog();
            
            if (homeInsertDDD.DialogResult.HasValue && homeInsertDDD.DialogResult.Value)
            {
                UpdateDataGrid();
                
            }
        }

        private void AddPregled_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = homeDebugDataGrid.SelectedItem as DataRowView;

            HomeInsertDDD homeInsertDDD = new HomeInsertDDD(3, int.Parse(rowview.Row[0].ToString()));
            homeInsertDDD.ShowDialog();

            if (homeInsertDDD.DialogResult.HasValue && homeInsertDDD.DialogResult.Value)
            {
                UpdateDataGrid();

            }
        }

        private void AddKasko_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = homeDebugDataGrid.SelectedItem as DataRowView;

            HomeInsertDDD homeInsertDDD = new HomeInsertDDD(4, int.Parse(rowview.Row[0].ToString()));
            homeInsertDDD.ShowDialog();

            if (homeInsertDDD.DialogResult.HasValue && homeInsertDDD.DialogResult.Value)
            {
                UpdateDataGrid();

            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = homeDebugDataGrid.SelectedItem as DataRowView;
            AddEditConsumableByCar consumableByCar = new  AddEditConsumableByCar(0);
            
            consumableByCar.ShowDialog();

            if (consumableByCar.DialogResult.HasValue && consumableByCar.DialogResult.Value)
            {
                UpdateDataGrid();


                AddNotification addeditCarDialog = new AddNotification(int.Parse(rowview.Row[0].ToString()), 1, 0);
                addeditCarDialog.ShowDialog();
                this.Visibility = Visibility.Hidden;


                if (addeditCarDialog.DialogResult.HasValue && addeditCarDialog.DialogResult.Value)
                {
                    UpdateDataGrid();
                }


            }
        }
    }
}
