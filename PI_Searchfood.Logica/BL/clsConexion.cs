using System.Configuration;

namespace PI_Searchfood.Logica.BL
{
    public class clsConexion
    {
        /// <summary>
        /// OBTIENE CONEXION BD
        /// </summary>
        /// <returns> CADENA DE CONEXION</returns>
        public string getConexion() {
            return ConfigurationManager.ConnectionStrings["Cnx"].ToString();

        }


    }
}
