using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Model;
using static Vueling.Common.Logic.Enums.Enums;

namespace Vueling.Business.Logic
{
    //Se tendrian que utilizar genericos.
    public interface IAlumnoBL
    {
        Alumno Add(Alumno alumno, TipoDocumento tipoFichero);
    }
}
