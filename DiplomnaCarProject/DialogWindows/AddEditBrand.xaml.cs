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

namespace DiplomnaCarProject
{
    /// <summary>
    /// Interaction logic for AddEditBrand.xaml
    /// </summary>
    public partial class AddEditBrand : Window
    {
        private int mode;
        private string name;
        private int idedit;
        SQL sql = new SQL();
        public AddEditBrand(int id, int idedit = 0 , string name ="")
        {
            InitializeComponent();
            this.mode = id;
            this.idedit = idedit;
            this.name = name;
            

            if (mode == 1)
            {
                b1.Content = "Редактирай";
                this.Title = "Редактиране на марка";
                textBoxBrand.Text = name;
            }
            else if(mode==0)
            {
                b1.Content = "Добави";
                this.Title = "Добавяне на марка";
            }

            //cb.DataContext = DataSet1.BrandViewDataTable();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mode == 0)
            {
                if (textBoxBrand.Text == "")
                {
                    
                }
                else
                {
                    sql.addBrand(textBoxBrand.Text.ToString());
                    DialogResult = true;
                    this.Close();
                    
                }
               
            }
            else if (mode == 1)
            {
                if (textBoxBrand.Text == "")
                {

                }
                else
                {
                    sql.editBrand(idedit,textBoxBrand.Text.ToString());
                    DialogResult = true;
                    this.Close();

                }
            }
        }
    }
}
