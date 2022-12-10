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
using System.Windows.Shapes;


namespace DiplomnaCarProject
{
    /// <summary>
    /// Interaction logic for navigation.xaml
    /// </summary>
    public partial class navigation : Window
    {
        CarView carView;
        BrandView brandView;
        DocumentView documentView;
        ModelViewPage modelView;
        ConsumableView consumableView;
        ContragentView contragentView;
        FuelView fuelView;
        MeasuresView measuresView;
        TypeView typeView;
        DocTypeView docTypeView;
        HomePageNotificationView homePageNotificationView;
        ConsumableByCarView consumableByCarView;
        SpravkaCarSum spravkaCarSum;
        SpravkaDocConsumables spravkaDocConsumables;
        SpravkaDocDetails spravkaDocDetails;
        Login2 login;

        bool menu = false;
        bool menu2 = false;
        bool menu3 = false;
        public navigation(Login2 login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            //GridMain.Children.Clear();
           
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    //usc = new CarView();
                    GridMain.Content = new CarView();
                    ButtonCloseMenu_Click(sender, e);
                    
                    break;
                case "ItemCreate":
                    /*usc = new UserControlCreate();
                    GridMain.Children.Add(usc);
                    break;*/
                default:
                    break;
            }


            

        }

      

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

       

        private void BTN_CAR(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void CarView(object sender, RoutedEventArgs e)
        {
            if (carView == null)
            {
                carView = new CarView();
            }
            
                GridMain.Content = carView;
            
            
        }

        private void BrandView(object sender, RoutedEventArgs e)
        {
            if (brandView == null)
            {
                brandView = new BrandView(); 
            }
           
                GridMain.Content = brandView;

            
        }

        private void DocumentView(object sender, RoutedEventArgs e)
        {
            if (documentView == null)
            {
                documentView = new DocumentView();
            }
           
                GridMain.Content = documentView;

            
        }

        private void ModelView(object sender, RoutedEventArgs e)
        {
            if (modelView == null)
            {
                modelView = new ModelViewPage();
            }
            
                GridMain.Content = modelView;

            
        }

        private void ConsumableView(object sender, RoutedEventArgs e)
        {
            if (consumableView == null)
            {
                consumableView = new ConsumableView();
            }
           
                GridMain.Content = consumableView;

            
        }

        private void ContragentView(object sender, RoutedEventArgs e)
        {
            if (contragentView == null)
            {
                contragentView = new ContragentView();
            }
           
                GridMain.Content = contragentView;

            
        }

        private void FuelView(object sender, RoutedEventArgs e)
        {
            if (fuelView == null)
            {
                fuelView = new FuelView();
            }
            
                GridMain.Content = fuelView;

            
        }

        private void MeasureView(object sender, RoutedEventArgs e)
        {
            if (measuresView == null)
            {
                measuresView = new MeasuresView();
            }
            
                GridMain.Content = measuresView;

            
        }

        private void TypeView(object sender, RoutedEventArgs e)
        {
            if (typeView == null)
            {
                typeView = new TypeView();
            }
            
                GridMain.Content = typeView;

            
        }

        private void DocTypeView(object sender, RoutedEventArgs e)
        {
            if (docTypeView == null)
            {
                docTypeView = new DocTypeView();
            }
            
                GridMain.Content = docTypeView;

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if(Singletone.uRole== "счетоводител")
            {
                ItemCreate.IsEnabled = false;
            }

            if (homePageNotificationView == null)
            {
                homePageNotificationView = new HomePageNotificationView();
            }
            else
            {
                GridMain.Content = homePageNotificationView;

            }
            GridMain.Content = homePageNotificationView;
            txtName.Text = Singletone.LogedUser.ToString();
            txtRole.Text = Singletone.uRole.ToString();
            this.Title = "МПС Мениджър";
        }

        private void ConsumableByCarView(object sender, RoutedEventArgs e)
        {
            if (consumableByCarView == null)
            {
                consumableByCarView = new ConsumableByCarView();
            }
            
                GridMain.Content = consumableByCarView;

            
            
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (homePageNotificationView == null)
            {
                homePageNotificationView = new HomePageNotificationView();
            }
            
                GridMain.Content = homePageNotificationView;

            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (spravkaCarSum == null)
            {
                spravkaCarSum = new SpravkaCarSum();
            }
            
                GridMain.Content = spravkaCarSum;

            
            //GridMain.Content = homePageNotificationView;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (spravkaDocConsumables == null)
            {
                spravkaDocConsumables = new SpravkaDocConsumables();

            }
                GridMain.Content = spravkaDocConsumables;

            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (spravkaDocDetails == null)
            {
                spravkaDocDetails = new SpravkaDocDetails();
                
            }
           
                GridMain.Content = spravkaDocDetails;

            
        }

        private void Logout(object sender, MouseButtonEventArgs e)
        {
            
            this.Close();
            login.TBusername.Text = "";
            login.TBpassword.Password = "";
            
            login.Show();
            login.TBusername.Focus();
        }
    }
}
