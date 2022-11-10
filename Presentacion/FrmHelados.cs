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
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Presentacion
{
    public partial class FrmHelados : Form
    {
        public FrmHelados()
        {
            InitializeComponent();
        }

        Helado helado = new Helado();
        ServicioHelados servicioHelados = new ServicioHelados();

        void guardar()
        {

            helado.Codigo = TxtCodigo.Text;
            helado.NombreHelado = textHelado.Text;
            helado.Categoria = CobCategoria.Text;
            helado.Cantidad = int.Parse(txtCant.Text);
            helado.PrecioHelado = int.Parse(txtPrecio.Text);


            string mensaje;
            mensaje = servicioHelados.Guardar(helado);

            MessageBox.Show(mensaje);
        }

        void Cargar()
        {
            dataListadoH.DataSource = servicioHelados.GetAll();
        }

        void Buscar(string Cod)
        {

            Helado helado;
            helado = servicioHelados.BuscarID(Cod);
            if (helado == null)
            {
                MessageBox.Show("No se encuentra el cliente en nuestro sistema");
                return;
            }
            Ver(helado);
        }

        void Ver(Helado helado)
        {
            TxtCodigo.Text = helado.Codigo;
            textHelado.Text = helado.NombreHelado;
            CobCategoria.Text = helado.Categoria;
            txtCant.Text = Convert.ToString(helado.Cantidad);
            txtPrecio.Text = Convert.ToString(helado.PrecioHelado); 

        }

        void Limpiar()
        {
            TxtCodigo.Clear();
            textHelado.Clear();
            CobCategoria.Items.Clear();
            txtCant.Clear();
            txtPrecio.Clear();

        }
        private void btnenlace_clientes_Click(object sender, EventArgs e)
        {

        }
        int toltal;
        void calculo(int can, int pre)
        {
            can = Convert.ToInt32(txtCant.Text);
            pre = Convert.ToInt32(txtPrecio.Text);

            toltal = can * pre;
            lblTotal.Text = toltal.ToString();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            calculo(int.Parse(txtCant.Text), int.Parse(txtPrecio.Text));
            guardar();
            Factura();
            Cargar();
            Limpiar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(TxtCodigo.Text);
        }

        private void FrmHelados_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        void Modificar()
        {
            if (helado == null)
            {
                MessageBox.Show("No se Encuentra Registrado el helado");
            }
            helado.Codigo = TxtCodigo.Text;
            helado.NombreHelado = textHelado.Text;
            helado.Categoria = CobCategoria.Text;
            helado.Cantidad = Convert.ToInt16(txtCant.Text);
            helado.PrecioHelado = Convert.ToInt32(txtPrecio.Text);
            string mensaje;
            mensaje = servicioHelados.Modificar(helado);
            MessageBox.Show(mensaje);
        }

        void Eliminar()
        {
            if (helado == null)
            {
                MessageBox.Show("No se Encuentra Registrado el helado");
            }

            string mensaje;
            mensaje = servicioHelados.Eliminar(TxtCodigo.Text);
            MessageBox.Show(mensaje);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
            Limpiar();
            Cargar();
        }
        void Factura()
        {
            FacturaTick.CreaTicket Ticket1 = new FacturaTick.CreaTicket();

            Ticket1.TextoCentro("Heladeria Mario Sosa "); //imprime una linea de descripcion
            Ticket1.TextoCentro("**********************************");


            Ticket1.TextoCentro("Factura de Venta"); //imprime una linea de descripcion
            //Ticket1.TextoIzquierda("No Fac:" + ClassBT.clsDetallesVenta.IdVentafk.ToString());
            Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
            Ticket1.TextoIzquierda("Le Atendio: Mario Sosa");
            Ticket1.TextoIzquierda("");
            FacturaTick.CreaTicket.LineasGuion();

            //FacturaTick.CreaTicket.EncabezadoVenta();
            Ticket1.AgregaTotales("Codigo de Helado", TxtCodigo.Text);
            Ticket1.AgregaTotales("Efectivo Entregado:", txtPrecio.Text);
            Ticket1.AgregaTotales("Cantidad De Eladoas:", txtCant.Text);
            //Ticket1.AgregaTotales();
            FacturaTick.CreaTicket.LineasGuion();
            foreach (DataGridViewRow r in dataListadoH.Rows)
            {
                // PROD                     //PrECIO                                    CANT                         TOTAL
                Ticket1.AgregaArticulo(r.Cells[0].Value.ToString(), (r.Cells[1].Value.ToString()), (r.Cells[2].Value.ToString()), int.Parse(r.Cells[3].Value.ToString()), int.Parse(r.Cells[4].Value.ToString())); //imprime una linea de descripcion
            }

            Ticket1.AgregaTotales("Total de Pago", lblTotal.Text);

            FacturaTick.CreaTicket.LineasGuion();

            //Ticket1.AgregaTotales("Total", double.Parse(lblCostoApagar.Text)); // imprime linea con total
            Ticket1.TextoIzquierda(" ");
            Ticket1.AgregaTotales("Efectivo Entregado:", txtPrecio.Text);
            Ticket1.AgregaTotales("Cantidad De Eladoas:", txtCant.Text);



            // Ticket1.LineasTotales(); // imprime linea 

            Ticket1.TextoIzquierda(" ");
            Ticket1.TextoCentro("**********************************");
            Ticket1.TextoCentro("*     Gracias por preferirnos    *");

            Ticket1.TextoCentro("**********************************");
            Ticket1.TextoIzquierda(" ");
            string impresora = "Microsoft XPS Document Writer";
            Ticket1.ImprimirTiket(impresora);




            //Fila = 0;
            //while (dataListadoH.RowCount > 0)//limpia el dgv
            //{ dataListadoH.Rows.Remove(dataListadoH.CurrentRow); }
            //LBLIDnuevaFACTURA.Text = ClaseFunciones.ClsFunciones.IDNUEVAFACTURA().ToString();

            //txtIdProducto.Text = lblNombre.Text = txtCantidad.Text = textBox3.Text = "";
            //lblCostoApagar.Text = lbldevolucion.Text = lblPrecio.Text = "0";
            //txtIdProducto.Focus();
            MessageBox.Show("Gracias por preferirnos");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            Limpiar();
            Cargar();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            

        }

        private void prueba_Click(object sender, EventArgs e)
        {
            //calculo(int.Parse(txtCant.Text), int.Parse(txtPrecio.Text));
        }
    }
}
