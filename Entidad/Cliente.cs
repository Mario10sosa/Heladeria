using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cliente
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Telefono}";
        }
        public Cliente()
        {

        }
        public Cliente(string linea)
        {
            if (linea != null)
            {
                Mapear(linea);
            }

        }
        public Cliente(string id, string nombre, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
        }
        private void Mapear(string linea)
        {
            Id = linea.Split(';')[0];
            Nombre = linea.Split(';')[1];
            Telefono = linea.Split(';')[2];
            
        }
    }
    
}
