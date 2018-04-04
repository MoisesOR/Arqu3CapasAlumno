using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Enums;
using static Vueling.Common.Logic.Enums.Enums;

namespace Vueling.DataAccess.Dao
{
    public interface IAlumnoDao 
    {
        Alumno Add(Alumno alumno, TipoDocumento tipoDocumento);
    }
}