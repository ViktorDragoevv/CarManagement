using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    /// Interaction logic for AddEditCar.xaml
    /// </summary>
    public partial class AddEditCar : Window
    {
        int picture = 0;
        string imageExtension = "";
        byte[] byteData;

        public static int brandSQL = 0;

        public string imageEx = "";

        SQL sql = new SQL();
        private int mode;
        private string regNum;
        private string VIN;
        private string color;
        private string engineNum;
        private int idedit;
        int model;
        int fuel;
        int brand;

        public AddEditCar(int mode, int model = 0,int brand =0, int fuel=0, string regNum="", string VIN = "", string color ="", string engineNum="", int idedit = 0)
        {
            InitializeComponent();
            this.mode = mode;
            this.model = model;
            this.fuel = fuel;
            this.VIN = VIN;
            this.regNum = regNum;
            this.color = color;
            this.engineNum = engineNum;
            this.idedit = idedit;
            this.brand = brand;

            

        }
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            // Load data into the table BrandView. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.BrandViewTableAdapter dataSet1BrandViewTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.BrandViewTableAdapter();
            dataSet1BrandViewTableAdapter.Fill(dataSet1.BrandView);
            System.Windows.Data.CollectionViewSource brandViewViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("brandViewViewSource")));
            brandViewViewSource.View.MoveCurrentToFirst();
            
            // Load data into the table fuel. You can modify this code as needed.
            DiplomnaCarProject.DataSet1TableAdapters.fuelTableAdapter dataSet1fuelTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.fuelTableAdapter();
            dataSet1fuelTableAdapter.Fill(dataSet1.fuel);
            System.Windows.Data.CollectionViewSource fuelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("fuelViewSource")));
            fuelViewSource.View.MoveCurrentToFirst();
            

            if (mode == 1)
            {
                byte[] bytee;
                bytee = sql.LoadImage(idedit);

                img.Source = LoadImage(bytee);


                cbModel.IsEnabled = true;

                this.Title = "Редактиране на превозно средство";

                //DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
                DiplomnaCarProject.DataSet1TableAdapters.modelSortTableAdapter dsds = new DiplomnaCarProject.DataSet1TableAdapters.modelSortTableAdapter();
                dsds.FillBy(dataSet1.modelSort);
                cbBrand.SelectedValue = brand;
                cbModel.SelectedValue = model;
                cbFuel.SelectedValue = fuel;
                textBoxRegNum.Text = regNum;
                textBoxVIN.Text = VIN;
                textBoxColor.Text = color;
                textBoxEngineNum.Text = engineNum;
                btnNotify.Visibility = Visibility.Hidden;



            }
            else if (mode==0)
            {
                this.Title = "Добавяне на превозно средство";
                cbBrand.SelectedIndex = -1;
                cbModel.IsEnabled = false;
                btnNotify.Visibility = Visibility.Hidden;

            }
            else if (mode == 3)
            {
                this.Title = "Профил на превозно средство";
                cbModel.IsEnabled = true;
                btnPicture.Visibility = Visibility.Hidden;
                b1.Visibility = Visibility.Hidden;
                /*byte[] bytee;
                bytee = sql.LoadImage(idedit);

                img.Source = LoadImage(bytee);


                cbModel.IsEnabled = true;



                //DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
                DiplomnaCarProject.DataSet1TableAdapters.modelSortTableAdapter dsds = new DiplomnaCarProject.DataSet1TableAdapters.modelSortTableAdapter();
                dsds.FillBy(dataSet1.modelSort);
                cbBrand.SelectedValue = brand;
                cbModel.SelectedValue = model;
                cbFuel.SelectedValue = fuel;
                textBoxRegNum.Text = regNum;
                textBoxVIN.Text = VIN;
                textBoxColor.Text = color;
                textBoxEngineNum.Text = engineNum;*/
                sql.CarModelJoin(idedit, this);
                sql.CarBrandJoin(idedit, this);
                sql.PopulateCarProfile(idedit, this);
                sql.CarModelJoin(idedit, this);
                byte[] bytee;
                bytee = sql.LoadImage(idedit);

                img.Source = LoadImage(bytee);

            }


            
            
            
        }

        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        private void btnPicture_Click(object sender, RoutedEventArgs e)
        {
            picture = 1;
            /* var dialog = new OpenFileDialog
             {
                 CheckFileExists = true,
                 Multiselect = false,
                 Filter = "Images (*.jpg,*.png)|*.jpg;*.png|All Files(*.*)|*.*"
             };

             if (dialog.ShowDialog() != true) 
             {

                 Uri resourceUri = new Uri("/Images/white_bengal_tiger.jpg", UriKind.Relative);
                 img.Source = new BitmapImage(resourceUri);


             }*/
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                byteData = null;
                Uri fileUri = new Uri(openFileDialog.FileName);
                img.Source = new BitmapImage(fileUri);
                byteData = getJPGFromImageControl(new BitmapImage(fileUri));
                
                 imageExtension = System.IO.Path.GetExtension(openFileDialog.FileName);
                


            }


            /*ImagePath.Text = dialog.FileName;
            MyImage.Source = new BitmapImage(new Uri(lImagePath.Text));

            using (var fs = new FileStream(ImagePath.Text, FileMode.Open, FileAccess.Read))
            {
                _imageBytes = new byte[fs.Length];
                fs.Read(imgBytes, 0, System.Convert.ToInt32(fs.Length));
            }*/

        }

        private void cbBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbModel.IsEnabled = true;
            int selectedBrand = Convert.ToInt32(cbBrand.SelectedValue);
            

            DiplomnaCarProject.DataSet1 dataSet1 = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.modelSortTableAdapter dataSet1BrandViewTableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.modelSortTableAdapter();
            dataSet1BrandViewTableAdapter.Fill(dataSet1.modelSort,selectedBrand);

            
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            if(mode == 0)
            {
                if(cbBrand.SelectedIndex == -1 || cbFuel.SelectedIndex == -1 || cbModel.SelectedIndex == -1 || textBoxColor.Text == "" || textBoxEngineNum.Text == "" || textBoxRegNum.Text == "" || textBoxVIN.Text == "")
                {
                    MessageBox.Show("Populnete poletata");
                }
                else
                {
                    sql.addCar(int.Parse(cbBrand.SelectedValue.ToString()), int.Parse(cbModel.SelectedValue.ToString()), int.Parse(cbFuel.SelectedValue.ToString()), textBoxRegNum.Text.ToString(), textBoxVIN.Text.ToString(), textBoxColor.Text.ToString(), textBoxEngineNum.Text.ToString());
                    //sql.Notify(notification, int.Parse(pers.ToString()), int.Parse(textBoxDays.Text.ToString()));
                    int carID = sql.GetCarID();
                    sql.NotificationInsert(carID, 1, DateTime.Today);
                    sql.NotificationInsert(carID, 2, DateTime.Today);
                    sql.NotificationInsert(carID, 3, DateTime.Today);
                    sql.NotificationInsert(carID, 4, DateTime.Today);
                    if (picture == 1)
                    {
                        if (byteData == null)
                        {

                        }
                        else
                        {
                            sql.addPicture(byteData, imageExtension);
                        }
                        
                    }
                    DialogResult = true;
                    this.Close();
                }
            }
            else if (mode == 1)
            {
                if (cbBrand.SelectedIndex == -1 || cbFuel.SelectedIndex == -1 || cbModel.SelectedIndex == -1 || textBoxColor.Text == "" || textBoxEngineNum.Text == "" || textBoxRegNum.Text == "" || textBoxVIN.Text == "")
                {
                    MessageBox.Show("Populnete poletata");
                }
                else
                {


                    sql.editCar(int.Parse(cbBrand.SelectedValue.ToString()), int.Parse(cbModel.SelectedValue.ToString()), int.Parse(cbFuel.SelectedValue.ToString()), textBoxRegNum.Text.ToString(), textBoxVIN.Text.ToString(), textBoxColor.Text.ToString(), textBoxEngineNum.Text.ToString(), idedit);
                    if (picture == 1)
                    {
                        if (byteData == null)
                        {
                           
                        }
                        else
                        {
                            sql.editPicture(byteData, imageExtension, idedit);
                        }

                    }
                    DialogResult = true;
                    this.Close();

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnNotify_Click(object sender, RoutedEventArgs e)
        {
            

                AddNotification addeditCarDialog = new AddNotification(idedit);
                addeditCarDialog.ShowDialog();



                if (addeditCarDialog.DialogResult.HasValue && addeditCarDialog.DialogResult.Value)
                {
                    
                }





           
        }
    }
}
