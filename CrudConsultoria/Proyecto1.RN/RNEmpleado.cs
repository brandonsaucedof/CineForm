using Proyecto2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.RN
{
    public class RNEmpleado : Contexto
    {
        private dbSistemadeInformacionIINoviembre2024Entities Esquema;

        public RNEmpleado()
        {
            Esquema = this.TraerEsquema();
        }

        public List<Empleado> ListarEmpleados()
        {
            try
            {
                return Esquema.Empleado.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar empleados: " + ex.Message);
            }
        }

        public Empleado BuscarEmpleadoPorId(int id)
        {
            return Esquema.Empleado.FirstOrDefault(e => e.Id == id);
        }
    }
}
