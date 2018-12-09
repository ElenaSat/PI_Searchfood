using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI_SearchfoodF.MVC.Models
{
    public class tbEstadoIncidencia
    {
        public int Id_EstdIncidencia { get; set; }
        [Required]
        [DisplayName("Descripción")]
        public string EstdDescripcion { get; set; }
    }
}