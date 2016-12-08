using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace LightSwitchApplication {
    /// <summary>
    /// Summary description for GetRifFromSeniat
    /// </summary>
    public class GetRifFromSeniat : IHttpHandler {
        public void ProcessRequest(HttpContext context) {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var numeroRif = context.Request.Form.Get("rif");
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Write(serializer.Serialize(GetRif(numeroRif)));
        }

        public bool IsReusable {
            get {
                return false;
            }
        }

        public Rif GetRif(string numero) {
            Rif result = null;
            var url = string.Format("http://contribuyente.seniat.gob.ve/getContribuyente/getrif?rif={0}", numero);
            try {
                var data = XElement.Load(url);
                result = new Rif {
                    Numero = numero.ToUpper(),
                    Nombre = XmlHelper.GetStringElement(data, "rif", "Nombre")
                };
            } catch (Exception) {
            }
            return result;
        }
    }

    public class Rif {
        public string Numero { get; set; }
        public string Nombre { get; set; }
    }

    public static class XmlHelper {
        public static string GetStringElement(XElement parent, XNamespace ns, string elementName) {
            string result = string.Empty;
            if (parent != null && parent.HasElements && !string.IsNullOrWhiteSpace(elementName) && ns != null) {
                var element = parent.Element(ns + elementName);
                if (element != null) {
                    result = element.Value;
                }
            }
            return result;
        }
    }
}