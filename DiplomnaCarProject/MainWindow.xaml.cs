using DiplomnaCarProject.View_Page;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiplomnaCarProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_BrandView(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new BrandView();
        }

        private void MenuItem_ModelView(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ModelViewPage();
        }

        private void MenuItem_Fuel(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new FuelView();
        }

        private void MenuItem_Car(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CarView();
        }
        private void MenuItem_Measure(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MeasuresView();
        }
        private void MenuItem_Type(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new TypeView();
        }
        private void MenuItem_Consumable(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ConsumableView();
        }
        private void MenuItem_Contragent(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ContragentView();
        }
        private void MenuItem_Document(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DocumentView();
        }
        private void MenuItem_D(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new testWindow();
        }
    }
}
