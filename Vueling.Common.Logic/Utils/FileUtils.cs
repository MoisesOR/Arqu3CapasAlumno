using System;
using System.Collections.Generic;
using Vueling.Common.Logic.Model;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Vueling.Common.Logic
{
    public class FileUtils
    {
        private FileUtils()
        {
        }

        public static string ToJson(string data, Alumno alumno)
        {
            var AlumnosLista = JsonConvert.DeserializeObject<List<Alumno>>(data);
            AlumnosLista.Add(alumno);
            return JsonConvert.SerializeObject(AlumnosLista, Formatting.Indented);
        }

        public static string ToString(Alumno alumno)
        {
            return alumno.Id + "," + alumno.Nombre + "," + alumno.Apellido + "," + alumno.Dni + "," + alumno.Edad + "," + alumno.FechaNacimiento.ToString() + "," + alumno.FechaActual.ToString() + "," + alumno.GuidNum;
        }

        public static Alumno DeserializeTexto(string pathFile)
        {
            string[] liniaFichero = null;
            foreach (var line in File.ReadAllLines(pathFile))
            {
                liniaFichero = line.Split(',');
            }
            return new Alumno(Convert.ToInt32(liniaFichero[0]), liniaFichero[1], liniaFichero[2], liniaFichero[3], Convert.ToInt32(liniaFichero[4]), Convert.ToDateTime(liniaFichero[5]), Convert.ToDateTime(liniaFichero[6]), liniaFichero[7]);
        }

        public static Alumno DeserializeJson(string pathFile)
        {
            var jsonData = System.IO.File.ReadAllText(pathFile);
            List<Alumno> alumnosList = JsonConvert.DeserializeObject<List<Alumno>>(jsonData);
            return new Alumno(alumnosList[0].Id, alumnosList[0].Nombre, alumnosList[0].Apellido, alumnosList[0].Dni, alumnosList[0].Edad, alumnosList[0].FechaNacimiento, alumnosList[0].FechaActual, alumnosList[0].GuidNum);
        }

        public static Alumno DeserializeXml(string pathFile)
        {
            Alumno alumno = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Alumno));
            using (FileStream fileStream = new FileStream(pathFile, FileMode.Open))
            {
                alumno = (Alumno)serializer.Deserialize(fileStream);
            }
            return alumno;
        }
    }
}
