using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class RepositorioCliente
    {
        string ruta = @"Clientes.txt";
        public string Guardar(Cliente cliente)
        {
            try
            {

                StreamWriter escritor = new StreamWriter(ruta, true);
                escritor.WriteLine(cliente.ToString());
                escritor.Close();
                return "Se han guardado los datos";
            }
            catch (Exception)
            {
                return "ERROR...No se han guardado los datos";
            }

        }

        public string Modificar2(List<Cliente> clientes)
        {
            try
            {
                StreamWriter escritor = new StreamWriter("tmp.txt", true);
                foreach (var item in clientes)
                {
                    escritor.WriteLine(item.ToString());

                }

                escritor.Close();

                File.Delete(ruta);
                File.Move("tmp.txt", ruta);

                return "Se han modificado  los datos";

            }
            catch (Exception)
            {

                return "ERROR... No Se modificar los datos";
            }

        }

        public Cliente Buscar(string identificacion)
        {
            List<Cliente> clientes = ConsultaGeneral();
            foreach (var item in clientes)
            {
                if (Encontrado(item.Id, identificacion))
                {
                    return item;
                }
            }
            return null;
        }
        private bool Encontrado(string IdClienteRegistrado, string IdClienteBuscado)
        {
            return IdClienteRegistrado == IdClienteBuscado;
        }
        public List<Cliente> ConsultaGeneral()
        {
            List<Cliente> clientes = new List<Cliente>();

            StreamReader lector = new StreamReader(ruta);
            string linea = string.Empty;
            while (!lector.EndOfStream)
            {
                linea = lector.ReadLine();
                Cliente cliente = new Cliente(linea);
                clientes.Add(cliente);
            }
            lector.Close();

            return clientes;
        }

        public Cliente Mapper(string linea)
        {
            try
            {
                var cliente = new Cliente();
                cliente.Id = linea.Split(';')[0];
                cliente.Nombre = linea.Split(';')[1];
                cliente.Telefono = linea.Split(';')[2];
                return cliente;

            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<Cliente> GetAll()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                StreamReader sr = new StreamReader(ruta);
                while (!sr.EndOfStream)
                {
                    clientes.Add(Mapper(sr.ReadLine()));
                }
                sr.Close();
                return clientes;
            }
            catch (Exception)
            {

                return null;
            }

        }

    }
}
