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
    /// Interaction logic for AddEditType.xaml
    /// </summary>
    public partial class AddEditType : Window
    {
        private int mode;
        private string name;
        private int idedit;
        SQL sql = new SQL();

        public AddEditType(int mode, int idedit = 0, string name = "")
        {
            InitializeComponent();

            this.mode = mode;
            this.idedit = idedit;
            this.name = name;


            if (mode == 1)
            {
                b1.Content = "Редактирай";
                this.Title = "Редактиране на тип консуматив";
                textBoxType.Text = name;
            }
            else if (mode == 0)
            {
                b1.Content = "Добави";
                this.Title = "Добавяне на тип консуматив";
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
                    sql.addType(textBoxType.Text.ToString());
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
                    sql.editType(idedit, textBoxType.Text.ToString());
                    DialogResult = true;
                    this.Close();

                }
            }
        }
    }
}
