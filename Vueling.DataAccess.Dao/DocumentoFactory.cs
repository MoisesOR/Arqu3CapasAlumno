using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using static Vueling.Common.Logic.Enums.Enums;


namespace Vueling.DataAccess.Dao
{
    public class DocumentoFactory
    {
        public static Object CrearDocumento(TipoDocumento tipoDocumento, string nombre)
        {
            switch (tipoDocumento)
            {
                case TipoDocumento.Texto:
                    return new DocumentoTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "DocumentoAlumnos.txt"));
                case TipoDocumento.Json:
                    return new DocumentoJson(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "DocumentoAlumnos.json"));
                case TipoDocumento.Xml:
                    return new DocumentoXml(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "DocumentoAlumnos.xml"));
                default:
                    return new DocumentoTxt(nombre, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "DocumentoAlumnos.txt"));
            }
        }
    }
}
