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

namespace DiplomnaCarProject.View_Page
{
    /// <summary>
    /// Interaction logic for SpravkaCarSum.xaml
    /// </summary>
    public partial class SpravkaCarSum : Page
    {
        public SpravkaCarSum()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            DiplomnaCarProject.DataSet1 bloodlabDataSet = ((DiplomnaCarProject.DataSet1)(this.FindResource("dataSet1")));
            DiplomnaCarProject.DataSet1TableAdapters.carsTableAdapter tableAdapter = new DiplomnaCarProject.DataSet1TableAdapters.carsTableAdapter();
            tableAdapter.Fill(bloodlabDataSet.cars);
            System.Windows.Data.CollectionViewSource source = ((System.Windows.Data.CollectionViewSource)(this.FindResource("carsViewSource")));
            source.View.MoveCurrentToFirst();
            dateTimePicker1.SelectedDate = DateTime.Today;
            dateTimePicker2.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            //fill data into adventureWorksDataSet
            /* DataSet1TableAdapters.ReportPERIODKoliCeniTableAdapter salesOrderDetailTableAdapter = new DataSet1TableAdapters.ReportPERIODKoliCeniTableAdapter();
             salesOrderDetailTableAdapter.ClearBeforeFill = true;
             salesOrderDetailTableAdapter.Fill(dataset.reportPriceByCar);

             reportViewer.RefreshReport();*/

            







            if (checkBox1.IsChecked == true)
            {
                



                if (CBCar.SelectedIndex == -1)
                {
                    MessageBox.Show("Моля изберете МПС");
                }
                else
                {


                    DateTime today = DateTime.Now;

                    DateTime edndDate = DateTime.Now;
                    DateTime startDate = DateTime.Now;

                    //DateTime n = DateTime.d.AddDays(1).AddTicks(-1);

                    string date = Convert.ToDateTime(dateTimePicker2.Text).ToString("yyyy/MM/dd HH:m:s");
                    DateTime dd = Convert.ToDateTime(date);
                    startDate = dateTimePicker1.DisplayDate;
                    //MessageBox.Show(startDate.ToString());

                    if (dd.Date.Day == today.Date.Day && dd.Date.Month == today.Date.Month)
                    {
                        edndDate = today;
                        reportViewer.LocalReport.DataSources.Clear();
                        reportViewer.Update();
                        reportViewer.RefreshReport();
                        reportViewer.Refresh();
                        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                        DataSet1 dataset = new DataSet1();

                        dataset.Clear();
                        dataset.BeginInit();

                        reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file
                        reportDataSource1.Value = dataset.PeriodKoliCeniSFILTUR;
                        this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                        this.reportViewer.LocalReport.ReportEmbeddedResource = "DiplomnaCarProject.Report1.rdlc";

                        dataset.EndInit();

                        //fill data into adventureWorksDataSet
                        DataSet1TableAdapters.PeriodKoliCeniSFILTURTableAdapter salesOrderDetailTableAdapter = new DataSet1TableAdapters.PeriodKoliCeniSFILTURTableAdapter();
                        salesOrderDetailTableAdapter.ClearBeforeFill = true;
                        salesOrderDetailTableAdapter.Fill(dataset.PeriodKoliCeniSFILTUR , startDate, edndDate, int.Parse(CBCar.SelectedValue.ToString()));

                        DateTime d1 = dateTimePicker1.SelectedDate.Value;
                        string sDate = String.Format("{0:dd/MM/yyyy}", d1);
                        DateTime d2 = dateTimePicker2.SelectedDate.Value;
                        string eDate = String.Format("{0:dd/MM/yyyy}", d2);
                        this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("startDate", sDate));
                        this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("endDate", eDate));
                        

                        reportViewer.RefreshReport();
                        reportViewer.Refresh();
                        reportViewer.Update();
                    }
                    else
                    {


                        DateTime d = dateTimePicker2.SelectedDate.Value.AddDays(1).AddSeconds(-1);
                        edndDate = d;
                        //MessageBox.Show(edndDate.ToString());
                        reportViewer.LocalReport.DataSources.Clear();
                        reportViewer.Update();
                        reportViewer.RefreshReport();
                        reportViewer.Refresh();
                        Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                        DataSet1 dataset = new DataSet1();

                        dataset.Clear();
                        dataset.BeginInit();

                        reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file
                        reportDataSource1.Value = dataset.PeriodKoliCeniSFILTUR;
                        this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                        this.reportViewer.LocalReport.ReportEmbeddedResource = "DiplomnaCarProject.Report1.rdlc";

                        dataset.EndInit();

                        //fill data into adventureWorksDataSet
                        DataSet1TableAdapters.PeriodKoliCeniSFILTURTableAdapter salesOrderDetailTableAdapter = new DataSet1TableAdapters.PeriodKoliCeniSFILTURTableAdapter();
                        salesOrderDetailTableAdapter.ClearBeforeFill = true;
                        salesOrderDetailTableAdapter.Fill(dataset.PeriodKoliCeniSFILTUR, startDate, edndDate, int.Parse(CBCar.SelectedValue.ToString()));
                        DateTime d1 = dateTimePicker1.SelectedDate.Value;
                        string sDate = String.Format("{0:dd/MM/yyyy}", d1);
                        DateTime d2 = dateTimePicker2.SelectedDate.Value;
                        string eDate = String.Format("{0:dd/MM/yyyy}", d2);
                        this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("startDate", sDate));
                        this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("endDate", eDate));
                        reportViewer.RefreshReport();
                        reportViewer.Refresh();
                        reportViewer.Update();
                    }

                }




            }
            else
            {
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.Update();
                reportViewer.RefreshReport();
                reportViewer.Refresh();
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                DataSet1 dataset = new DataSet1();
                dataset.Clear();
                dataset.BeginInit();

                reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file
                reportDataSource1.Value = dataset.ReportPERIODKoliCeni;
                this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer.LocalReport.ReportEmbeddedResource = "DiplomnaCarProject.Report1.rdlc";

                dataset.EndInit();

                //fill data into adventureWorksDataSet
                DataSet1TableAdapters.ReportPERIODKoliCeniTableAdapter salesOrderDetailTableAdapter = new DataSet1TableAdapters.ReportPERIODKoliCeniTableAdapter();
                salesOrderDetailTableAdapter.ClearBeforeFill = true;
                salesOrderDetailTableAdapter.Fill(dataset.ReportPERIODKoliCeni, Convert.ToDateTime(dateTimePicker1.SelectedDate), Convert.ToDateTime(dateTimePicker2.SelectedDate));
                DateTime d1 = dateTimePicker1.SelectedDate.Value;
                string sDate = String.Format("{0:dd/MM/yyyy}", d1);
                DateTime d2 = dateTimePicker2.SelectedDate.Value;
                string eDate = String.Format("{0:dd/MM/yyyy}", d2);
                this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("startDate", sDate));
                this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("endDate", eDate));
                reportViewer.RefreshReport();
                reportViewer.Refresh();
                reportViewer.Update();
            }


        }
    }
}
