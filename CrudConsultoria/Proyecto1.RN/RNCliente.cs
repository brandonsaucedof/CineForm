
using Proyecto2.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.RN
{
    public class RNCliente : Contexto
    {
        private dbSistemadeInformacionIINoviembre2024Entities Esquema;

        public RNCliente()
        {
            Esquema = this.TraerEsquema();
        }

        public Int64 GenerarId()
        {
            try
            {
                return (from e in Esquema.Cliente select e.Id).Max() + 1;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public bool InsertarClienteJuridico(Cliente objCliente, ClienteJuridico objCJuridico)
        {
            using (var transaction = Esquema.Database.BeginTransaction())
            {
                try
                {
                    objCliente.TipoCliente = "Juridico";
                    objCliente.FechaRegistro = DateTime.Now;

                    Esquema.Cliente.Add(objCliente);
                    Esquema.SaveChanges();

                    objCJuridico.IdCliente = objCliente.Id;
                    Esquema.ClienteJuridico.Add(objCJuridico);
                    Esquema.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool ExisteNIT(string nit)
        {
            return Esquema.ClienteJuridico.Any(c => c.NIT == nit);
        }

        public bool ExisteEmail(string email)
        {
            return Esquema.Cliente.Any(c => c.Email == email);
        }
        public List<Cliente> ListarClientes()
        {
            try
            {
                return (from c in Esquema.Cliente
                        join cj in Esquema.ClienteJuridico on c.Id equals cj.IdCliente
                        select c).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar clientes: " + ex.Message);
            }
        }
        public ClienteJuridico BuscarClienteJuridicoPorId(int idCliente)
        {
            try
            {
                return Esquema.ClienteJuridico
                    .FirstOrDefault(cj => cj.IdCliente == idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar cliente jurídico: " + ex.Message);
            }
        }
    }
}