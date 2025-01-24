using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto1.RN;
using Proyecto2.Datos;


namespace Proyecto1.PresentacionEscritorio
{
    public partial class FrmCliente : Form
    {

        public FrmCliente()
        {
            InitializeComponent();
            this.Load += frmCliente_Load;
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            ConfigurarControlesIniciales();
            CargarComboPlanPago();
        }

        private void CargarComboPlanPago()
        {
            try
            {
                RNPlanPago ObjRNPlanPago = new RNPlanPago();
                var planes = ObjRNPlanPago.TraerPlanPago(0);

                if (planes == null || !planes.Any())
                {
                    MessageBox.Show("No se encontraron planes de pago en la base de datos.");
                    return;
                }

                this.cmbPlanPago.DataSource = null; // Limpiar primero
                this.cmbPlanPago.DataSource = planes;
                this.cmbPlanPago.ValueMember = "Id";
                this.cmbPlanPago.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar planes de pago: {ex.Message}\n\nDetalles: {ex.InnerException?.Message}");
            }
        }

        private void ConfigurarControlesIniciales()
        {
            // Configurar DateTimePicker
            dtpFechaRegistro.Format = DateTimePickerFormat.Short;
            dtpFechaRegistro.Value = DateTime.Now;
            dtpFechaRegistro.Enabled = false;

            // Configurar validaciones en tiempo real
            txtEmail.Leave += ValidarEmail;
            txtNit.Leave += ValidarNIT;
        }

        private void ValidarEmail(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                RNCliente objRNCliente = new RNCliente();
                if (objRNCliente.ExisteEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("El email ya está registrado", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                }
            }
        }

        private void ValidarNIT(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNit.Text))
            {
                RNCliente objRNCliente = new RNCliente();
                if (objRNCliente.ExisteNIT(txtNit.Text.Trim()))
                {
                    MessageBox.Show("El NIT ya está registrado", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNit.Focus();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                RNCliente objRNCliente = new RNCliente();

                // Crear objeto Cliente
                Cliente objCliente = new Cliente
                {
                    Id = (int)objRNCliente.GenerarId(),
                    Direccion = txtDireccion.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Nit = txtNit.Text.Trim(),
                    FechaRegistro = DateTime.Now,
                    TipoCliente = "Juridico",
                    IdPlanPago = (int)cmbPlanPago.SelectedValue  // Agregamos el IdPlanPago directamente
                };

                // Crear objeto ClienteJuridico
                ClienteJuridico objClienteJuridico = new ClienteJuridico
                {
                    Nombre = txtNombre.Text.Trim(),
                    RazonSocial = txtRazonSocial.Text.Trim(),
                    NIT = txtNit.Text.Trim(),
                    NroPadron = txtNroPatron.Text.Trim(),
                    RepresentanteLegal = txtRepresentanteLegal.Text.Trim()
                };

                if (objRNCliente.InsertarClienteJuridico(objCliente, objClienteJuridico))
                {
                    MessageBox.Show("Cliente registrado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                }
                else
                {
                    MessageBox.Show("Error al registrar el cliente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtNit.Text) ||
                string.IsNullOrEmpty(txtRazonSocial.Text) ||
                string.IsNullOrEmpty(txtNroPatron.Text) ||
                string.IsNullOrEmpty(txtRepresentanteLegal.Text) ||
                cmbPlanPago.SelectedIndex == -1)
            {
                MessageBox.Show("Debe completar todos los campos obligatorios",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtNit.Clear();
            txtRazonSocial.Clear();
            txtNroPatron.Clear();
            txtRepresentanteLegal.Clear();
            txtCuentaBancaria.Clear();
            cmbPlanPago.SelectedIndex = -1;
            dtpFechaRegistro.Value = DateTime.Now;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de impresión en desarrollo", "Aviso");
        }

        private void BtnImprimir_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("No hay datos de cliente para imprimir", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(ImprimirKardexCliente);

                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                printPreviewDialog1.Document = pd;
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar vista previa: " + ex.Message);
            }
        }

        private void ImprimirKardexCliente(object sender, PrintPageEventArgs e)
        {
            try
            {
                // Configuración de fuentes
                Font titleFont = new Font("Arial", 14, FontStyle.Bold);
                Font headerFont = new Font("Arial", 10, FontStyle.Bold);
                Font normalFont = new Font("Arial", 10, FontStyle.Regular);

                // Medidas y posiciones
                int startX = 50;
                int startY = 50;
                int cellHeight = 30;
                int cellWidth = 120;

                // Título del Kardex
                e.Graphics.DrawString("Kardex Cliente Jurídico", titleFont, Brushes.Black,
                    new Rectangle(startX, startY, e.PageBounds.Width - 100, 30),
                    new StringFormat { Alignment = StringAlignment.Center });

                startY += 50;

                // Dibujar encabezados de la tabla
                string[] headers = { "Nombre", "Nit", "RazonSocial", "Direccion", "Telefono", "Email" };
                int currentX = startX;

                // Dibujar línea superior de la tabla
                e.Graphics.DrawLine(Pens.Black, startX, startY, startX + (cellWidth * headers.Length), startY);

                // Dibujar encabezados
                for (int i = 0; i < headers.Length; i++)
                {
                    Rectangle cellRect = new Rectangle(currentX, startY, cellWidth, cellHeight);
                    e.Graphics.DrawRectangle(Pens.Black, cellRect);
                    e.Graphics.DrawString(headers[i], headerFont, Brushes.Black,
                        cellRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    currentX += cellWidth;
                }

                // Dibujar datos del cliente
                currentX = startX;
                startY += cellHeight;

                string[] datos = {
            txtNombre.Text.Trim(),
            txtNit.Text.Trim(),
            txtRazonSocial.Text.Trim(),
            txtDireccion.Text.Trim(),
            txtTelefono.Text.Trim(),
            txtEmail.Text.Trim()
        };

                // Dibujar celdas de datos
                for (int i = 0; i < datos.Length; i++)
                {
                    Rectangle cellRect = new Rectangle(currentX, startY, cellWidth, cellHeight);
                    e.Graphics.DrawRectangle(Pens.Black, cellRect);
                    e.Graphics.DrawString(datos[i], normalFont, Brushes.Black,
                        new Rectangle(currentX + 5, startY + 5, cellWidth - 10, cellHeight - 10));
                    currentX += cellWidth;
                }

                // Dibujar línea inferior de la tabla
                e.Graphics.DrawLine(Pens.Black, startX, startY + cellHeight,
                    startX + (cellWidth * headers.Length), startY + cellHeight);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message);
            }
        }
    }
}