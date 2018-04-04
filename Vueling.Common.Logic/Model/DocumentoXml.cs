using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Vueling.Common.Logic.Model
{
    public class DocumentoXml : IDocumento
    {
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public DocumentoXml(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public void Guardar(Alumno alumno)
        {
            TextWriter writer = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(alumno.GetType());
                if (!File.Exists(this.Ruta))
                {
                    writer = new StreamWriter(this.Ruta, false);

                }
                else
                {
                    writer = new StreamWriter(this.Ruta, true);
                }
                serializer.Serialize(writer, alumno);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }

            }
        }
    }
}

