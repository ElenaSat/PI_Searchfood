using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Searchfood.Logica.BL
{
    public class clsEmpleados
    {
        public class clsModelEmpleado
        {
            public int ID { get; set; }
            public string NOMBRES { get; set; }
            public string APELLIDOS { get; set; }
        }

        List<clsModelEmpleado> lstclsModelEmpleado =
                new List<clsModelEmpleado>();

        public clsEmpleados()
        {

            clsModelEmpleado obclsModelEmpleado1 = new clsModelEmpleado
            {
                ID = 1,
                APELLIDOS = "PEREZ",
                NOMBRES = "JUAN"
            };

            clsModelEmpleado obclsModelEmpleado2 = new clsModelEmpleado
            {
                ID = 2,
                APELLIDOS = "DIAS",
                NOMBRES = "JUAN"
            };

            lstclsModelEmpleado.Add(obclsModelEmpleado1);
            lstclsModelEmpleado.Add(obclsModelEmpleado2);
        }

        public List<clsModelEmpleado> getEmpleados(string stNombreCompleto)
        {
            return (from q in lstclsModelEmpleado
                    where (q.NOMBRES + " " + q.APELLIDOS).Contains(stNombreCompleto)
                    select q).ToList();
        }
    }
}
