using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicioHelados
    {
        RepositorioHelado repositorioHelado = new RepositorioHelado();
        List<Helado> helados;

        public ServicioHelados()
        {
            helados = repositorioHelado.ConsultaGeneral();
        }

        public string Guardar(Helado helado)
        {
            string mensaje = string.Empty;
            try
            {

                if (repositorioHelado.Buscar(helado.Codigo) == null)
                {
                    mensaje = repositorioHelado.Guardar(helado);
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
            helados = repositorioHelado.ConsultaGeneral();
        }
        public Helado BuscarID(string CodHelados)
        {
            foreach (var item in helados)
            {
                if (item.Codigo == CodHelados)
                {
                    return item;
                }

            }
            return null;

        }

        public List<Helado> GetAll()
        {
            helados = repositorioHelado.GetAll();
            return helados;
        }

        public Helado BuscarCod(string codigo)
        {
            foreach (var item in helados)
            {
                if (item.Codigo == codigo)
                {
                    return item;
                }

            }
            return null;

        }

        public string Modificar(Helado Helado_New)
        {
            Helado Helado_actual = BuscarCod(Helado_New.Codigo);
            if (Helado_actual == null)
            {
                return Guardar(Helado_New);

            }
            else
            {
                Helado_actual.Codigo = Helado_New.Codigo;
                Helado_actual.NombreHelado = Helado_New.NombreHelado;
                Helado_actual.Categoria = Helado_New.Categoria;
                Helado_actual.Cantidad = Convert.ToInt16(Helado_New.Cantidad);
                Helado_actual.PrecioHelado = Convert.ToInt32(Helado_New.PrecioHelado);
                return repositorioHelado.Modificar2(helados);
            }

        }

        public string Eliminar(string codigo)
        {
            Helado cuenta = BuscarCod(codigo);
            if (cuenta == null)
            {
                return "El codigo ingresado, no ha sido encontrada";
            }
            else
            {
                helados.Remove(cuenta);

                repositorioHelado.Modificar2(helados);
                return "El helado ha sido eliminada";
            }
        }
    }
}
