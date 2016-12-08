using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.ReportService {
    public class LicenciasEnUso {
        [Key]
        public int ID { get; set; }
        public string Software { get; set; }
        public string Version { get; set; }
        public string Key { get; set; }
        public string Computador { get; set; }
        public string Usuario { get; set; }
    }
}
