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
    
    public partial class Tramite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tramite()
        {
            this.Documento = new HashSet<Documento>();
            this.SeguimientoTramite = new HashSet<SeguimientoTramite>();
            this.TramiteCombustible = new HashSet<TramiteCombustible>();
            this.TramiteSustancia = new HashSet<TramiteSustancia>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<int> Id_Prioridad { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdTipoTramite { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public Nullable<int> IdEntidadReguladora { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documento> Documento { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual EntidadReguladora EntidadReguladora { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeguimientoTramite> SeguimientoTramite { get; set; }
        public virtual TipoTramite TipoTramite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TramiteCombustible> TramiteCombustible { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TramiteSustancia> TramiteSustancia { get; set; }
    }
}
