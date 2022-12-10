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
using System.Windows.Shapes;

namespace DiplomnaCarProject.DialogWindows
{
    /// <summary>
    /// Interaction logic for ConsumableByCarDocDetails.xaml
    /// </summary>
    public partial class ConsumableByCarDocDetails : Window
    {
        public ConsumableByCarDocDetails()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            // Load data into the table ConsumableByCarSelectConsumablee. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.ConsumableByCarSelectConsumableeTableAdapter dataSet1ConsumableByCarSelectConsumableeTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.ConsumableByCarSelectConsumableeTableAdapter();
            dataSet1ConsumableByCarSelectConsumableeTableAdapter.Fill(dataSet1.ConsumableByCarSelectConsumablee);
            System.Windows.Data.CollectionViewSource consumableByCarSelectConsumableeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("consumableByCarSelectConsumableeViewSource")));
            consumableByCarSelectConsumableeViewSource.View.MoveCurrentToFirst();
            this.Title = "Налични консумативи";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = consumableByCarSelectConsumableeDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {
                decimal beginQuantity = Convert.ToDecimal(rowview.Row[2].ToString());
                int editid = int.Parse(rowview.Row[7].ToString());
                
                Singletone.docDetails = editid;
                Singletone.docQuantity = beginQuantity;
                //MessageBox.Show(editid.ToString());
                //MessageBox.Show(beginQuantity.ToString());
                DialogResult = true;

            }
        }
    }
}
