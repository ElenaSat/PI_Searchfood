using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Searchfood.Logica.Models
{
  public  class clstbRestaurante
    {   public long longrestCodigo { set; get; }
        public string strrestNombre { set; get; }
        public string strrestDireccion { set; get; }
        public string strrestTelefono { set; get; }
        public string strrestDescripcion { set; get; }
        public string strrestLatitud { set; get; }
        public string   strrestLongitud { set; get; }
        public string strrestcorreo { set; get; }
        public clstbCiudad clstbCiudad { set; get; }
        public clsUsuarios clsUsuarios { set; get; }
        public string strrestPrincipal { set; get; }
        public string strrestSucursal { set; get; }

    }
}
