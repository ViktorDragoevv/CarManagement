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
    /// Interaction logic for SpravkaDocConsumables.xaml
    /// </summary>
    public partial class SpravkaDocConsumables : Page
    {
        public SpravkaDocConsumables()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*DateTime today = DateTime.Now;

            DateTime edndDate = DateTime.Now;
            DateTime startDate = DateTime.Now;

            //DateTime n = DateTime.d.AddDays(1).AddTicks(-1);

            string date = Convert.ToDateTime(dateTimePicker2.Text).ToString("yyyy/MM/dd HH:m:s");
            DateTime dd = Convert.ToDateTime(date);
            startDate = dateTimePicker1.SelectedDate.Value;
            //MessageBox.Show(startDate.ToString());
            if (dd.Date.Day == today.Date.Day && dd.Date.Month == today.Date.Month)
            {
                edndDate = today;
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                DataSet1 dataset = new DataSet1();

                dataset.Clear();
                dataset.BeginInit();

                reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file
                reportDataSource1.Value = dataset.ReportDocDetailsCOnsumable;
                this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer.LocalReport.ReportEmbeddedResource = "DiplomnaCarProject.Report2.rdlc";

                dataset.EndInit();

                //fill data into adventureWorksDataSet
                DataSet1TableAdapters.ReportDocDetailsCOnsumableTableAdapter salesOrderDetailTableAdapter = new DataSet1TableAdapters.ReportDocDetailsCOnsumableTableAdapter();
                salesOrderDetailTableAdapter.ClearBeforeFill = true;
                salesOrderDetailTableAdapter.Fill(dataset.ReportDocDetailsCOnsumable, startDate, edndDate);

                reportViewer.RefreshReport();
                reportViewer.Refresh();
                reportViewer.Update();
            }
            else
            {


                DateTime d = dateTimePicker2.SelectedDate.Value.AddDays(1).AddSeconds(-1);
                edndDate = d;
                //MessageBox.Show(edndDate.ToString());
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                DataSet1 dataset = new DataSet1();

                dataset.Clear();
                dataset.BeginInit();

                reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file
                reportDataSource1.Value = dataset.ReportDocDetailsCOnsumable;
                this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer.LocalReport.ReportEmbeddedResource = "DiplomnaCarProject.Report2.rdlc";

                dataset.EndInit();

                //fill data into adventureWorksDataSet
                DataSet1TableAdapters.ReportDocDetailsCOnsumableTableAdapter salesOrderDetailTableAdapter = new DataSet1TableAdapters.ReportDocDetailsCOnsumableTableAdapter();
                salesOrderDetailTableAdapter.ClearBeforeFill = true;
                salesOrderDetailTableAdapter.Fill(dataset.ReportDocDetailsCOnsumable, startDate, edndDate);

                reportViewer.RefreshReport();
                reportViewer.Refresh();
                reportViewer.Update();
            }*/
           
            //MessageBox.Show(edndDate.ToString());
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            DataSet1 dataset = new DataSet1();

            dataset.Clear();
            dataset.BeginInit();
            reportViewer.Reset();
            reportViewer.LocalReport.DataSources.Clear();
           
            reportViewer.RefreshReport();
            
            reportDataSource1.Name = "DataSet1"; //Name of the report dataset in our .RDLC file
            reportDataSource1.Value = dataset.ReportDocDetailsCOnsumable;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "DiplomnaCarProject.Report2.rdlc";

            dataset.EndInit();

            DateTime sd = dateTimePicker1.SelectedDate.Value;
            DateTime ed = dateTimePicker2.SelectedDate.Value.AddDays(1).AddTicks(-1);
            //ed.AddDays(1);
            
            MessageBox.Show(sd.ToString());
            MessageBox.Show(ed.ToString());


            //fill data into adventureWorksDataSet
            DataSet1TableAdapters.ReportDocDetailsCOnsumableTableAdapter salesOrderDetailTableAdapter = new DataSet1TableAdapters.ReportDocDetailsCOnsumableTableAdapter();
            salesOrderDetailTableAdapter.ClearBeforeFill = true;
            salesOrderDetailTableAdapter.Fill(dataset.ReportDocDetailsCOnsumable, sd, ed);
            DateTime d1 = dateTimePicker1.SelectedDate.Value;
            string sDate = String.Format("{0:dd/MM/yyyy}", d1);
            DateTime d2 = dateTimePicker2.SelectedDate.Value;
            string eDate = String.Format("{0:dd/MM/yyyy}", d2);
            this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("startDate", sDate));
            this.reportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("endDate", eDate));
            reportViewer.RefreshReport();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dateTimePicker1.SelectedDate = DateTime.Today;
            dateTimePicker2.SelectedDate = DateTime.Today;
        }
    }
}
