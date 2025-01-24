using Proyecto2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.RN
{
    public class RNSustanciaControlada : Contexto
    {
        private dbSistemadeInformacionIINoviembre2024Entities Esquema;

        public RNSustanciaControlada()
        {
            Esquema = this.TraerEsquema();
        }

        public List<SustanciaControlada> ListarSustancias()
        {
            try
            {
                return Esquema.SustanciaControlada.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar sustancias controladas: " + ex.Message);
            }
        }

        public SustanciaControlada BuscarPorId(int id)
        {
            return Esquema.SustanciaControlada.FirstOrDefault(s => s.Id == id);
        }
    }
}
