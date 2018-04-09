using System;
using System.Data;
using System.Data.SqlClient;


namespace PI_Searchfood.Logica.BL
{
    public class clsRecuperarPassword
    {

        SqlConnection _SqlConnection = null; //Me permite establecer comunicacion con BBDD
        SqlCommand _SqlCommand = null; //Me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null; // Me permite adapter conjunto de datos SQL
        string stConexion = string.Empty; //Cadena de Conexion;
        public clsRecuperarPassword()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }

        public DataSet getConsultarPassword(Models.clsUsuarios obclsUsuarios)
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarPassword", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.Parameters.Add(new SqlParameter("@cLogin", obclsUsuarios.stLogin));

                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);
                return dsConsulta;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }


        }





    }

}
