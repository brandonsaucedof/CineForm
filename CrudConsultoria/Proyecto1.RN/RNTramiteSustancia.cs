using Proyecto2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.RN
{
    public class RNTramiteSustancia : Contexto
    {
        private dbSistemadeInformacionIINoviembre2024Entities Esquema;

        public RNTramiteSustancia()
        {
            Esquema = this.TraerEsquema();
        }

        public bool InsertarTramiteSustancia(TramiteSustancia objTramiteSustancia)
        {
            try
            {
                Esquema.TramiteSustancia.Add(objTramiteSustancia);
                return Esquema.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar trámite sustancia: " + ex.Message);
            }
        }

        public List<TramiteSustancia> ListarPorTramite(int idTramite)
        {
            return Esquema.TramiteSustancia.Where(ts => ts.IdTramite == idTramite).ToList();
        }
    }
}
