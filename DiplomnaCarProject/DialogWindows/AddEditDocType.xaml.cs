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
    /// Interaction logic for AddEditDocType.xaml
    /// </summary>
    public partial class AddEditDocType : Window
    {
        private int mode;
        private string name;
        private int idedit;
        SQL sql = new SQL();
        public AddEditDocType(int mode, int idedit = 0, string name = "")
        {
            InitializeComponent();

            this.mode = mode;
            this.idedit = idedit;
            this.name = name;


            if (mode == 1)
            {
                b1.Content = "Редактирай";
                this.Title = "Редактиране на вид докумет";
                textBoxType.Text = name;
            }
            else if (mode == 0)
            {
                b1.Content = "Добави";
                this.Title = "Добавяне на вид документ";
            }

        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            if (mode == 0)
            {
                if (textBoxType.Text == "")
                {

                }
                else
                {
                    sql.addDocType(textBoxType.Text.ToString());
                    DialogResult = true;
                    this.Close();

                }

            }
            else if (mode == 1)
            {
                if (textBoxType.Text == "")
                {

                }
                else
                {
                    sql.editDocType(idedit, textBoxType.Text.ToString());
                    DialogResult = true;
                    this.Close();

                }
            }
        }
    }
}
