//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PI_SearchfoodF.MVC.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class tbTipoIncidencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbTipoIncidencia()
        {
            this.tbIncidencia = new HashSet<tbIncidencia>();
        }
    
        public int Id_TipoIncidencia { get; set; }
        [DisplayName("Tipo Incidencia")]
        public string TipoInDescripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbIncidencia> tbIncidencia { get; set; }
    }
}
