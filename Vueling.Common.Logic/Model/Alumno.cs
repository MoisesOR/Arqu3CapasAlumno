using System;
using System.Collections.Generic;

namespace Vueling.Common.Logic.Model
{
    public class Alumno : VuelingModelObject
    {
        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public DateTime FechaActual { get; set; }
        #endregion

        public Alumno()
        {
            this.GuidNum = Guid.NewGuid().ToString();
        }

        public Alumno(int id, string nombre, string apellido, string dni, int edad, DateTime fechaNacimiento)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Edad = edad;
            this.FechaNacimiento = fechaNacimiento;
            this.FechaActual = DateTime.Now;
            this.GuidNum = Guid.NewGuid().ToString();
        }

        public Alumno(int id, string nombre, string apellido, string dni, int edad, DateTime fechaNacimiento, DateTime fechaActual, string guid)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Edad = edad;
            this.FechaNacimiento = fechaNacimiento;
            this.FechaActual = fechaActual;
            this.GuidNum = guid;
        }

        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            return alumno != null &&
                   Id == alumno.Id &&
                   Nombre == alumno.Nombre &&
                   Apellido == alumno.Apellido &&
                   Dni == alumno.Dni &&
                   alumno.ToString() == alumno.FechaNacimiento.ToString() &&
                   Edad == alumno.Edad &&
                   FechaActual.ToString() == alumno.FechaActual.ToString() &&
                   GuidNum == alumno.GuidNum;
        }

        public override int GetHashCode()
        {
            var hashCode = 292974432;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellido);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + FechaNacimiento.GetHashCode();
            hashCode = hashCode * -1521134295 + Edad.GetHashCode();
            hashCode = hashCode * -1521134295 + FechaActual.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GuidNum);
            return hashCode;
        }
    }
}
