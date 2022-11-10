using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicioFactura
    {
        RepositorioFactura repositorioFactura = new RepositorioFactura();
        List<Factura> facturas;
        public ServicioFactura()
        {
            facturas = repositorioFactura.ConsultaGeneral();
        }

        public string Guardar(Factura factura)
        {
            string mensaje = string.Empty;
            try
            {

                if (repositorioFactura.Buscar(factura.Id) == null)
                {
                    mensaje = repositorioFactura.Guardar(factura);
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
            facturas = repositorioFactura.ConsultaGeneral();
        }
        public Factura BuscarID(string IDfactura)
        {
            foreach (var item in facturas)
            {
                if (item.Id == IDfactura)
                {
                    return item;
                }

            }
            return null;

        }

        public List<Factura> GetAll()
        {
            facturas = repositorioFactura.GetAll();
            return facturas;
        }

        public Factura BuscarId(string id)
        {
            foreach (var item in facturas)
            {
                if (item.Id == id)
                {
                    return item;
                }

            }
            return null;

        }

        public string Modificar(Factura Factura_New)
        {
            Factura factura_actual = BuscarId(Factura_New.Id);
            if (factura_actual == null)
            {
                return Guardar(Factura_New);

            }
            else
            {
                factura_actual.Id = Factura_New.Id;
                factura_actual.Usuario = Factura_New.Usuario;
                factura_actual.Cliente = Factura_New.Cliente;
                factura_actual.Fecha = Factura_New.Fecha;
                factura_actual.Helado = Factura_New.Helado;
                factura_actual.Cant = Factura_New.Cant;
                return repositorioFactura.Modificar2(facturas);
            }

        }

        public string Eliminar(string id)
        {
            Factura cuenta = BuscarId(id);
            if (cuenta == null)
            {
                return "El id ingresado, no ha sido encontrada";
            }
            else
            {
                facturas.Remove(cuenta);

                repositorioFactura.Modificar2(facturas);
                return "La Factura ha sido eliminada";
            }
        }

    }
}
