//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PI_Searchfood.Logica.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbbonus
    {
        public decimal bonuCodigo { get; set; }
        public decimal restCodigo { get; set; }
        public Nullable<decimal> persIdentificacion { get; set; }
        public Nullable<decimal> bonuDescuento { get; set; }
    
        public virtual tbrestaurante tbrestaurante { get; set; }
        public virtual tbpersona tbpersona { get; set; }
    }
}
