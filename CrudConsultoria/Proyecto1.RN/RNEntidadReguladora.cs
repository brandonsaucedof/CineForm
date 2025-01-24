using Proyecto2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.RN
{
    public class RNEntidadReguladora : Contexto
    {
        private dbSistemadeInformacionIINoviembre2024Entities Esquema;

        public RNEntidadReguladora()
        {
            Esquema = this.TraerEsquema();
        }

        public List<EntidadReguladora> ListarEntidades()
        {
            try
            {
                return Esquema.EntidadReguladora.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar entidades reguladoras: " + ex.Message);
            }
        }

        public EntidadReguladora BuscarPorId(int id)
        {
            return Esquema.EntidadReguladora.FirstOrDefault(e => e.Id == id);
        }
    }
}
