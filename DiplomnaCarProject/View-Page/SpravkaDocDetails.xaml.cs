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
    /// Interaction logic for SpravkaDocDetails.xaml
    /// </summary>
    public partial class SpravkaDocDetails : Page
    {
        public SpravkaDocDetails()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dateTimePicker1.SelectedDate = DateTime.Today;
            dateTimePicker2.SelectedDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime today = DateTime.Now;

            DateTime edndDate = dateTimePicker2.DisplayDate;
            DateTime startDate = dateTimePicker1.DisplayDate;

            //DateTime n = DateTime.d.AddDays(1).AddTicks(-1);

            string date = Convert.ToDateTime(dateTimePicker2.Text).ToString("yyyy/MM/dd HH:m:s");
            DateTime dd = Convert.ToDateTime(date);
            //startDate = dateTimePicker1.SelectedDate.Value;
            //MessageBox.Show(startDate.ToString());
            if (dd.Date.Day == today.Date.Day && dd.Date.Month == today.Date.Month)
            {
                //edndDate = today;
                //MessageBox.Show(edndDate.ToString());
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                DataSet1 dataset = new DataSet1();
                DateTime d = dateTimePicker2.SelectedDate.Value.AddDays(1).AddSeconds(-1);
                DateTime s = dateTimePicker1.SelectedDate.Value;
                dataset.Clear();
                dataset.BeginInit();
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.Update();
                reportViewer.RefreshReport();
                reportViewer.Refresh();
                reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file
                reportDataSource1.Value = dataset.ReportDocDetails;
                this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer.LocalReport.ReportEmbeddedResource = "DiplomnaCarProject.Report3.rdlc";

                dataset.EndInit();

                //fill data into adventureWorksDataSet
                DataSet1TableAdapters.ReportDocDetailsTableAdapter salesOrderDetailTableAdapter = new DataSet1TableAdapters.ReportDocDetailsTableAdapter();
                salesOrderDetailTableAdapter.ClearBeforeFill = true;
                salesOrderDetailTableAdapter.Fill(dataset.ReportDocDetails, s, d);

                reportViewer.RefreshReport();
                reportViewer.Refresh();
                reportViewer.Update();
            }
            else
            {

                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.Update();
                reportViewer.RefreshReport();
                reportViewer.Refresh();
                DateTime d = dateTimePicker2.SelectedDate.Value.AddDays(1).AddSeconds(-1);
                DateTime s = dateTimePicker1.SelectedDate.Value;
                edndDate = d;
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                DataSet1 dataset = new DataSet1();

                dataset.Clear();
                dataset.BeginInit();

                reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file
                reportDataSource1.Value = dataset.ReportDocDetails;
                this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer.LocalReport.ReportEmbeddedResource = "DiplomnaCarProject.Report3.rdlc";

                dataset.EndInit();

                //fill data into adventureWorksDataSet
                DataSet1TableAdapters.ReportDocDetailsTableAdapter salesOrderDetailTableAdapter = new DataSet1TableAdapters.ReportDocDetailsTableAdapter();
                salesOrderDetailTableAdapter.ClearBeforeFill = true;
                salesOrderDetailTableAdapter.Fill(dataset.ReportDocDetails, s, d);

                reportViewer.RefreshReport();
                reportViewer.Refresh();
                reportViewer.Update();
            }
        }
    }
}
