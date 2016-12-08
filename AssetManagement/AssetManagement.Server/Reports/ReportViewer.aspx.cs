using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightSwitchApplication.Reports {
    public partial class ReportViewer : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack && !string.IsNullOrWhiteSpace(Request.QueryString["ReportName"])) {
                ShowReportViewer();
            }
        }

        private void ShowReportViewer() {
            string reportName = Request.QueryString["ReportName"];
            string reportPath = GetReportPath(reportName);
            
            this.ReportViewer1.ProcessingMode = ProcessingMode.Local;
            this.ReportViewer1.LocalReport.ReportPath = Server.MapPath(reportPath);
            this.ReportViewer1.LocalReport.DataSources.Add(GetReportDataSource(reportName));
        }

        private ReportDataSource GetReportDataSource(string reportName) {
            string datasetName = "";
            IEnumerable data = null;
            switch (reportName) {
                case "LicenciasUsadas":
                    datasetName = "AssetManagement_ReportService_LicenciasUsadas";
                    data = GetLicenciasEnUso();
                    break;
                case "LicenciasDisponibles":
                    datasetName = "AssetManagement_ReportService_LicenciasDisponible";
                    data = GetLicenciasDisponibles();
                    break;
            }
            if (data != null && !string.IsNullOrWhiteSpace(datasetName)) {
                return new ReportDataSource(datasetName, data);
            }
            return new ReportDataSource();
        }

        private string GetReportPath(string reportName) {
            switch (reportName) {
                case "LicenciasUsadas":
                    return "~/Reports/LicenciasUsadas.rdlc";
                case "LicenciasDisponibles":
                    return "~/Reports/LicenciasDisponibles.rdlc";
            }
            return string.Empty;
        }

        private List<LicenciasEnUso> GetLicenciasEnUso() {
            List<LicenciasEnUso> list = new List<LicenciasEnUso>();
            using (var context = ServerApplicationContext.CreateContext()) {
                var enumerator = context.DataWorkspace.ReportsServiceData.LicenciasEnUso.GetEnumerator();
                while (enumerator.MoveNext()) {
                    list.Add(enumerator.Current as LicenciasEnUso);
                }
            };
            return list;
        }

        private List<LicenciasDisponible> GetLicenciasDisponibles() {
            List<LicenciasDisponible> list = new List<LicenciasDisponible>();
            using (var context = ServerApplicationContext.CreateContext()) {
                var enumerator = context.DataWorkspace.ReportsServiceData.LicenciasDisponibles.GetEnumerator();
                while (enumerator.MoveNext()) {
                    list.Add(enumerator.Current as LicenciasDisponible);
                }
            };
            return list;
        }
    }
}