using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Vueling.Common.Logic.Enums.Enums;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Newtonsoft.Json;
using Vueling.Business.Logic;

namespace Vueling.DataAccess.Dao.Tests
{
    [TestClass()]
    public class AlumnoTests
    {
        [TestInitialize]
        public void Initialize()
        {
            this.EliminarFichero();
        }

        private void EliminarFichero()
        {
            string[] fileEntries = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "ListadoDeAlumnos.*");
            for (int i = 0; i < fileEntries.Length; ++i)
            {
                File.Delete(fileEntries[i]);
            }
        }

        [DataRow(TipoDocumento.Texto, "DocumentoTxt.txt")]
        [DataTestMethod]
        public void CrearTipoFicheroFactoryTest(TipoDocumento tipo, string nombre)
        {
            IDocumento fichero = (IDocumento)DocumentoFactory.CrearDocumento(tipo, nombre);
            Assert.IsTrue(fichero.GetType() == typeof(DocumentoTxt));
        }

        [DataRow(TipoDocumento.Json, "DocumentoJson.json")]
        [DataTestMethod]
        public void CrearTipoFicheroJsonFactoryTest(TipoDocumento tipo, string nombre)
        {
            IDocumento fichero = (IDocumento)DocumentoFactory.CrearDocumento(tipo, nombre);
            Assert.IsTrue(fichero.GetType() == typeof(DocumentoJson));
        }

        [DataRow(TipoDocumento.Xml, "MiPrimerFicheroJson.xml")]
        [DataTestMethod]
        public void CrearTipoFicheroXmlFactoryTest(TipoDocumento tipo, string nombre)
        {
            IDocumento fichero = (IDocumento)DocumentoFactory.CrearDocumento(tipo, nombre);
            Assert.IsTrue(fichero.GetType() == typeof(DocumentoXml));
        }

        [DataRow("DocumentoAlumnos.txt", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void CrearFicheroTestTxt(string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IDocumento fichero = (IDocumento)DocumentoFactory.CrearDocumento(TipoDocumento.Texto, nombre);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);
            Assert.IsTrue(File.Exists(fichero.Ruta));
        }

        [DataRow("DocumentoAlumnos.json", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void CrearFicheroTestJson(string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IDocumento fichero = (IDocumento)DocumentoFactory.CrearDocumento(TipoDocumento.Json, nombre);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);
            Assert.IsTrue(File.Exists(fichero.Ruta));
        }

        [DataRow("DocumentoAlumnos.xml", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void CrearFicheroTestXml(string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IDocumento fichero = (IDocumento)DocumentoFactory.CrearDocumento(TipoDocumento.Xml, nombre);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);
            Assert.IsTrue(File.Exists(fichero.Ruta));
        }

        [DataRow(TipoDocumento.Texto, "DocumentoAlumnos.txt", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void GuardarAlumnoFicheroTextoTest(TipoDocumento tipo, string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IDocumento fichero = (IDocumento)DocumentoFactory.CrearDocumento(tipo, nombre);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);

            Alumno alumnoFichero = FileUtils.DeserializeTexto(fichero.Ruta);
            Assert.IsTrue(alumno.Equals(alumnoFichero));
        }

        [DataRow(TipoDocumento.Json, "DocumentoAlumnos.json", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void GuardarAlumnoFicheroJsonTest(TipoDocumento tipo, string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IDocumento fichero = (IDocumento)DocumentoFactory.CrearDocumento(tipo, nombre);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);

            Alumno alumnoFichero = FileUtils.DeserializeJson(fichero.Ruta);
            Assert.IsTrue(alumno.Equals(alumnoFichero));
        }

        [DataRow(TipoDocumento.Xml, "DocumentoAlumnos.xml", 1, "Leia", "Organa", "1234", 26, "22-01-1992")]
        [DataTestMethod]
        public void GuardarAlumnoFicheroXmlTest(TipoDocumento tipo, string nombreFichero, int id, string nombre, string apellidos, string dni, int edad, string fechaNacimiento)
        {
            IDocumento fichero = (IDocumento)DocumentoFactory.CrearDocumento(tipo, nombre);
            Alumno alumno = new Alumno(id, nombre, apellidos, dni, edad, Convert.ToDateTime(fechaNacimiento));

            fichero.Guardar(alumno);

            Alumno alumnoFichero = FileUtils.DeserializeXml(fichero.Ruta);
            Assert.IsTrue(alumno.Equals(alumnoFichero));
        }
    }
}