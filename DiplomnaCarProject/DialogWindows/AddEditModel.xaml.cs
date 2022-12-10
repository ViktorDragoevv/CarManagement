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
    /// Interaction logic for AddEditModel.xaml
    /// </summary>
    public partial class AddEditModel : Window
    {
        SQL sql = new SQL();
        private int mode;
        private string modelName;
        private int idedit;
        int brand ;
        public AddEditModel(int mode, int brand=0, string modelName="", int idedit=0)
        {
            InitializeComponent();
            this.mode = mode;
            this.brand = brand;
            this.modelName = modelName;
            this.idedit = idedit;


            if (mode == 1)
            {
                b1.Content = "Редактирай";
                this.Title = "Редактиране на модел";
                textBoxModel.Text = modelName;
                cb.SelectedValue = brand;
            }
            else if (mode == 0)
            {
                b1.Content = "Добави";
                this.Title = "Добавяне на модел";
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            // Load data into the table BrandView. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.BrandViewTableAdapter dataSet1BrandViewTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.BrandViewTableAdapter();
            dataSet1BrandViewTableAdapter.Fill(dataSet1.BrandView);
            System.Windows.Data.CollectionViewSource brandViewViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("brandViewViewSource")));
            brandViewViewSource.View.MoveCurrentToFirst();
            cb.SelectedValue = brand;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (mode == 0)
            {
                if (textBoxModel.Text == "")
                {

                }
                else
                {   
                    sql.addModel(int.Parse(cb.SelectedValue.ToString()), textBoxModel.Text.ToString());
                    DialogResult = true;
                    this.Close();

                }

            }
            else if (mode == 1)
            {
                if (textBoxModel.Text == "")
                {

                }
                else
                {
                   
                    sql.editModel(idedit, int.Parse(cb.SelectedValue.ToString()), textBoxModel.Text.ToString());
                    DialogResult = true;
                    this.Close();

                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
