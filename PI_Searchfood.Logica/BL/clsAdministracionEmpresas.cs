using System;
using System.Data;
using System.Data.SqlClient;

namespace PI_Searchfood.Logica.BL
{
    public class clsAdministracionEmpresas
    {
        SqlConnection _SqlConnection = null; //Me permite establecer comunicacion con BBDD
        SqlCommand _SqlCommand = null; //Me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null; // Me permite adapter conjunto de datos SQL
        string stConexion = string.Empty; //Cadena de Conexion;
        SqlParameter _SqlParameter = null;

        public clsAdministracionEmpresas()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }
        public DataSet getConsultarEmpresas()
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarEmpresa", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);
                return dsConsulta;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }


        }
        public DataSet getConsultarPais()
        {
            try
            {
                DataSet dsConsultarPais = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarPais", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsultarPais);
                return dsConsultarPais;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }


        }
        public DataSet getConsultarDepartamento(int inCodigoPaisDepa)
        {
            try
            {
                DataSet dsConsultarDepartamento = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarDepartamento", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.Parameters.Add(new SqlParameter("@CodigoPais", inCodigoPaisDepa));
                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsultarDepartamento);
                return dsConsultarDepartamento;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }


        }
        public DataSet getConsultarCiudad(int inCodigoDepCiudad)
        {
            try
            {
                DataSet dsConsultarCiudad = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarCiudad", _SqlConnection);
                _SqlCommand.Parameters.Add(new SqlParameter("@CodigoDepaCiudad", inCodigoDepCiudad));
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsultarCiudad);
                return dsConsultarCiudad;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }


        }

        public int getValidarCodigoRestaurante()
        {
            try
            {
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spGenerarCodigoR", _SqlConnection);
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
        public string setAdministrarEmpresas(Models.clstbRestaurante obclstbRestaurante, int inOpcion)
        {

            try {

                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarEmpresas", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                //Ingreso de Datos
                _SqlCommand.Parameters.Add(new SqlParameter("@restCodigo",obclstbRestaurante.longrestCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@restNombre",obclstbRestaurante.strrestNombre ));

                _SqlCommand.Parameters.Add(new SqlParameter("@restDireccion",obclstbRestaurante.strrestDireccion ));
                _SqlCommand.Parameters.Add(new SqlParameter("@restTelefono",obclstbRestaurante.strrestTelefono ));
                _SqlCommand.Parameters.Add(new SqlParameter("@restDescripcion",obclstbRestaurante.strrestDescripcion ));
                _SqlCommand.Parameters.Add(new SqlParameter("@restLatitud", obclstbRestaurante.strrestLatitud));
                _SqlCommand.Parameters.Add(new SqlParameter("@restLongitud",obclstbRestaurante.strrestLongitud ));

                _SqlCommand.Parameters.Add(new SqlParameter("@ciudCodigo", obclstbRestaurante.clstbCiudad.ciudCodigo ));
                _SqlCommand.Parameters.Add(new SqlParameter("@usuaCodigo",obclstbRestaurante.clsUsuarios.inCodigo ));
                _SqlCommand.Parameters.Add(new SqlParameter("@restCorreo", obclstbRestaurante.strrestcorreo));

                _SqlCommand.Parameters.Add(new SqlParameter("@restContraseña",obclstbRestaurante.clsUsuarios.stPassword ));
                _SqlCommand.Parameters.Add(new SqlParameter("@inOpcion", inOpcion));


                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@cMensaje";
                _SqlParameter.Direction = ParameterDirection.Output;
                _SqlParameter.SqlDbType = SqlDbType.VarChar;
                _SqlParameter.Size = 100;

                _SqlCommand.Parameters.Add(_SqlParameter);
                _SqlCommand.ExecuteNonQuery();

                return _SqlParameter.Value.ToString();

            }           catch (Exception ex) { throw ex; }
           finally { _SqlConnection.Close(); }

       }

        public DataSet getConsultarPDR(int inCodigoCiudad)
        {
            try
            {
                DataSet dsConsultarPD = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarPD", _SqlConnection);
                _SqlCommand.Parameters.Add(new SqlParameter("@ciudCodigo", inCodigoCiudad));
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsultarPD);
                return dsConsultarPD;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }



        }






    }
}