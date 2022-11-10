using Entidad;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Logica;

namespace Presentacion
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }
        Cliente cliente = new Cliente();
        ServicioCliente servicioCliente = new ServicioCliente();
        void guardar()
        {

            cliente.Id = TxtIdClientes.Text;
            cliente.Nombre = TxtNombreCliente.Text;
            cliente.Telefono = txtTel.Text;
            

            string mensaje;
            mensaje = servicioCliente.Guardar(cliente);

            MessageBox.Show(mensaje);
        }
        void Buscar(string id)
        {
            
            Cliente cliente;
            cliente = servicioCliente.BuscarID(id);
            if (cliente == null)
            {
                MessageBox.Show("No se encuentra el cliente en nuestro sistema");
                return;
            }
            Ver(cliente);
        }
        void Ver(Cliente cliente)
        {
            TxtIdClientes.Text = cliente.Id;
            TxtNombreCliente.Text = cliente.Nombre;
            txtTel.Text = cliente.Telefono;
            
        }
        void cargar()
        {
            dataListadoC.DataSource = servicioCliente.GetAll(); 
        }
        void Limpiar()
        {
            TxtIdClientes.Clear();
            TxtNombreCliente.Clear();
            txtTel.Clear();

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
            Limpiar();
            cargar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(TxtIdClientes.Text);
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            cargar();
        }

        void Modificar()
        {
            if (cliente == null)
            {
                MessageBox.Show("No se Encuentra Registrado el cliente");
            }
            cliente.Id = TxtIdClientes.Text;
            cliente.Nombre = TxtNombreCliente.Text;
            cliente.Telefono = txtTel.Text;
            string mensaje;
            mensaje = servicioCliente.Modificar(cliente);
            MessageBox.Show(mensaje);
        }

        void Eliminar()
        {
            if (cliente == null)
            {
                MessageBox.Show("No se Encuentra Registrado el cliente");
            }
           
            string mensaje;
            mensaje = servicioCliente.Eliminar(TxtIdClientes.Text);
            MessageBox.Show(mensaje);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
            Limpiar();
            cargar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            Limpiar();
            cargar();
        }
    }
}
