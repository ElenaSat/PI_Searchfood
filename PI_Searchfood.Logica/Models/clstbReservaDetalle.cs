using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Searchfood.Logica.Models
{
    public class clstbReservaDetalle
    {
        public long longredeCodigo { set; get; }
        public clstbRestaurante clstbRestaurante { set; get;}
        public clstbComida clstbComida { set; get; }
        public long longredeCantidad { set; get; }
        public float floatredeSubtotal { set; get; }
    }
}
