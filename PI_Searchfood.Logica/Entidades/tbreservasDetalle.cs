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
    
    public partial class tbreservasDetalle
    {
        public decimal redeCodigo { get; set; }
        public decimal restCodigo { get; set; }
        public decimal comiCodigo { get; set; }
        public decimal redeCantidad { get; set; }
        public decimal redeSubtotal { get; set; }
    
        public virtual tbComida tbComida { get; set; }
        public virtual tbrestaurante tbrestaurante { get; set; }
    }
}