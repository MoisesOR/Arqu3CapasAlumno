using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic;
using System.IO;

namespace Vueling.Common.Logic.Model
{
    public class DocumentoTxt : IDocumento
    {
        public string Nombre { get; set; }
        public string Ruta { get; set; }

        public DocumentoTxt(string nombre, string ruta)
        {
            this.Nombre = nombre;
            this.Ruta = ruta;
        }

        public void Guardar(Alumno alumno)
        {
            if (!File.Exists(this.Ruta))
            {
                using (StreamWriter sw = File.CreateText(this.Ruta))
                {
                    sw.WriteLine(FileUtils.ToString(alumno));
                }
            }
            else
            {
                File.AppendAllText(this.Ruta, FileUtils.ToString(alumno) + Environment.NewLine);
            }
        }
    }
}
