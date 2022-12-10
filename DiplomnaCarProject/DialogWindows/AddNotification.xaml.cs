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
    /// Interaction logic for AddNotification.xaml
    /// </summary>
    public partial class AddNotification : Window
    {
        List<PeopleClass> peopleIDList = new List<PeopleClass>();
        SQL sql = new SQL();
        int carID;
        int consumable;
        int mode;
        public AddNotification(int carID,int consumable = 0,int mode =0)
        {
            InitializeComponent();
            this.carID = carID;
            this.consumable = consumable;
            this.mode = mode;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*DataRowView rowview = carsDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {*/

                AddEditPeopleDialogView addeditCarDialog = new AddEditPeopleDialogView();
                addeditCarDialog.ShowDialog();



                if (addeditCarDialog.DialogResult.HasValue && addeditCarDialog.DialogResult.Value)
                {
                //UpdateDataGrid();
                peopleIDList = Singletone.PeopleIDList;
                listView.ItemsSource = peopleIDList;
                }





            /*}
            else
            {
                MessageBox.Show("Изберете елемент");
            }*/
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (peopleIDList.Count == 0)
            {
                int notification = 0;
                int consumableID = Convert.ToInt32(CBConsumable.SelectedValue);
                DateTime date = datePicker.SelectedDate.Value;
                
                    sql.NotificationInsert(carID, consumableID, date);
               
                notification = sql.GetMaxNotificationID();
                sql.Notify(notification, 1, 15);
                DialogResult = true;
                
                this.Close();
            }
            else
            {
                int count = 0;
                int notification = 0;
                int consumableID = Convert.ToInt32(CBConsumable.SelectedValue);
                //DateTime date = DateTime.Today.AddDays(7);
                DateTime date = datePicker.SelectedDate.Value;
                //MessageBox.Show(date.ToShortDateString());
                
                    sql.NotificationInsert(carID, consumableID, date);
                
                
                foreach (var per in peopleIDList)
                {
                    notification = sql.GetMaxNotificationID();
                    //int day = peopleIDList[count].days;
                    string pers = peopleIDList[count].id;
                    sql.Notify(notification, int.Parse(pers.ToString()), int.Parse(textBoxDays.Text.ToString()));
                    count++;
                }
                DialogResult = true;
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            // Load data into the table consumablesOfferedConsumableContractors. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.consumablesOfferedConsumableContractorsTableAdapter dataSet1consumablesOfferedConsumableContractorsTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.consumablesOfferedConsumableContractorsTableAdapter();
            dataSet1consumablesOfferedConsumableContractorsTableAdapter.Fill(dataSet1.consumablesOfferedConsumableContractors);
            System.Windows.Data.CollectionViewSource consumablesOfferedConsumableContractorsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("consumablesOfferedConsumableContractorsViewSource")));
            consumablesOfferedConsumableContractorsViewSource.View.MoveCurrentToFirst();
            textBoxDays.Text = "15";
            datePicker.SelectedDate = DateTime.Today;
            if (mode == 1){
                CBConsumable.SelectedValue = consumable;
            }
            datePicker.DisplayDate = DateTime.Today;
            this.Title = "Добавяне на известие";
        }
    }
}
