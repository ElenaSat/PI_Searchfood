

namespace PI_Searchfood.Logica.Models
{
   public class clstbPersona
    {
        
        public long longpersIdentificacion { get; set; }
        public string stpersNombre { get; set; }
        public string stpersApellido { get; set; }
        public string stpersDireccion { get; set; }
        public string stpersCorreo { get; set; }
        public string stpersCelular { get; set; }
        public clstbGenero  clstbGenero{ get; set; }
        public  clstbCiudad clstbCiudad { get; set; }
        public clsUsuarios clsUsuarios { get; set; }
    }
}
