using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioHelado
    {
        string ruta = @"helados.txt";

        public string Guardar(Helado helados)
        {
            try
            {

                StreamWriter escritor = new StreamWriter(ruta, true);
                escritor.WriteLine(helados.ToString());
                escritor.Close();
                return "Se han guardado los datos";
            }
            catch (Exception)
            {
                return "ERROR...No se han guardado los datos";
            }

        }

        public string Modificar2(List<Helado> helados)
        {
            try
            {
                StreamWriter escritor = new StreamWriter("tmp1.txt", true);
                foreach (var item in helados)
                {
                    escritor.WriteLine(item.ToString());

                }

                escritor.Close();

                File.Delete(ruta);
                File.Move("tmp1.txt", ruta);

                return "Se han modificado  los datos";

            }
            catch (Exception)
            {

                return "ERROR... No Se modificar los datos";
            }

        }

        public Helado Buscar(string codigoH)
        {
            List<Helado> helados = ConsultaGeneral();
            foreach (var item in helados)
            {
                if (Encontrado(item.Codigo, codigoH))
                {
                    return item;
                }
            }
            return null;
        }

        private bool Encontrado(string CodHeladoRegistrado, string CodHeladoBuscado)
        {
            return CodHeladoRegistrado == CodHeladoBuscado;
        }

        public List<Helado> ConsultaGeneral()
        {
            List<Helado> helados = new List<Helado>();

            StreamReader lector = new StreamReader(ruta);
            string linea = string.Empty;
            while (!lector.EndOfStream)
            {
                linea = lector.ReadLine();
                Helado helado = new Helado(linea);
                helados.Add(helado);
            }
            lector.Close();

            return helados;
        }
        public Helado Mapper(string linea)
        {
            try
            {
                var helado = new Helado();
                helado.Codigo = linea.Split(';')[0];
                helado.NombreHelado = linea.Split(';')[1];
                helado.Categoria = linea.Split(';')[2];
                helado.Cantidad = int.Parse(linea.Split(';')[3]);
                helado.PrecioHelado = int.Parse(linea.Split(';')[4]);
                return helado;

            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<Helado> GetAll()
        {
            try
            {
                List<Helado> helados = new List<Helado>();
                StreamReader sr = new StreamReader(ruta);
                while (!sr.EndOfStream)
                {
                    helados.Add(Mapper(sr.ReadLine()));
                }
                sr.Close();
                return helados;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
