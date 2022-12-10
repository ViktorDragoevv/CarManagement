using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddEditDocument.xaml
    /// </summary>
    public partial class AddEditDocument : Window
    {
        int editnumber = 1;
        private int mode;
        string date;
        int contragent;
        int docType;
        string nomer;
        int idedit;
        int idDocument;
        SQL sql = new SQL();
        bool flag = false;
        List<ClassDocumentDetails> list = new List<ClassDocumentDetails>();
        List<ClassDocumentDetails> editList = new List<ClassDocumentDetails>();
        int ideditConsumable;
        CollectionViewSource itemCollectionViewSource;
        
        public AddEditDocument(int mode, int idedit = 0, string date = "", int contragent = 0, int docType = 0, string nomer = "", int idDocument = 0)
        {
            InitializeComponent();
            this.mode = mode;
            this.date = date;
            this.contragent = contragent;
            this.docType = docType;
            this.nomer = nomer;
            this.idedit = idedit;
            this.idDocument = idDocument;
            datagrid.UnselectAll();

            itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int success = 0;
           
            if (textBoxNomer.Text == "")
            {
                DialogHost.Show("Въведете номер на документа!");
                
            }else if (cbDocType.SelectedIndex == -1)
            {
                DialogHost.Show("Изберете вид на документа!");

            }
            
            else if(cbContragent.SelectedIndex == -1)
            {
                DialogHost.Show("Изберете контрагент!");
            }
            if (success > 0) 
            {

            }
            else
            {
                string date = Convert.ToDateTime(datePicker.Text).ToString("yyyy/MM/dd");
                string documentNumber = textBoxNomer.Text.ToString();
                int contragent = int.Parse(cbContragent.SelectedValue.ToString());
                int documentType = int.Parse(cbDocType.SelectedValue.ToString());
                string user = Singletone.LogedUser;
                //MessageBox.Show(user);
                int userid = 0;
                decimal bruto = 0;
                decimal neto = 0;

                ///DA SE OPRAVI
                userid = 1;
                //userid = sql.GetLoggedUserId(user);
                int document = 0;
                if (mode == 0)
                {
                    if (sql.documentNumberCheck(textBoxNomer.Text, contragent) == true)
                    {
                        MessageBox.Show("Вече съществува документ с такъв номер");
                        
                    }
                    else
                    {
                        if (list.Count == 0)
                        {
                            MessageBox.Show("Не може да създадете документ без стока");
                            
                        }
                        else
                        {
                            userid = 1;
                            sql.addDocuments(userid, date, documentNumber, contragent, documentType, list);
                            //document = sql.DocumentLastDoc();
                            //sql.AddDocDetailsList(document, list);
                            DialogResult = true;
                            this.Close();
                        }
                    }
                }

                else if (mode == 1)
                {
                    if (sql.documentNumberCheck(textBoxNomer.Text, contragent) == true && textBoxNomer.Text != nomer)
                    {
                        MessageBox.Show("Вече съществува документ с такъв номер");
                        
                    }
                    else
                    {
                        if (editList.Count == 0)
                        {
                            var Result = MessageBox.Show("Фактурата ще бъде изтрита поради липса на елементи! Желаете ли да продължите ?", "Vnimanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            
                            if (Result == MessageBoxResult.Yes)
                            {




                                try
                                {
                                    sql.deleteFaktura(idDocument);
                                }
                                catch (MySqlException ex)
                                {


                                    if (ex.Number == 1451)
                                        MessageBox.Show("Не може да изтриете запис , който се използва");
                                    //throw ex;
                                    int errorcode = ex.Number;
                                    MessageBox.Show(errorcode.ToString());

                                }

                                DialogHost.Show("Запазихте промените");
                                DialogResult = true;
                                this.Close();



                            }
                            else if (Result == MessageBoxResult.No)
                            {
                                Environment.Exit(0);
                            }






                           
                        }
                        else
                        {
                            sql.editDocument(idedit, userid, date, documentNumber, contragent, documentType);
                            sql.editDocDetailsList(idDocument, editList);
                            /*if (textBoxBruto.Text != "" && textBoxNeto.Text != "")
                            {
                                bruto = Convert.ToDecimal(textBoxBruto.Text.ToString());
                                neto = Convert.ToDecimal(textBoxNeto.Text.ToString());
                            }*/
                            DialogResult = true;
                            this.Close();
                        }
                        //int document = 0;
                        //int document
                        //if (textboxbruto.text == "" || textboxneto.text == "" || textboxquantity.text == "")
                        //{
                        //    messagebox.show("попълнете всички полета");
                        //}
                        //else
                        //{
                    }

                    //frm.Show();
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClassDocumentDetails doc = new ClassDocumentDetails();

            AddEditDocDetails addEditDocDetails = new AddEditDocDetails(0);
            addEditDocDetails.ShowDialog();
            if (addEditDocDetails.DialogResult.HasValue && addEditDocDetails.DialogResult.Value)
            {
                //obek s danni ot doc details dialoga
                doc = Singletone.classDoc;


                //proverka za redakciq ili dobavqne
                if (mode == 0)
                {

                    //ako ima elementi v spisuka
                    if (list.Count.Equals(0))
                    {   //ako spisuka e prazen
                        doc.editnumber = editnumber;
                        list.Add(doc);

                    }
                    else
                    {       //ako ima elementi v spisuka
                        for (int i = 0; i < list.Count; i++)
                        {      //ako se povtarq konsumativa se subirat cenite i kolichestvoto
                            if (list[i].consumable == doc.consumable)
                            {
                                list[i].quantity += doc.quantity;
                                list[i].bruto += doc.bruto;
                                list[i].neto += doc.neto;
                                //list = buffList;
                                flag = false;

                                break;

                            }
                            else
                            {   //ako ne se povtarqt a e nov konsumativ
                                flag = true;

                            }

                        }
                        if (flag == true)
                        {       //dobavq se noviq konsumativ
                            editnumber++;
                            doc.editnumber = editnumber;
                            list.Add(doc);
                            flag = false;

                        }

                    }
                    //dannite se populvat vuv tablicata
                    //dataGridView1.Refresh();
                    /*BindingList<ClassDocumentDetails> bd = new BindingList<ClassDocumentDetails>(list);
                    //BindingSource bs = new BindingSource(bd, null);
                    //datagrid.ItemsSource = list;

                    BindingListCollectionView bdv = new BindingListCollectionView(bd);
                    datagrid.ItemsSource = bdv;*/

                    
                    itemCollectionViewSource.Source = list;
                    itemCollectionViewSource.View.MoveCurrentToFirst();
                    itemCollectionViewSource.View.Refresh();




                    datagrid.Columns[4].Visibility = Visibility.Hidden;
                    datagrid.Columns[5].Visibility = Visibility.Hidden;
                    datagrid.Columns[6].Visibility = Visibility.Hidden;
                    datagrid.Columns[0].Header = "Стока";
                    datagrid.Columns[2].Header = "Цена без ДДС";
                    datagrid.Columns[3].Header = "Цена с ДДС";
                    datagrid.Columns[1].Header = "Количество";



                    datagrid.Columns[0].Width = 150;
                    datagrid.Columns[1].Width = 150;
                    datagrid.Columns[2].Width = 150;
                    datagrid.Columns[3].Width = 150;

                    /*datagrid.Items.Refresh();
                    datagrid.Columns[0].Header = "Стока";
                    datagrid.Columns[2].Header = "Цена без ДДС";
                    datagrid.Columns[3].Header = "Цена с ДДС";
                    datagrid.Columns[1].Header = "Количество";
                    datagrid.Items.Refresh();*/

                }
                else if (mode == 1)
                {//redaktirane 
                    if (editList.Count.Equals(0))
                    {       //ako doc details e ot bazata danni
                        if (doc.id > 0)
                        {
                            doc.editnumber = editnumber;
                            editList.Add(doc);
                        }
                        else
                        {   //ako e bil t.e ne e ot bazata danni
                            // 0 znachi che ne e zapisan v bazata ot danni
                            doc.id = 0;
                            editList.Add(doc);

                        }

                        /* BindingList<ClassDocumentDetails> bd = new BindingList<ClassDocumentDetails>(editList);
                         BindingSource bs = new BindingSource(bd, null);
                         dataGridView1.DataSource = bs;
                         dataGridView1.Refresh();*/
                        itemCollectionViewSource.Source = editList;
                        itemCollectionViewSource.View.MoveCurrentToFirst();
                        itemCollectionViewSource.View.Refresh();


                        datagrid.Columns[4].Visibility = Visibility.Hidden;
                        datagrid.Columns[5].Visibility = Visibility.Hidden;
                        datagrid.Columns[6].Visibility = Visibility.Hidden;
                        datagrid.Columns[0].Header = "Стока";
                        datagrid.Columns[2].Header = "Цена без ДДС";
                        datagrid.Columns[3].Header = "Цена с ДДС";
                        datagrid.Columns[1].Header = "Количество";



                        datagrid.Columns[0].Width = 150;
                        datagrid.Columns[1].Width = 150;
                        datagrid.Columns[2].Width = 150;
                        datagrid.Columns[3].Width = 150;
                    }
                    else
                    {
                        for (int i = 0; i < editList.Count; i++)
                        {
                            if (editList[i].consumable == doc.consumable)
                            {

                                editList[i].quantity += doc.quantity;
                                editList[i].bruto += doc.bruto;
                                editList[i].neto += doc.neto;
                                //editList[i].id = 0;
                                //list = buffList;
                                flag = false;
                                break;

                            }
                            else
                            {
                                flag = true;

                            }

                        }
                        if (flag == true)
                        {
                            editnumber++;
                            doc.editnumber = editnumber;
                            editList.Add(doc);
                            flag = false;
                            //dataGridView1.Refresh();

                        }

                        /*BindingList<ClassDocumentDetails> bd = new BindingList<ClassDocumentDetails>(editList);
                        BindingSource bs = new BindingSource(bd, null);
                        dataGridView1.DataSource = bs;*/
                        itemCollectionViewSource.Source = editList;
                        itemCollectionViewSource.View.MoveCurrentToFirst();
                        itemCollectionViewSource.View.Refresh();


                        datagrid.Columns[4].Visibility = Visibility.Hidden;
                        datagrid.Columns[5].Visibility = Visibility.Hidden;
                        datagrid.Columns[6].Visibility = Visibility.Hidden;
                        datagrid.Columns[0].Header = "Стока";
                        datagrid.Columns[2].Header = "Цена без ДДС";
                        datagrid.Columns[3].Header = "Цена с ДДС";
                        datagrid.Columns[1].Header = "Количество";



                        datagrid.Columns[0].Width = 150;
                        datagrid.Columns[1].Width = 150;
                        datagrid.Columns[2].Width = 150;
                        datagrid.Columns[3].Width = 150;

                    }
                    //dataGridView1.Refresh();







                }




            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*datagrid.Columns["Consumable"].Visible = false;
            datagrid.Columns["editnumber"].Visible = false;
            dataGridView1.Columns["id"].Visible = false;*/
            
            if (mode == 0)
            {

                //button4.Visible = false;
                //this.Text = "Добавяне на документ";
                datePicker.SelectedDate = DateTime.Now.Date;
                this.Title = "Добавяне на документ";

                //zarejdane na tablicata 
                DataTable dt = new DataTable();


                list = (from DataRow dr in dt.Rows
                        select new ClassDocumentDetails()
                        {
                            id = Convert.ToInt32(dr["idDetails"]),
                            userConsumable = dr["name"].ToString(),
                            quantity = Convert.ToDecimal(dr["quantity"]),
                            bruto = Convert.ToDecimal(dr["price"]),
                            neto = Convert.ToDecimal(dr["priceDDS"]),


                            consumable = Convert.ToInt32(dr["Consumables_idConsumables"]
                            )

                        }
                                  ).ToList();




                /* BindingList<ClassDocumentDetails> bd = new BindingList<ClassDocumentDetails>(editList);
                 //BindingSource bs = new BindingSource(bd, null);
                 BindingListCollectionView bdv = new BindingListCollectionView(bd);
                 datagrid.ItemsSource = bdv;*/





                /* dataGridView1.Columns["Consumable"].Visible = false;
                 dataGridView1.Columns["editnumber"].Visible = false;
                 dataGridView1.Columns["id"].Visible = false;*/


                itemCollectionViewSource.Source = list;
                itemCollectionViewSource.View.MoveCurrentToFirst();
                itemCollectionViewSource.View.Refresh();


                datagrid.Columns[4].Visibility = Visibility.Hidden;
                datagrid.Columns[5].Visibility = Visibility.Hidden;
                datagrid.Columns[6].Visibility = Visibility.Hidden;
                datagrid.Columns[0].Header = "Стока";
                datagrid.Columns[2].Header = "Цена без ДДС";
                datagrid.Columns[3].Header = "Цена с ДДС";
                datagrid.Columns[1].Header = "Количество";



                datagrid.Columns[0].Width = 150;
                datagrid.Columns[1].Width = 150;
                datagrid.Columns[2].Width = 150;
                datagrid.Columns[3].Width = 150;





            }
            if (mode == 1)
            {
                datePicker.SelectedDate = DateTime.Parse(date);
                textBoxNomer.Text = nomer.ToString();


               
                    //button2.Visible = false;
               using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
               {
                        string sql = "SELECT idDetails , price , priceDDS ,Documents_idDocuments,Consumables_idConsumables , quantity,idConsumables,consumables.`name` from docdetails join consumables on docdetails.Consumables_idConsumables=consumables.idConsumables Where Documents_idDocuments = @idDocument";
                        MySqlCommand comand = new MySqlCommand(sql, mysqlCon); ;
                        comand.Parameters.Clear();
                        comand.Parameters.AddWithValue("@idDocument", idDocument);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(comand);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);


                    

                        editList = (from DataRow dr in dt.Rows
                                    select new ClassDocumentDetails()
                                    {
                                        id = Convert.ToInt32(dr["idDetails"]),
                                        bruto = Convert.ToDecimal(dr["price"]),
                                        neto = Convert.ToDecimal(dr["priceDDS"]),
                                        quantity = Convert.ToDecimal(dr["quantity"]),
                                        userConsumable = dr["name"].ToString(),
                                        consumable = Convert.ToInt32(dr["Consumables_idConsumables"]
                                        )

                                    }
                                       ).ToList();
                    itemCollectionViewSource.Source = editList;
                    itemCollectionViewSource.View.MoveCurrentToFirst();
                    itemCollectionViewSource.View.Refresh();

                    datagrid.Columns[4].Visibility = Visibility.Hidden;
                    datagrid.Columns[5].Visibility = Visibility.Hidden;
                    datagrid.Columns[6].Visibility = Visibility.Hidden;
                    datagrid.Columns[0].Header = "Стока";
                    datagrid.Columns[2].Header = "Цена без ДДС";
                    datagrid.Columns[3].Header = "Цена с ДДС";
                    datagrid.Columns[1].Header = "Количество";



                    datagrid.Columns[0].Width = 150;
                    datagrid.Columns[1].Width = 150;
                    datagrid.Columns[2].Width = 150;
                    datagrid.Columns[3].Width = 150;

                    /* dataGridView1.Columns[0].HeaderText = "Бруто";
                     dataGridView1.Columns[1].HeaderText = "Нето";
                     dataGridView1.Columns[2].HeaderText = "Количество";
                     dataGridView1.Columns[4].HeaderText = "Стока";*/






                }
                

            }




            DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            // Load data into the table contractors. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.contractorsTableAdapter dataSet1contractorsTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.contractorsTableAdapter();
            dataSet1contractorsTableAdapter.Fill(dataSet1.contractors);
            System.Windows.Data.CollectionViewSource contractorsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contractorsViewSource")));
            contractorsViewSource.View.MoveCurrentToFirst();
            // Load data into the table doctype. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.doctypeTableAdapter dataSet1doctypeTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.doctypeTableAdapter();
            dataSet1doctypeTableAdapter.Fill(dataSet1.doctype);
            System.Windows.Data.CollectionViewSource doctypeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("doctypeViewSource")));
            doctypeViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            dynamic row = datagrid.SelectedItem;
            if (row == null)
            {
                MessageBox.Show("Izberete element za redaktirane");
                
            }
            else
            {

                

                ClassDocumentDetails buff = new ClassDocumentDetails();
                ideditConsumable = Convert.ToInt32(row.id);
                Decimal Buffbruto = Convert.ToDecimal(row.bruto);
                Decimal Buffneto = Convert.ToDecimal(row.neto);
                Decimal Buffquantity = Convert.ToDecimal(row.quantity);
                int Buffconsumable = Convert.ToInt32(row.consumable);
                int Buffeditnumber = Convert.ToInt32(row.editnumber);
                buff.bruto = Buffbruto;
                buff.neto = Buffneto;
                buff.id = ideditConsumable;
                buff.quantity = Buffquantity;
                buff.consumable = Buffconsumable;

                ClassDocumentDetails doc = new ClassDocumentDetails();
                int idEdit = Convert.ToInt32(row.id);
                decimal bruto = Convert.ToDecimal(row.bruto);
                decimal neto = Convert.ToDecimal(row.neto);
                decimal quantity = Convert.ToDecimal(row.quantity);
                AddEditDocDetails addEditDocDetails = new AddEditDocDetails(1, idEdit, Buffconsumable, Buffbruto, Buffneto, Buffquantity, Buffeditnumber);

                addEditDocDetails.ShowDialog();
                if (addEditDocDetails.DialogResult.HasValue && addEditDocDetails.DialogResult.Value)
                {

                    doc = Singletone.classDoc;
                    itemCollectionViewSource.Source = editList;
                    itemCollectionViewSource.View.MoveCurrentToFirst();
                    itemCollectionViewSource.View.Refresh();
                    //datagrid.ItemsSource = editList;

                    if (mode == 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].consumable == doc.consumable && list[i].consumable != buff.consumable)
                            {


                                list[i].quantity += doc.quantity;
                                list[i].bruto += doc.bruto;
                                list[i].neto += doc.neto;
                                //list = buffList;
                                flag = false;

                                //editList.RemoveAll(x => x.consumable == buff.consumable&&x.id==buff.id&&x.neto==buff.neto);

                                list.RemoveAll(x => x.consumable == buff.consumable);
                                if (buff.id == 0)
                                {

                                }
                                else if (buff.id > 0)
                                {
                                    try
                                    {
                                        sql.deleteDocDetails(buff.id);
                                        list.RemoveAll(x => x.consumable == buff.consumable && x.id == buff.id && x.neto == buff.neto);
                                    }
                                    catch (MySqlException ex)
                                    {

                                        //log.Log(ex.ToString());
                                        //MessageBox.Show(ex.ToString());
                                        if (ex.Number == 1451)
                                        {

                                            var Result = MessageBox.Show("Елемента на документа който се опитвате да промените е вече разпределен на МПС , ако го промените разпределението ще отпадне! Желаете ли да продължите", "Vnimanie", MessageBoxButton.YesNo, MessageBoxImage.Question);

                                            if (Result == MessageBoxResult.Yes)
                                            {

                                                sql.deleteConsumbaleBycarBYDOCDETAILSID(buff.id);


                                                sql.deleteDocDetails(buff.id);
                                                list.RemoveAll(x => x.consumable == buff.consumable && x.id == buff.id && x.neto == buff.neto);



                                            }
                                            else if (Result == MessageBoxResult.No)
                                            {
                                                list[i].quantity -= doc.quantity;
                                                list[i].bruto -= doc.bruto;
                                                list[i].neto -= doc.neto;
                                                this.Close();
                                                
                                            }




                                            
                                        }
                                        //throw ex;
                                        //editList[i].quantity -= doc.quantity;
                                        //editList[i].bruto -= doc.bruto;

                                        //editList[i].neto -= doc.neto;


                                    }



                                }




                                break;

                            }
                            else
                            {
                                flag = true;

                            }

                        }
                        if (flag == true)
                        {
                            foreach (ClassDocumentDetails c in list)
                            {
                                if (c.editnumber == doc.editnumber)
                                {
                                    c.bruto = doc.bruto;
                                    c.neto = doc.neto;
                                    c.quantity = doc.quantity;
                                    c.consumable = doc.consumable;
                                    c.userConsumable = doc.userConsumable;
                                }

                            }
                            flag = false;

                        }

                        /*BindingList<ClassDocumentDetails> bds = new BindingList<ClassDocumentDetails>(list);
                        BindingSource bss = new BindingSource(bds, null);*/
                        itemCollectionViewSource.Source = list;
                        itemCollectionViewSource.View.MoveCurrentToFirst();
                        itemCollectionViewSource.View.Refresh();
                        datagrid.Columns[4].Visibility = Visibility.Hidden;
                        datagrid.Columns[5].Visibility = Visibility.Hidden;
                        datagrid.Columns[6].Visibility = Visibility.Hidden;
                        datagrid.Columns[0].Header = "Стока";
                        datagrid.Columns[2].Header = "Цена без ДДС";
                        datagrid.Columns[3].Header = "Цена с ДДС";
                        datagrid.Columns[1].Header = "Количество";



                        datagrid.Columns[0].Width = 150;
                        datagrid.Columns[1].Width = 150;
                        datagrid.Columns[2].Width = 150;
                        datagrid.Columns[3].Width = 150;
                    }
                    else if (mode == 1)
                    {


                        for (int i = 0; i < editList.Count; i++)
                        {
                            if (editList[i].consumable == doc.consumable && editList[i].consumable != buff.consumable)
                            {
                                editList[i].quantity += doc.quantity;
                                editList[i].bruto += doc.bruto;
                                editList[i].neto += doc.neto;
                                //list = buffList;
                                flag = false;

                                //editList.RemoveAll(x => x.consumable == buff.consumable&&x.id==buff.id&&x.neto==buff.neto);


                                if (buff.id == 0)
                                {
                                    editList.RemoveAll(x => x.consumable == buff.consumable && x.id == buff.id && x.neto == buff.neto);
                                }
                                else if (buff.id > 0)
                                {
                                    try
                                    {
                                        sql.deleteDocDetails(buff.id);
                                        editList.RemoveAll(x => x.consumable == buff.consumable && x.id == buff.id && x.neto == buff.neto);
                                    }
                                    catch (MySqlException ex)
                                    {

                                        //log.Log(ex.ToString());
                                        //MessageBox.Show(ex.ToString());
                                        if (ex.Number == 1451)
                                        {
                                            var Result = MessageBox.Show("Елемента на документа който се опитвате да промените е вече разпределен на МПС , ако го промените разпределението ще отпадне! Желаете ли да продължите", "Vnimanie", MessageBoxButton.YesNo, MessageBoxImage.Question);

                                            if (Result == MessageBoxResult.Yes)
                                            {
                                                MessageBox.Show(buff.id.ToString());
                                                sql.deleteConsumbaleBycarBYDOCDETAILSID(buff.id);





                                                sql.deleteDocDetails(buff.id);
                                                editList.RemoveAll(x => x.consumable == buff.consumable && x.id == buff.id && x.neto == buff.neto);
                                                //????? 
                                                sql.editDocDetailsList(idDocument, editList);
                                                //tuk
                                            }
                                            else if (Result == MessageBoxResult.No)
                                            {
                                                editList[i].quantity -= doc.quantity;
                                                editList[i].bruto -= doc.bruto;
                                                editList[i].neto -= doc.neto;
                                                this.Close();
                                            }
                                        }
                                        //throw ex;
                                        //editList[i].quantity -= doc.quantity;
                                        //editList[i].bruto -= doc.bruto;

                                        //editList[i].neto -= doc.neto;


                                    }



                                }




                                break;

                            }
                            else
                            {
                                flag = true;

                            }

                        }
                        if (flag == true)
                        {
                            foreach (ClassDocumentDetails c in editList)
                            {
                                if (doc.id != 0)
                                {

                                    if (c.id == doc.id)
                                    {
                                        if (sql.CheckIfConsumableIsUsed(doc.id) == true)
                                        {

                                            


                                            var Result = MessageBox.Show("Ако промените стоката разпределението ще бъде изтрито ! ", "Vnimanie", MessageBoxButton.YesNo, MessageBoxImage.Question);

                                            if (Result == MessageBoxResult.Yes)
                                            {

                                                sql.deleteConsumbaleBycarBYDOCDETAILSID(doc.id);
                                            }




                                        }
                                        else
                                        {
                                            c.bruto = doc.bruto;
                                            c.neto = doc.neto;
                                            c.quantity = doc.quantity;
                                            c.consumable = doc.consumable;
                                            c.userConsumable = doc.userConsumable;
                                        }

                                    }
                                    sql.editDocDetailsList(idDocument, editList);
                                }
                                else if (doc.id == 0)
                                {
                                    if (c.editnumber == doc.editnumber)
                                    {
                                        c.bruto = doc.bruto;
                                        c.neto = doc.neto;
                                        c.quantity = doc.quantity;
                                        c.consumable = doc.consumable;
                                        c.userConsumable = doc.userConsumable;
                                    }
                                }


                            }
                            flag = false;

                        }
                        /*BindingList<ClassDocumentDetails> bd = new BindingList<ClassDocumentDetails>(editList);
                        BindingSource bs = new BindingSource(bd, null);*/
                        itemCollectionViewSource.Source = editList;
                        itemCollectionViewSource.View.MoveCurrentToFirst();
                        itemCollectionViewSource.View.Refresh();
                        datagrid.Columns[4].Visibility = Visibility.Hidden;
                        datagrid.Columns[5].Visibility = Visibility.Hidden;
                        datagrid.Columns[6].Visibility = Visibility.Hidden;
                        datagrid.Columns[0].Header = "Стока";
                        datagrid.Columns[2].Header = "Цена без ДДС";
                        datagrid.Columns[3].Header = "Цена с ДДС";
                        datagrid.Columns[1].Header = "Количество";



                        datagrid.Columns[0].Width = 150;
                        datagrid.Columns[1].Width = 150;
                        datagrid.Columns[2].Width = 150;
                        datagrid.Columns[3].Width = 150;

                    }




                }


            }

            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dynamic row = datagrid.SelectedItem;
            if (row == null)
            {
                MessageBox.Show("Izberete element za redaktirane");

            }
            else
            {
                //int deleteid = Convert.ToInt32(dataGridViewContragent.SelectedRows[0].Cells["idConsumablesDataGridViewTextBoxColumn"].Value.ToString());
                //ideditConsumable = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
                ideditConsumable = Convert.ToInt32(row.id);
                int consumable = Convert.ToInt32(row.consumable);

                //int consumable = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());


                
                var Result = MessageBox.Show("Сигурни ли сте че искате да изтриете избрания запис ?", " Изтриване на запис",  MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (Result == MessageBoxResult.Yes)
                {
                    if (ideditConsumable == 0)
                    {
                        if (mode == 0)
                        {
                            list.RemoveAll(x => x.consumable == consumable);
                            sql.editDocDetailsList(idDocument, list);

                            itemCollectionViewSource.Source = list;
                            itemCollectionViewSource.View.MoveCurrentToFirst();
                            itemCollectionViewSource.View.Refresh();
                        }
                        else if (mode == 1)
                        {
                            // foreach (ClassDocumentDetails cd in editList)
                            //{
                            //if (cd.id == ideditConsumable)
                            //{
                            editList.RemoveAll(x => x.consumable == consumable);
                            sql.editDocDetailsList(idDocument, editList);
                            //}
                            //}

                            itemCollectionViewSource.Source = editList;
                            itemCollectionViewSource.View.MoveCurrentToFirst();
                            itemCollectionViewSource.View.Refresh();
                        }

                    }
                    else
                    {


                        try
                        {
                            using (MySqlConnection mysqlCon = new MySqlConnection(Properties.Settings.Default.Connection))
                            {
                                mysqlCon.Open();
                                MySqlCommand mySqlCmd = new MySqlCommand("deleteDocDetails", mysqlCon);
                                mySqlCmd.CommandType = CommandType.StoredProcedure;
                                mySqlCmd.Parameters.AddWithValue("_idDelete", ideditConsumable);

                                mySqlCmd.ExecuteNonQuery();

                                if (mode == 0)
                                {
                                    list.RemoveAll(x => x.id == ideditConsumable);
                                    sql.editDocDetailsList(idDocument, list);

                                    itemCollectionViewSource.Source = list;
                                    itemCollectionViewSource.View.MoveCurrentToFirst();
                                    itemCollectionViewSource.View.Refresh();
                                }
                                else if (mode == 1)
                                {
                                    // foreach (ClassDocumentDetails cd in editList)
                                    //{
                                    //if (cd.id == ideditConsumable)
                                    //{
                                    editList.RemoveAll(x => x.id == ideditConsumable);
                                    sql.editDocDetailsList(idDocument, editList);
                                    //}
                                    //}

                                    itemCollectionViewSource.Source = editList;
                                    itemCollectionViewSource.View.MoveCurrentToFirst();
                                    itemCollectionViewSource.View.Refresh();
                                }

                            }
                            //dataGridView1.Refresh();

                        }
                        catch (MySqlException ex)
                        {

                            //log.Log(ex.ToString());
                            //MessageBox.Show(ex.ToString());
                            if (ex.Number == 1451)
                                MessageBox.Show("Не може да изтриете запис , който се използва");
                            //throw ex;


                        }
                    }


                }
                
            }
        }

        private void textBoxNomer_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
              e.Key == Key.Delete || e.Key == Key.Back || e.Key == Key.Left || e.Key == Key.Right )
            {
                //Pressed Alt, ctrl, shift and other modifier keys
                if (e.KeyboardDevice.Modifiers != ModifierKeys.None)
                {
                    e.Handled = true;
                }
                else
                {
                    //return true;
                }

            }
            else//Press other function keys such as characters
            {
                e.Handled = true;
            }
        }
    }
}

