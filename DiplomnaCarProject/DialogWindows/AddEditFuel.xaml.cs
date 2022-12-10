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
    /// Interaction logic for AddEditFuel.xaml
    /// </summary>
    public partial class AddEditFuel : Window
    {
        private int mode;
        private string name;
        private int idedit;
        SQL sql = new SQL();

        public AddEditFuel(int mode, int idedit = 0, string name = "")
        {
            InitializeComponent();
            this.mode = mode;
            this.idedit = idedit;
            this.name = name;
            
            if (mode == 1)
            {
                b1.Content = "Редактирай";
                this.Title = "Редактиране на тип гориво";
                textBoxFuel.Text = name;
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
                if (textBoxFuel.Text == "")
                {

                }
                else
                {
                    sql.addFuel(textBoxFuel.Text.ToString());
                    DialogResult = true;
                    this.Close();

                }

            }
            else if (mode == 1)
            {
                if (textBoxFuel.Text == "")
                {

                }
                else
                {
                    sql.editFuel(idedit, textBoxFuel.Text.ToString());
                    DialogResult = true;
                    this.Close();

                }
            }
        }
    }
}
