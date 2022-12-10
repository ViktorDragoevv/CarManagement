using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddEditOfferedConsumable.xaml
    /// </summary>
    public partial class AddEditOfferedConsumable : Window
    {
        public List<int> offeredConsumablesIDList = new List<int>();
        public AddEditOfferedConsumable()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            // Load data into the table consumablesOfferedConsumableContractors. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.consumablesOfferedConsumableContractorsTableAdapter dataSet1consumablesOfferedConsumableContractorsTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.consumablesOfferedConsumableContractorsTableAdapter();
            dataSet1consumablesOfferedConsumableContractorsTableAdapter.Fill(dataSet1.consumablesOfferedConsumableContractors);
            System.Windows.Data.CollectionViewSource consumablesOfferedConsumableContractorsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("consumablesOfferedConsumableContractorsViewSource")));
            consumablesOfferedConsumableContractorsViewSource.View.MoveCurrentToFirst();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            
               /* bool checkBoxSelect = Convert.ToBoolean(drv.is);
                if (checkBoxSelect)
                {
                    offeredConsumablesIDList.Add(Convert.ToInt32(drv.Cells[1].Value));
                }

                for (int i = 0; i < consumablesOfferedConsumableContractorsDataGrid.Items.Count; i++)
                {
                    var item = consumablesOfferedConsumableContractorsDataGrid.Items[i];
                    var mycheckbox = consumablesOfferedConsumableContractorsDataGrid.Columns[1].GetCellContent(item) as CheckBox;
                    if ((bool)mycheckbox.IsChecked)
                    {
                        offeredConsumablesIDList.Add();
                    }
                }*/

                for (int i = 0; i < consumablesOfferedConsumableContractorsDataGrid.Items.Count; i++)
                {
                    var item = consumablesOfferedConsumableContractorsDataGrid.Items[i];
                    var mycheckbox = consumablesOfferedConsumableContractorsDataGrid.Columns[0].GetCellContent(item) as CheckBox;
                    if ((bool)mycheckbox.IsChecked)
                    {
                        string ID = (consumablesOfferedConsumableContractorsDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                        offeredConsumablesIDList.Add(int.Parse(ID.ToString()));
                    }
                    
                }



            
            this.Hide();
        }
    }
}
