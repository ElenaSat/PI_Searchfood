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
    
    public partial class tbIncidencia_Comentarios
    {
        public int Id_ICom { get; set; }
        public Nullable<int> Id_Incidencia { get; set; }
        public string Comentarios { get; set; }
        public Nullable<int> Estado_Incidencia_IDCom { get; set; }
    
        public virtual tbEstado_Incidencia tbEstado_Incidencia { get; set; }
        public virtual tbIncidencia tbIncidencia { get; set; }
    }
}