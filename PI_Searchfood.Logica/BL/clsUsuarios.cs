using System;
using System.Data;
using System.Data.SqlClient;

namespace PI_Searchfood.Logica.BL
{
    public class clsUsuarios
    {
        SqlConnection _SqlConnection = null; //Me permite establecer comunicacion con BBDD
        SqlCommand _SqlCommand = null; //Me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null; // Me permite adapter conjunto de datos SQL
        string stConexion = string.Empty; //Cadena de Conexion;
        SqlParameter _SqlParameter = null;

        public clsUsuarios() {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
            }
        public bool getValidarUsuario(Models.clsUsuarios obclsUsuarios) {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();
                _SqlCommand = new SqlCommand("spConsultarUsuario", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.Parameters.Add(new SqlParameter("@cLogin", obclsUsuarios.stLogin));
                _SqlCommand.Parameters.Add(new SqlParameter("@cPassword", obclsUsuarios.stPassword));
                _SqlCommand.Parameters.Add(new SqlParameter("@cperfcodigo", obclsUsuarios.stPerfil));
                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);
                if (dsConsulta.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                _SqlConnection.Close();
            }

        }

        public int getValidarCodigo()
        {
            try
            {
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spGenerarCodigo", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@codigo";
                _SqlParameter.Direction = ParameterDirection.Output;
                _SqlParameter.SqlDbType = SqlDbType.Int;
                _SqlCommand.Parameters.Add(_SqlParameter);
                _SqlCommand.ExecuteNonQuery();

                return Convert.ToInt32(_SqlParameter.Value);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { _SqlConnection.Close(); }


        }

    }
}
