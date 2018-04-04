using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic;
using static Vueling.Common.Logic.Enums.Enums;
using Vueling.DataAccess.Dao;

namespace Vueling.DataAccess.Dao
{
    public class AlumnoDao : IAlumnoDao
    {
        public AlumnoDao()
        {
        }

        public Alumno Add(Alumno alumno, TipoDocumento tipoDocumento)
        {
            IDocumento documento = (IDocumento)DocumentoFactory.CrearDocumento(tipoDocumento, "DocumentoAlumnos");
            documento.Guardar(alumno);
            return alumno;
        }
    }
}
