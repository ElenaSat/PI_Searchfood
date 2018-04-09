using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Searchfood.Logica.Models
{
    public class clstbReservas
    {
        public clstbRestaurante clstbRestaurante {set; get;}
        public clstbPersona clstbPersona { set; get; }
        public long longreseCodigo { set; get; }
        public string strreseFecha { set; get; }

        public int intestaCodigo { set; get; }
        public float floatreseTotal { set; get; }
        public float floatreseImpuesto { set; get; }
        public string strreseObservacion { set; get; }

    }
}
