using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Searchfood.Logica.BL
{
    public class clsBuscador
    {

        public List<Models.clstbRestaurante> getBuquedadRest(string datoBus)
        {
            try
            {
                using (Entidades.BD_SEARCHFOODEntities1 obtDatos = new Entidades.BD_SEARCHFOODEntities1())
                {
                    List<Models.clstbRestaurante> lstclstbRestaurantes = (from rest in obtDatos.tbrestaurante
                                                                          from comi in obtDatos.tbComida
                                                                          from cate in obtDatos.tbCategorias
                                                                          from usuario in obtDatos.tbUsuarios
                                                                          where ((comi.restcodigo == rest.restCodigo && comi.cateCodigo == cate.cateCodigo && rest.usuaCodigo==usuario.usuaCodigo)
                                                                           && (
                                                                           rest.restNombre.Equals(datoBus) || comi.comiDescripcion.Equals(datoBus) || cate.cateDescripcion.Equals(datoBus))

                                                                          )
                                                                          group rest by new
                                                                          {
                                                                              rest.restCodigo,
                                                                              rest.restNombre,
                                                                              rest.restDireccion,
                                                                              rest.restCorreo,
                                                                              rest.restTelefono,
                                                                              rest.restDescripcion,
                                                                              rest.restLatitud,
                                                                              rest.restLongitud,
                                                                              rest.restPrincipal,
                                                                              rest.restSucursal,
                                                                              usuario.usuaImagen
                                                                          } into re
                                                                          select new Models.clstbRestaurante
                                                                          {
                                                                              longrestCodigo = (long)re.Key.restCodigo,
                                                                              strrestDireccion = re.Key.restDireccion,
                                                                              strrestNombre = re.Key.restNombre,
                                                                              strrestcorreo = re.Key.restCorreo,
                                                                              strrestTelefono = re.Key.restTelefono,
                                                                              strrestDescripcion = re.Key.restDescripcion,
                                                                              strrestLatitud = re.Key.restLatitud,
                                                                              strrestLongitud = re.Key.restLongitud,
                                                                              strrestPrincipal = re.Key.restPrincipal,
                                                                              strrestSucursal = re.Key.restSucursal,
                                                                              clsUsuarios = new Models.clsUsuarios
                                                                              {
                                                                                  stImagen = re.Key.usuaImagen
                                                                              }
                                                                          }).ToList();

                    return lstclstbRestaurantes;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Models.clstbRestaurante> getBuquedadRestUnico(string datoBus)
        {
            try
            {
                using (Entidades.BD_SEARCHFOODEntities1 obtDatos = new Entidades.BD_SEARCHFOODEntities1())
                {
                    List<Models.clstbRestaurante> lstclstbRestaurantes = (from rest in obtDatos.tbrestaurante
                                                                          from comi in obtDatos.tbComida
                                                                          from cate in obtDatos.tbCategorias
                                                                          from usuario in obtDatos.tbUsuarios
                                                                          where ((comi.restcodigo == rest.restCodigo && comi.cateCodigo == cate.cateCodigo && rest.usuaCodigo == usuario.usuaCodigo && usuario.usuaCorreo==datoBus))
                                                                          group rest by new
                                                                          {
                                                                              rest.restCodigo,
                                                                              rest.restNombre,
                                                                              rest.restDireccion,
                                                                              rest.restCorreo,
                                                                              rest.restTelefono,
                                                                              rest.restDescripcion,
                                                                              rest.restLatitud,
                                                                              rest.restLongitud,
                                                                              rest.restPrincipal,
                                                                              rest.restSucursal,
                                                                              usuario.usuaImagen
                                                                          } into re
                                                                          select new Models.clstbRestaurante
                                                                          {
                                                                              longrestCodigo = (long)re.Key.restCodigo,
                                                                              strrestDireccion = re.Key.restDireccion,
                                                                              strrestNombre = re.Key.restNombre,
                                                                              strrestcorreo = re.Key.restCorreo,
                                                                              strrestTelefono = re.Key.restTelefono,
                                                                              strrestDescripcion = re.Key.restDescripcion,
                                                                              strrestLatitud = re.Key.restLatitud,
                                                                              strrestLongitud = re.Key.restLongitud,
                                                                              strrestPrincipal = re.Key.restPrincipal,
                                                                              strrestSucursal = re.Key.restSucursal,
                                                                              clsUsuarios = new Models.clsUsuarios
                                                                              {
                                                                                  stImagen = re.Key.usuaImagen
                                                                              }
                                                                          }).ToList();

                    return lstclstbRestaurantes;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Models.clstbPersona> GetUsuarios(Models.clstbPersona obclstbPersona) {
            try
            {

                using (Entidades.BD_SEARCHFOODEntities1 obtDatos = new Entidades.BD_SEARCHFOODEntities1())
                {
                    List<Models.clstbPersona> lstclstUsuario = (from usuario in obtDatos.tbUsuarios
                                                                from perso in obtDatos.tbpersona
                                                                where (usuario.usuaCorreo == obclstbPersona.clsUsuarios.stLogin && usuario.usuaContraseña == obclstbPersona.clsUsuarios.stPassword && usuario.usuaCodigo == perso.usuaCodigo && perso.persCorreo == usuario.usuaCorreo)
                                                                select new Models.clstbPersona
                                                                {
                                                                    stpersNombre = perso.persNombre,
                                                                    stpersCorreo = perso.persCorreo,
                                                                    stpersApellido = perso.persApellido,
                                                                    stpersCelular = perso.persCelular,
                                                                    stpersDireccion = perso.persDireccion,
                                                                    clstbCiudad = new Models.clstbCiudad {
                                                                        ciudCodigo = (long)perso.tbciudad.ciudCodigo,
                                                                        ciudNombre = perso.tbciudad.ciudNombre,
                                                                        clstbDepartamento = new Models.clstbDepartamento {
                                                                            longdepaCodigo = (long)perso.tbciudad.tbdepartamento.depaCodigo,
                                                                            stdepaCombre = perso.tbciudad.tbdepartamento.depaCombre,
                                                                            clstbPais = new Models.clstbPais {

                                                                                longpaisCodigo = (long)perso.tbciudad.tbdepartamento.tbpais.paisCodigo,
                                                                                stpaisNombre = perso.tbciudad.tbdepartamento.tbpais.paisNombre
                                                                            }
                                                                        }
                                                                    },
                                                                    clsUsuarios = new Models.clsUsuarios {
                                                                        inCodigo = (int)perso.tbUsuarios.usuaCodigo,
                                                                        stLogin = perso.tbUsuarios.usuaCorreo,
                                                                        stPassword = perso.tbUsuarios.usuaContraseña,
                                                                        stDescripcion = "",
                                                                        stImagen="",
                                                                        stPerfil=1
                                                                    }
                                                                    
                                                                }).ToList();                                                   
                                                           

                    return lstclstUsuario;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
