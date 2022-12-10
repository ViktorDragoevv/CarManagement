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
    /// Interaction logic for AddEditPeople.xaml
    /// </summary>
    public partial class AddEditPeople : Window
    {
        private int mode;
        private string name;
        private string mail;
        private int idedit;
        SQL sql = new SQL();

        public AddEditPeople(int mode, int idedit = 0, string name = "" , string mail = "")
        {
            InitializeComponent();
            this.mode = mode;
            this.idedit = idedit;
            this.name = name;
            this.mail = mail;


            if (mode == 1)
            {
                b1.Content = "Редактирай";
                this.Title = "Редактиране на тип гориво";
                textBoxName.Text = name;
                textBoxMail.Text = mail;
            }
            else if (mode == 0)
            {
                b1.Content = "Добави";
                this.Title = "Добавяне на тип гориво ";
            }
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            if (mode == 0)
            {
                if (textBoxName.Text == "" && textBoxMail.Text=="")
                {
                    MessageBox.Show("Populnete poletata ! ");
                }
                else
                {
                    sql.addPeople(textBoxName.Text.ToString(),textBoxMail.Text.ToString());
                    DialogResult = true;
                    this.Close();

                }

            }
            else if (mode == 1)
            {
                if (textBoxName.Text == "" && textBoxMail.Text == "")
                {
                    MessageBox.Show("Populnete poletata ! ");
                }
                else
                {
                    sql.editPeople(idedit, textBoxName.Text.ToString(),textBoxMail.Text.ToString());

                    DialogResult = true;
                    this.Close();

                }
            }
        }
    }
}
