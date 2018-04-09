using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Searchfood.Logica.Models
{
  public class clstbBonus
    {
        public long longbonuCodigo { set; get; }
        public clstbRestaurante clstbRestaurante { set; get; }
        public clstbPersona clstbPersona { set; get; }
        public long longbonuDescuento { set; get; }


    }
}
