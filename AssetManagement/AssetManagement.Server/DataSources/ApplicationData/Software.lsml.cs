using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication {
    public partial class Software {
        partial void LicenciasAutorizadas_Compute(ref int? result) {
            if (Licencia != null) {
                result = Licencia.Sum(i => i.Autorizadas);
            }
        }

        partial void LicenciasUsadas_Compute(ref int? result) {
            if (Licencia != null) {
                result = Licencia.Sum(i => i.Usadas);
            }
        }

        partial void LicenciasDisponibles_Compute(ref int? result) {
            if (Licencia != null) {
                result = Licencia.Sum(i => i.Disponibles);
            }
        }
    }
}
