using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Helado
    {
        public string Codigo { get; set; }
        public string NombreHelado { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public int PrecioHelado { get; set; }

        public override string ToString()
        {
            return $"{Codigo};{NombreHelado}; {Categoria}; {Cantidad};{PrecioHelado}";
        }

        public Helado()
        {

        }

        public Helado(string linea)
        {
            if(linea != null)
            {
                Mapear(linea);
            }
        }

        public Helado(string codigo, string nombreHelado, string categoria, int cantidad, int precioHelado)
        {
            Codigo = codigo;
            NombreHelado = nombreHelado;
            Categoria = categoria;
            Cantidad = cantidad;
            PrecioHelado = precioHelado;
        }

        public void Mapear(string linea)
        {
            Codigo = linea.Split(';')[0];
            NombreHelado = linea.Split(';')[1];
            Categoria = linea.Split(';')[2];
            Cantidad = int.Parse(linea.Split(';')[3]);
            PrecioHelado = int.Parse(linea.Split(';')[4]);
        }
    }
}
