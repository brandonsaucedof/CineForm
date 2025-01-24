using Proyecto2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.RN
{
    public class RNContrato : Contexto
    {
        private dbSistemadeInformacionIINoviembre2024Entities Esquema;

        public RNContrato()
        {
            Esquema = this.TraerEsquema();
        }

        public Int64 GenerarId()
        {
            try
            {
                return (from c in Esquema.Contrato select c.Id).Max() + 1;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public bool InsertarContrato(Contrato objContrato)
        {
            try
            {
                using (var transaction = Esquema.Database.BeginTransaction())
                {
                    try
                    {
                        // Establecer valores iniciales
                        objContrato.Estado = "Activo";

                        Esquema.Contrato.Add(objContrato);
                        Esquema.SaveChanges();

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Contrato> ListarContratos()
        {
            return Esquema.Contrato.ToList();
        }

        public List<Contrato> ListarContratosPorCliente(int idCliente)
        {
            return Esquema.Contrato.Where(c => c.IdCliente == idCliente).ToList();
        }

        public bool ActualizarEstadoContrato(int idContrato, string nuevoEstado)
        {
            try
            {
                var contrato = Esquema.Contrato.Find(idContrato);
                if (contrato != null)
                {
                    contrato.Estado = nuevoEstado;
                    return Esquema.SaveChanges() > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidarContrato(Contrato objContrato)
        {
            if (objContrato.IdCliente <= 0)
                throw new Exception("Cliente no válido");

            if (objContrato.Costo <= 0)
                throw new Exception("El costo debe ser mayor a cero");

            if (objContrato.FechaFin <= objContrato.FechaInicio)
                throw new Exception("La fecha de fin debe ser posterior a la fecha de inicio");

            if (string.IsNullOrEmpty(objContrato.Clausula))
                throw new Exception("Debe especificar las cláusulas del contrato");

            return true;
        }
    }
}
