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
using System.Windows.Shapes;

namespace DiplomnaCarProject.DialogWindows
{
    /// <summary>
    /// Interaction logic for AddEditPeopleDialogView.xaml
    /// </summary>
    public partial class AddEditPeopleDialogView : Window
    {
        SQL sql = new SQL();
        List<PeopleClass> listPeople = new List<PeopleClass>();

        public AddEditPeopleDialogView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            // Load data into the table people. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.peopleTableAdapter dataSet1peopleTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.peopleTableAdapter();
            dataSet1peopleTableAdapter.Fill(dataSet1.people);
            System.Windows.Data.CollectionViewSource peopleViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("peopleViewSource")));
            peopleViewSource.View.MoveCurrentToFirst();
            this.Title = "Добавяне на хора";
        }

        public void UpdateDataGrid()
        {
            DiplomnaCarProject.DataSet1TableAdapters.peopleTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.peopleTableAdapter();
            peopleDataGrid.ItemsSource = null;
            peopleDataGrid.ItemsSource = tableAdapter.GetData();
        }

        private void AddPeople_Click(object sender, RoutedEventArgs e)
        {
            AddEditPeople addEditPeople = new AddEditPeople(0);
            addEditPeople.ShowDialog();

            if (addEditPeople.DialogResult.HasValue && addEditPeople.DialogResult.Value)
            {
                UpdateDataGrid();
            }
            //CollectionViewSource.GetDefaultView(this.modelDataGrid).Refresh();



        }

        private void deletePeople_Click(object sender, RoutedEventArgs e)
        {

            DataRowView rowview = peopleDataGrid.SelectedItem as DataRowView;
            if (rowview == null)
            {

            }
            else
            {

                var Result = MessageBox.Show("Сигурни ли сте , че искате да изтриете този запис ?", "Изтриване на марка", MessageBoxButton.YesNo, MessageBoxImage.Question);
                //DialogHost.Show("Сигурни ли сте , че искате да изтриете този запис ?", "Изтриване на марка");
                if (Result == MessageBoxResult.Yes)
                {




                    try
                    {
                        sql.deletePerson(int.Parse(rowview.Row[0].ToString()));
                        UpdateDataGrid();
                        MessageBox.Show("Успешно изтрит човек");
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

        private void editPeople_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = peopleDataGrid.SelectedItem as DataRowView;
            if (rowview != null)
            {
                AddEditPeople addEditPeople = new AddEditPeople(1, int.Parse(rowview.Row[0].ToString()), rowview.Row[1].ToString(), rowview.Row[2].ToString());
                addEditPeople.ShowDialog();



                if (addEditPeople.DialogResult.HasValue && addEditPeople.DialogResult.Value)
                {
                    UpdateDataGrid();
                }





            }
            else
            {
                MessageBox.Show("Изберете елемент");
            }




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < peopleDataGrid.Items.Count; i++)
            {
                var item = peopleDataGrid.Items[i];
                var mycheckbox = peopleDataGrid.Columns[0].GetCellContent(item) as CheckBox;
                if ((bool)mycheckbox.IsChecked)
                {
                    /* string ID = peopleDataGrid.SelectedCells[1].Column.GetCellContent(item).ToString();
                     string name = (peopleDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                     string mail = (peopleDataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;*/
                    string ID = (peopleDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    string name = (peopleDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                    string mail = (peopleDataGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                    PeopleClass p = new PeopleClass();
                    p.id = ID;
                    p.name = name;
                    p.mail = mail;
                    listPeople.Add(p);
                    Singletone.PeopleIDList = listPeople;
                    
                }

            }
            DialogResult = true;
        }
    }
}
