using Proyecto2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.RN
{
    public class RNTramite : Contexto
    {
        private dbSistemadeInformacionIINoviembre2024Entities Esquema;

        public RNTramite()
        {
            Esquema = this.TraerEsquema();
        }

        public Int64 GenerarId()
        {
            try
            {
                return (from t in Esquema.Tramite select t.Id).Max() + 1;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public bool InsertarTramite(Tramite objTramite)
        {
            try
            {
                using (var transaction = Esquema.Database.BeginTransaction())
                {
                    try
                    {
                        // Establecer valores por defecto
                        objTramite.FechaInicio = DateTime.Now;
                        objTramite.Estado = "Pendiente";

                        Esquema.Tramite.Add(objTramite);
                        Esquema.SaveChanges();

                        // Crear seguimiento inicial del trámite
                        SeguimientoTramite seguimiento = new SeguimientoTramite
                        {
                            IdTramite = objTramite.Id,
                            Estado = "Iniciado",
                            Fecha = DateTime.Now,
                            Observaciones = "Trámite iniciado"
                        };

                        Esquema.SeguimientoTramite.Add(seguimiento);
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

        public List<Tramite> ListarTramites()
        {
            return Esquema.Tramite.ToList();
        }

        public List<Tramite> ListarTramitesPorCliente(int idCliente)
        {
            return Esquema.Tramite.Where(t => t.IdCliente == idCliente).ToList();
        }

        public List<Tramite> ListarTramitesPorEstado(string estado)
        {
            return Esquema.Tramite.Where(t => t.Estado == estado).ToList();
        }

        public bool ActualizarEstadoTramite(int idTramite, string nuevoEstado, string observaciones)
        {
            using (var transaction = Esquema.Database.BeginTransaction())
            {
                try
                {
                    var tramite = Esquema.Tramite.Find(idTramite);
                    if (tramite == null)
                        return false;

                    tramite.Estado = nuevoEstado;

                    SeguimientoTramite seguimiento = new SeguimientoTramite
                    {
                        IdTramite = idTramite,
                        Estado = nuevoEstado,
                        Fecha = DateTime.Now,
                        Observaciones = observaciones
                    };

                    Esquema.SeguimientoTramite.Add(seguimiento);
                    Esquema.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public List<SeguimientoTramite> ObtenerSeguimientoTramite(int idTramite)
        {
            return Esquema.SeguimientoTramite
                .Where(s => s.IdTramite == idTramite)
                .OrderByDescending(s => s.Fecha)
                .ToList();
        }

        public bool ValidarTramite(Tramite objTramite)
        {
            if (objTramite.IdCliente <= 0)
                throw new Exception("Cliente no válido");

            if (objTramite.IdTipoTramite <= 0)
                throw new Exception("Tipo de trámite no válido");

            if (objTramite.IdEmpleado <= 0)
                throw new Exception("Empleado responsable no válido");

            if (objTramite.IdEntidadReguladora <= 0)
                throw new Exception("Entidad reguladora no válida");

            if (string.IsNullOrEmpty(objTramite.Descripcion))
                throw new Exception("La descripción es obligatoria");

            return true;
        }
    }
}
