using Proyecto2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.RN
{
    public class RNTipoTramite : Contexto
    {
        private dbSistemadeInformacionIINoviembre2024Entities Esquema;

        public RNTipoTramite()
        {
            Esquema = this.TraerEsquema();
        }

        public List<TipoTramite> TraerTipoTramite(int Id)
        {
            try
            {
                if (Id == 0)
                    return Esquema.TipoTramite.ToList();
                else
                    return Esquema.TipoTramite.Where(t => t.Id == Id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener tipos de trámite: " + ex.Message);
            }
        }
    }
}