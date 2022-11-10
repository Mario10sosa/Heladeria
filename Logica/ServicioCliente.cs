using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;

namespace Logica
{
    public class ServicioCliente
    {
        RepositorioCliente repositorioClientes = new RepositorioCliente();
        List<Cliente> clientes; 
        public ServicioCliente()
        {
            clientes = repositorioClientes.ConsultaGeneral();
        }
        public string Guardar(Cliente cliente)
        {
            string mensaje = string.Empty;
            try
            {

                if (repositorioClientes.Buscar(cliente.Id) == null)
                {
                    mensaje = repositorioClientes.Guardar(cliente);
                    Actualizar();
                    return mensaje;
                }
                return mensaje;
            }
            catch (Exception e)
            {
                return "ERROR: " + e.Message;
            }
        }
        private void Actualizar()
        {
            clientes = repositorioClientes.ConsultaGeneral();
        }
        public Cliente BuscarID(string IDcliente)
        {
            foreach (var item in clientes)
            {
                if (item.Id == IDcliente)
                {
                    return item;
                }

            }
            return null;

        }

        public List<Cliente> GetAll()
        {
            clientes = repositorioClientes.GetAll();
            return clientes;
        }

        public Cliente BuscarId(string id)
        {
            foreach (var item in clientes)
            {
                if (item.Id == id)
                {
                    return item;
                }

            }
            return null;

        }

        public string Modificar(Cliente Cliente_New)
        {
            Cliente cliente_actual = BuscarId(Cliente_New.Id);
            if (cliente_actual == null)
            {
                return Guardar(Cliente_New);

            }
            else
            {
                cliente_actual.Id = Cliente_New.Id;
                cliente_actual.Nombre = Cliente_New.Nombre;
                cliente_actual.Telefono = Cliente_New.Telefono;
                return repositorioClientes.Modificar2(clientes);
            }

        }

        public string Eliminar(string id)
        {
            Cliente cuenta = BuscarId(id);
            if (cuenta == null)
            {
                return "El id ingresado, no ha sido encontrada";
            }
            else
            {
                clientes.Remove(cuenta);

                repositorioClientes.Modificar2(clientes);
                return "El Cliente ha sido eliminada";
            }
        }
    }
}
