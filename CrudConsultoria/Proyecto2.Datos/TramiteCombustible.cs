//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto2.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class TramiteCombustible
    {
        public int Id { get; set; }
        public Nullable<decimal> CantidadSolicitada { get; set; }
        public Nullable<int> IdTramite { get; set; }
        public string Justificacion { get; set; }
        public Nullable<System.DateTime> PeriodoUso { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> IdAutorizacionCombustible { get; set; }
    
        public virtual AutorizacionCombustible AutorizacionCombustible { get; set; }
        public virtual Tramite Tramite { get; set; }
    }
}
