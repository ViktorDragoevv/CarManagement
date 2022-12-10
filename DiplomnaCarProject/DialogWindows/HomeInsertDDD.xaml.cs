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
    /// Interaction logic for HomeInsertDDD.xaml
    /// </summary>
    public partial class HomeInsertDDD : Window
    {
        SQL sql = new SQL();
        int documentType = 1;
        List<ClassDocumentDetails> list = new List<ClassDocumentDetails>();

        decimal quantity = 1;
        int document = 0;
        int consumable = 0;
        int carID = 0;

        public HomeInsertDDD(int consumable, int carID)
        {
            InitializeComponent();

            this.consumable = consumable;
            this.carID = carID;
            datePicker.SelectedDateFormat = DatePickerFormat.Short;

        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            if (dokumentNomer.Text == "" || textBoxPrice.Text == "" || cbContragent.SelectedIndex == -1)
            {

            }
            else
            {
                int contragent = int.Parse(cbContragent.SelectedValue.ToString());
                string documentNumber = dokumentNomer.Text.ToString();
                if (sql.DocumentNumberCheck(documentNumber, contragent) == true)
                {
                    MessageBox.Show("Вече съществува документ с такъв номер");
                    
                }
                else
                {

                    string date = Convert.ToDateTime(datePicker.Text).ToString("yyyy/MM/dd");
                    //int contragent = int.Parse(comboBox1.SelectedValue.ToString());
                    //string documentNumber = textBox1.Text.ToString();
                    string user = Singletone.LogedUser;

                    ////Da se opravi !
                    //int userid = sql.GetLoggedUserId(user);
                    int userid = 1;
                    decimal bruto = Convert.ToDecimal(textBoxPrice.Text.ToString());
                    decimal multi = 1.2m;
                    decimal res = bruto * multi;
                    decimal neto = res;
                    int docDD = 0;



                    ClassDocumentDetails doc = new ClassDocumentDetails();
                    doc.bruto = bruto;
                    doc.neto = res;
                    doc.quantity = quantity;
                    doc.consumable = consumable;


                    list.Add(doc);



                    //tuk trqq da se opravi !!!
                    sql.addDocuments(userid, date, documentNumber, contragent, documentType, list);
                    //document = sql.SelectDocumentID();
                    //sql.addDocDetails(bruto, neto, document, quantity, consumable);
                    docDD = sql.SelectDocDetailsID();


                    //Da se opravi !!!!


                    sql.addConsumableByCar(carID, docDD, quantity);
                    

                    
                    AddNotification addeditCarDialog = new AddNotification(carID,consumable,1);
                    addeditCarDialog.ShowDialog();
                    this.Visibility = Visibility.Hidden;


                    if (addeditCarDialog.DialogResult.HasValue && addeditCarDialog.DialogResult.Value)
                    {
                        DialogResult = true;
                        this.Close();
                    }


                }
            }

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datePicker.SelectedDate = DateTime.Today;
            if (consumable == 1)
            {
                this.Title = "Добавяне на Гражданска";
            }
            else if (consumable == 2)
            {
                this.Title = "Добавяне на Винетка";
            }
            else if (consumable == 3)
            {
                this.Title = "Добавяне на Преглед";
            }
            DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            // TODO: Add code here to load data into the table homeContractorCombobox.
            // This code could not be generated, because the dataSet1homeContractorComboboxTableAdapter.Fill method is missing, or has unrecognized parameters.
            DiplomnaCarProject.DataSet1TableAdapters.homeContractorComboboxTableAdapter dataSet1homeContractorComboboxTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.homeContractorComboboxTableAdapter();
            System.Windows.Data.CollectionViewSource homeContractorComboboxViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("homeContractorComboboxViewSource")));
            homeContractorComboboxViewSource.View.MoveCurrentToFirst();
            // Load data into the table contractors. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.contractorsTableAdapter dataSet1contractorsTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.contractorsTableAdapter();
            dataSet1contractorsTableAdapter.Fill(dataSet1.contractors);
            System.Windows.Data.CollectionViewSource contractorsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contractorsViewSource")));
            contractorsViewSource.View.MoveCurrentToFirst();
        }
    }
}
