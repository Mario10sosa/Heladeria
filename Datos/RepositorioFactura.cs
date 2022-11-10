using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioFactura
    {
        string ruta = @"factura.txt";

        public string Guardar(Factura factura)
        {
            try
            {

                StreamWriter escritor = new StreamWriter(ruta, true);
                escritor.WriteLine(factura.ToString());
                escritor.Close();
                return "Se han guardado los datos";
            }
            catch (Exception)
            {
                return "ERROR...No se han guardado los datos";
            }
        }

        public string Modificar2(List<Factura> facturas)
        {
            try
            {
                StreamWriter escritor = new StreamWriter("tmpF.txt", true);
                foreach (var item in facturas)
                {
                    escritor.WriteLine(item.ToString());

                }

                escritor.Close();

                File.Delete(ruta);
                File.Move("tmpF.txt", ruta);

                return "Se han modificado  los datos";

            }
            catch (Exception)
            {

                return "ERROR... No Se modificar los datos";
            }

        }

        public Factura Buscar(string idFactura)
        {
            List<Factura> facturas = ConsultaGeneral();
            foreach (var item in facturas)
            {
                if (Encontrado(item.Id, idFactura))
                {
                    return item;
                }
            }
            return null;
        }

        private bool Encontrado(string IdFacturaRegistrado, string IdFacturaBuscado)
        {
            return IdFacturaRegistrado == IdFacturaBuscado;
        }

        public List<Factura> ConsultaGeneral()
        {
            List<Factura> facturas = new List<Factura>();

            StreamReader lector = new StreamReader(ruta);
            string linea = string.Empty;
            while (!lector.EndOfStream)
            {
                linea = lector.ReadLine();
                Factura factura = new Factura(linea);
                facturas.Add(factura);
            }
            lector.Close();

            return facturas;
        }

        public Factura Mapper(string linea)
        {
            try
            {
                var factura = new Factura();
                factura.Id = linea.Split(';')[0];
                factura.Usuario = linea.Split(';')[1];
                factura.Cliente.Id = linea.Split(';')[2];
                factura.Fecha = linea.Split(';')[3];
                factura.Helado.Codigo = (linea.Split(';')[4]);
                //Helado.NombreHelado = linea.Split(';')[5];
                //factura.Helado.PrecioHelado = int.Parse(linea.Split(';')[5]);
                factura.Cant = int.Parse(linea.Split(';')[6]);
                return factura;

            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<Factura> GetAll()
        {
            try
            {
                List<Factura> facturas = new List<Factura>();
                StreamReader sr = new StreamReader(ruta);
                while (!sr.EndOfStream)
                {
                    facturas.Add(Mapper(sr.ReadLine()));
                }
                sr.Close();
                return facturas;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
