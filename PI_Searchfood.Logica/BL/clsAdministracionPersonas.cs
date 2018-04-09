using System;
using System.Data;
using System.Data.SqlClient;

namespace PI_Searchfood.Logica.BL
{
   public  class clsAdministracionPersonas
    {
        SqlConnection _SqlConnection = null; //Me permite establecer comunicacion con BBDD
        SqlCommand _SqlCommand = null; //Me permite ejecutar comandos SQL
        SqlDataAdapter _SqlDataAdapter = null; // Me permite adapter conjunto de datos SQL
        string stConexion = string.Empty; //Cadena de Conexion;
        SqlParameter _SqlParameter = null;

        public clsAdministracionPersonas()
        {
            clsConexion obclsConexion = new clsConexion();
            stConexion = obclsConexion.getConexion();
        }
        /// <summary>
        /// ConsultarPersona
        /// </summary>
        /// <returns>REGISTROS DE PERSONAS</returns>
        public DataSet getConsultarPersonas() {
            try
            {
                DataSet dsConsulta = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarPersona", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsulta);
                return dsConsulta;

            }
            catch (Exception ex){throw ex;} finally { _SqlConnection.Close(); }


        }
        /// <summary>
        /// Consultar Genero
        /// </summary>
        /// <returns>REGISTRO DE GÈNERO</returns>
        public DataSet getConsultarGenero()
        {
            try
            {
                DataSet dsConsultarGenero = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarGenero", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsultarGenero);
                return dsConsultarGenero;

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
                _SqlCommand.Parameters.Add(new SqlParameter("@CodigoDepaCiudad", inCodigoDepCiudad ));
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsultarCiudad);
                return dsConsultarCiudad;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }


        }

        public DataSet getConsultarPD(int inCodigoCiudad) {
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

        public DataSet getConsultarGU(int inCodigoGU)
        {
            try
            {
                DataSet dsConsultarGU = new DataSet();
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spConsultarGU", _SqlConnection);
                _SqlCommand.Parameters.Add(new SqlParameter("@geneCodigo", inCodigoGU));
                _SqlCommand.CommandType = CommandType.StoredProcedure;

                _SqlCommand.ExecuteNonQuery();

                _SqlDataAdapter = new SqlDataAdapter(_SqlCommand);
                _SqlDataAdapter.Fill(dsConsultarGU);
                return dsConsultarGU;

            }
            catch (Exception ex) { throw ex; }
            finally { _SqlConnection.Close(); }


        }
        /// <summary>
        /// Administrar Persona
        /// </summary>
        /// <param name="obclstbPersona"></param>
        /// <param name="inOpcion"></param>
        /// <returns></returns>

        public string setAdministrarPersona(Models.clstbPersona obclstbPersona, int inOpcion)
        {
            try
            {
                
                _SqlConnection = new SqlConnection(stConexion);
                _SqlConnection.Open();

                _SqlCommand = new SqlCommand("spAdministrarPersona", _SqlConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                //Ingreso de Datos
                _SqlCommand.Parameters.Add(new SqlParameter("@persIdentificacion", obclstbPersona.longpersIdentificacion));
                _SqlCommand.Parameters.Add(new SqlParameter("@persNombre", obclstbPersona.stpersNombre));
                _SqlCommand.Parameters.Add(new SqlParameter("@persApellido", obclstbPersona.stpersApellido));
                
                _SqlCommand.Parameters.Add(new SqlParameter("@persDireccion", obclstbPersona.stpersDireccion));
                _SqlCommand.Parameters.Add(new SqlParameter("@persCorreo", obclstbPersona.stpersCorreo));
                _SqlCommand.Parameters.Add(new SqlParameter("@persCelular", obclstbPersona.stpersCelular));
                _SqlCommand.Parameters.Add(new SqlParameter("@geneCodigo", obclstbPersona.clstbGenero.longeneCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@ciudCodigo", obclstbPersona.clstbCiudad.ciudCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@usuaCodigo", obclstbPersona.clsUsuarios.inCodigo));
                _SqlCommand.Parameters.Add(new SqlParameter("@usuacontraseña", obclstbPersona.clsUsuarios.stPassword));
                _SqlCommand.Parameters.Add(new SqlParameter("@inOpcion", inOpcion));

                
                _SqlParameter = new SqlParameter();
                _SqlParameter.ParameterName = "@cMensaje";
                _SqlParameter.Direction = ParameterDirection.Output;
                _SqlParameter.SqlDbType = SqlDbType.VarChar;
                _SqlParameter.Size = 100;

                _SqlCommand.Parameters.Add(_SqlParameter);
                _SqlCommand.ExecuteNonQuery();

                return _SqlParameter.Value.ToString();

            }
            catch (Exception ex){ throw ex;}finally{ _SqlConnection.Close();}

        }
    }
}
