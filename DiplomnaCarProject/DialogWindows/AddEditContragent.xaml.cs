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
    /// Interaction logic for AddEditContragent.xaml
    /// </summary>
    public partial class AddEditContragent : Window
    {
        private int mode;
        private string EIK;
        private string name;
        private string city;
        private string address;
        private string DDS;
        private string MOL;
        private int idedit;
        SQL sql = new SQL();
        public List<int> list = new List<int>();
        AddEditOfferedConsumable addEditOfferedConsumable = new AddEditOfferedConsumable();
        public AddEditContragent(int mode , string EIK ="",string name ="" , string city = "" ,string address ="" ,string DDS = "" ,string MOL = "", int idedit=0 )
        {
            InitializeComponent();

            this.mode = mode;
            this.EIK = EIK;
            this.name = name;
            this.city = city;
            this.address = address;
            this.DDS = DDS;
            this.MOL = MOL;
            this.idedit = idedit;
            


            if (mode == 1)
            {
                b1.Content = "Редактирай";
                this.Title = "Редактиране на контрагент";
                
                textBoxEIK.Text = EIK;
                textBoxName.Text = name;
                textBoxCity.Text = city;
                textBoxAddress.Text = address;
                textBoxDDS.Text = DDS;
                textBoxMOL.Text = MOL;

            }
            else if (mode == 0)
            {
                b1.Content = "Добави";
                this.Title = "Добавяне на контрагент";
            }
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            if (mode == 0)
            {
                if (textBoxName.Text == "")
                {
                    MessageBox.Show("Моля въведете име !");
                }
                else 
                {
                    if (sql.ContractorNameCheck(textBoxName.Text) == true)
                    {
                        MessageBox.Show("Съществува контрагент с това име !");
                    }
                    else if(sql.ContractorEIKCheck(textBoxEIK.Text)==true)
                    {
                        MessageBox.Show("Съществува контрагент с това ЕИК !");
                    }
                    else
                    {
                        //int idLastContragent;
                        sql.addContragent(textBoxEIK.Text.ToString(),textBoxName.Text.ToString(),textBoxCity.Text.ToString(),textBoxAddress.Text.ToString(),textBoxDDS.Text.ToString(),textBoxMOL.Text.ToString());
                        //idLastContragent = sql.GetMaxContragentID();
                        /*list = addEditOfferedConsumable.offeredConsumablesIDList;
                        foreach (var consumableID in list)
                        {
                            sql.AddOfferedConsumable(idLastContragent, consumableID);
                        }*/
                        DialogResult = true;
                        this.Close();
                    }
                    
                    

                }

            }
            else if (mode == 1)
            {
                if (sql.ContractorNameCheck(textBoxName.Text) == true && textBoxName.Text != name)
                {
                    MessageBox.Show("Съществува контрагент с това име !");
                }
                else if (sql.ContractorEIKCheck(textBoxEIK.Text) == true && textBoxEIK.Text != EIK)
                {
                    MessageBox.Show("Съществува контрагент с това ЕИК !");
                }
                else
                {
                    //int idLastContragent;
                    sql.editContragent(idedit,textBoxEIK.Text.ToString(), textBoxName.Text.ToString(), textBoxCity.Text.ToString(), textBoxAddress.Text.ToString(), textBoxDDS.Text.ToString(), textBoxMOL.Text.ToString());
                    //idLastContragent = sql.GetMaxContragentID();
                    /*list = addEditOfferedConsumable.offeredConsumablesIDList;
                    foreach (var consumableID in list)
                    {
                        sql.AddOfferedConsumable(idLastContragent, consumableID);
                    }*/
                    DialogResult = true;
                    this.Close();
                }
            }
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            
            addEditOfferedConsumable.ShowDialog();
        }
    }
}
