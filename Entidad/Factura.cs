using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Factura
    {
        public string Id { get; set; }
        public string Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public string Fecha { get; set; }
        public Helado Helado { get; set;}
        public int Cant { get; set; }

        public Factura(string id, string usuario, Cliente cliente, string fecha, Helado helado, int cant)
        {
            Id= id;
            Usuario= usuario;
            Cliente= cliente;
            Fecha= fecha;
            Helado= helado;
            Cant= cant;
        }
        public Factura()
        {

        }

        public Factura(string linea)
        {
            if(linea == null)
            {
                Mapear(linea);
            }

        }
        private void Mapear(string linea)
        {
            Id = linea.Split(';')[0];
            Usuario= linea.Split(';')[1];
            Cliente.Id = linea.Split(';')[2];
            Fecha = linea.Split(';')[3];
            Helado.Codigo = (linea.Split(';')[4]);
            //Helado.NombreHelado = linea.Split(';')[5];
            Helado.PrecioHelado = int.Parse(linea.Split(';')[5]);
            Cant = int.Parse(linea.Split(';')[6]);
            
        }
        
        public override string ToString()
        {
            return $"{Id};{Usuario};{Cliente.Nombre};{Fecha};{Helado.NombreHelado};{Helado.Categoria};{Helado.PrecioHelado};{Cant}";
        }

    }
}

