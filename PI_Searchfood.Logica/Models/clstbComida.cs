using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Searchfood.Logica.Models
{
    public class clstbComida
    {
        public long longcomiCodigo { set; get; }
        public clstbCategoria clstbCategoria { set; get; }
        public clstbRestaurante clstbRestaurante { set; get; }
        public long loncomiValor { set; get; }
        public string strcomiDescripcion { set; get; }
        public string strcomiRutaImagen { set; get; }

    }
}
