using Proyecto2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.RN
{
    public class RNPlanPago : Contexto
    {

        private dbSistemadeInformacionIINoviembre2024Entities Esquema;

        public RNPlanPago()
        {
            try
            {
                Esquema = new dbSistemadeInformacionIINoviembre2024Entities();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al inicializar: " + ex.Message);
            }
        }

        public List<PlanPago> TraerPlanPago(int Id)
        {
            try
            {
                if (Id == 0)
                    return Esquema.PlanPago.ToList();
                else
                    return Esquema.PlanPago.Where(p => p.Id == Id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener planes: " + ex.Message);
            }
        }
    }
}