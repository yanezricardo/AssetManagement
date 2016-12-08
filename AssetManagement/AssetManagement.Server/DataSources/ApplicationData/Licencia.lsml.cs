using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication {
    public partial class Licencia {
        partial void Disponibles_Compute(ref int? result) {
            if (Autorizadas != null && Usadas != null) {
                result = Autorizadas - Usadas;
            } else if (Autorizadas != null) {
                result = Autorizadas;
            } else {
                result = 0;
            }
        }
    }
}
