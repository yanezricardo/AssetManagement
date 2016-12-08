using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.EntityClient;
using System.Web.Configuration;
using LightSwitchApplication.Implementation;
using System.ServiceModel.DomainServices.Server;

namespace AssetManagement.ReportService {
    public class ReportsDataService : DomainService {
        private ApplicationData _context;
        public ApplicationData Context {
            get {
                if (_context == null) {
                    string connString = WebConfigurationManager.ConnectionStrings["_IntrinsicData"].ConnectionString;
                    EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder();
                    builder.Metadata = "res://*/ApplicationData.csdl|res://*/ApplicationData.ssdl|res://*/ApplicationData.msl";
                    builder.Provider = "System.Data.SqlClient";
                    builder.ProviderConnectionString = connString;
                    _context = new ApplicationData(builder.ConnectionString);
                }
                return _context;
            }
        }

        [Query(IsDefault = true)]
        public IQueryable<LicenciasDisponibles> GetLicenciasDisponibles() {
            var licencias = this.Context.Licencias.Include("LicenciaRegistradas").Include("Software").ToList();
            var result = licencias.Select(lic => new LicenciasDisponibles {
                ID = lic.Id,
                Key = lic.Key,
                Software = lic.Software.Nombre,
                Version = lic.Software.Version,
                InstalacionesDisponibles = lic.Autorizadas - lic.LicenciaRegistradas.Count(),
            }).AsQueryable();
            return result;
        }

        [Query(IsDefault = true)]
        public IQueryable<LicenciasEnUso> GetLicenciasEnUso() {
            var licenciasEnUso = from lic in this.Context.LicenciaRegistradas
                                 select new LicenciasEnUso {
                                           ID = lic.Id,
                                           Key = lic.Licencia.Key,
                                           Software = lic.Licencia.Software.Nombre,
                                           Version = lic.Licencia.Software.Version,
                                           Computador = lic.Computador.Nombre,
                                           Usuario = lic.Computador.Usuario
                                       };
            return licenciasEnUso;
        }

        protected override int Count<T>(IQueryable<T> query) {
            return query.Count();
        }
    }
}
