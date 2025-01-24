using Proyecto1.RN;
using Proyecto2.Datos;
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

namespace Proyecto1.PresentacionEscritorio
{
    public partial class FrmContrato : Form
    {
        public FrmContrato()
        {
            InitializeComponent();
            this.Load += FrmContrato_Load;
        }
        private void FrmContrato_Load(object sender, EventArgs e)
        {
            CargarComboCliente();
            ConfigurarControlesIniciales();
        }

        private void ConfigurarControlesIniciales()
        {
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now.AddMonths(12);
            txtEstado.Text = "Activo";
            txtEstado.Enabled = false;
        }

        private void CargarComboCliente()
        {
            try
            {
                RNCliente objRNCliente = new RNCliente();
                cmbCliente.DataSource = objRNCliente.ListarClientes();
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }



        private bool ValidarCampos()
        {
            if (cmbCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtVolumenActividad.Text) ||
                string.IsNullOrEmpty(txtCosto.Text) ||
                string.IsNullOrEmpty(txtClausula.Text))
            {
                MessageBox.Show("Debe completar todos los campos obligatorios", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal volumen, costo;
            if (!decimal.TryParse(txtVolumenActividad.Text, out volumen) ||
                !decimal.TryParse(txtCosto.Text, out costo))
            {
                MessageBox.Show("Los valores numéricos no son válidos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpFechaFin.Value <= dtpFechaInicio.Value)
            {
                MessageBox.Show("La fecha de fin debe ser posterior a la fecha de inicio", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarControles()
        {
            cmbCliente.SelectedIndex = -1;
            txtVolumenActividad.Clear();
            txtCosto.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now.AddMonths(12);
            txtClausula.Clear();
            txtEstado.Text = "Activo";
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
        }

        private void DibujarCampo(string label, string valor, Font font, int startX, ref int currentY, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(label, font, Brushes.Black, startX, currentY);
            e.Graphics.DrawString(valor, font, Brushes.Black, startX + 220, currentY);
            currentY += 30;
        }
    

    private void BtnGuardar_Click_1(object sender, EventArgs e)
        {
            {
                try
                {
                    if (!ValidarCampos())
                        return;

                    RNContrato objRNContrato = new RNContrato();

                    Contrato objContrato = new Contrato
                    {
                        Id = (int)objRNContrato.GenerarId(),
                        IdCliente = (int)cmbCliente.SelectedValue,
                        VolumenActividad = decimal.Parse(txtVolumenActividad.Text),
                        Costo = decimal.Parse(txtCosto.Text),
                        Estado = txtEstado.Text,
                        FechaInicio = dtpFechaInicio.Value,
                        FechaFin = dtpFechaFin.Value,
                        Clausula = txtClausula.Text
                    };

                    if (objRNContrato.ValidarContrato(objContrato))
                    {
                        if (objRNContrato.InsertarContrato(objContrato))
                        {
                            MessageBox.Show("Contrato registrado exitosamente", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarControles();
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar el contrato", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(ImprimirContrato);

                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                printPreviewDialog1.Document = pd;

                try
                {
                    printPreviewDialog1.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al mostrar vista previa: " + ex.Message);
                }
            }

            private void ImprimirContrato(object sender, PrintPageEventArgs e)
            {
                try
                {
                    // Configuración de fuentes
                    Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                    Font subtitleFont = new Font("Arial", 14, FontStyle.Bold);
                    Font normalFont = new Font("Arial", 12, FontStyle.Regular);
                    Font smallFont = new Font("Arial", 10, FontStyle.Regular);

                    // Configuración de espaciado
                    int startX = 50;
                    int startY = 50;
                    int offsetY = 30;
                    int labelWidth = 200;
                    int currentY = startY;

                    // Título principal
                    e.Graphics.DrawString("Contrato", titleFont, Brushes.Black,
                        new Rectangle(startX, currentY, e.PageBounds.Width - 100, 30),
                        new StringFormat { Alignment = StringAlignment.Center });
                    currentY += offsetY * 2;

                    // Primera sección - Datos del Contrato
                    DibujarCampo("Cliente:", cmbCliente.Text, normalFont, startX, ref currentY, e);
                    DibujarCampo("Volumen de actividad:", txtVolumenActividad.Text, normalFont, startX, ref currentY, e);
                    DibujarCampo("Costo:", txtCosto.Text + "Bs", normalFont, startX, ref currentY, e);
                    DibujarCampo("Estado:", txtEstado.Text, normalFont, startX, ref currentY, e);
                    DibujarCampo("Fecha inicio:", dtpFechaInicio.Value.ToShortDateString(), normalFont, startX, ref currentY, e);
                    DibujarCampo("Fecha Fin:", dtpFechaFin.Value.ToShortDateString(), normalFont, startX, ref currentY, e);

                    currentY += offsetY;

                    // Subtítulo Cliente Jurídico
                    e.Graphics.DrawString("Cliente jurídico", subtitleFont, Brushes.Black,
                        new Rectangle(startX, currentY, e.PageBounds.Width - 100, 30),
                        new StringFormat { Alignment = StringAlignment.Center });
                    currentY += offsetY * 2;

                    // Sección Cliente Jurídico
                    RNCliente objRNCliente = new RNCliente();
                    var clienteJuridico = objRNCliente.BuscarClienteJuridicoPorId((int)cmbCliente.SelectedValue);

                    DibujarCampo("Razón social:", clienteJuridico.RazonSocial, normalFont, startX, ref currentY, e);
                    DibujarCampo("Nro. Padrón:", clienteJuridico.NroPadron, normalFont, startX, ref currentY, e);
                    DibujarCampo("Representante Legal:", clienteJuridico.RepresentanteLegal, normalFont, startX, ref currentY, e);

                    currentY += offsetY;

                    // Cláusula
                    e.Graphics.DrawString("Clausula:", normalFont, Brushes.Black, startX, currentY);
                    currentY += 25;

                    // Dibujar cláusula con wrap de texto
                    Rectangle clausulaRect = new Rectangle(startX, currentY, e.PageBounds.Width - 100, 200);
                    e.Graphics.DrawString(txtClausula.Text, normalFont, Brushes.Black, clausulaRect);

                    currentY = clausulaRect.Bottom + offsetY * 2;

                    // Firmas
                    int middleX = e.PageBounds.Width / 2;
                    currentY += 50;

                    // Línea de firma cliente
                    e.Graphics.DrawLine(Pens.Black, startX, currentY, startX + 200, currentY);
                    e.Graphics.DrawString("Cliente", normalFont, Brushes.Black, startX + 70, currentY + 10);
                    e.Graphics.DrawString("Date:___________", smallFont, Brushes.Black, startX + 50, currentY + 30);

                    // Línea de firma consultora
                    e.Graphics.DrawLine(Pens.Black, middleX + 100, currentY, middleX + 300, currentY);
                    e.Graphics.DrawString("Consultora Asemax", normalFont, Brushes.Black, middleX + 150, currentY + 10);
                    e.Graphics.DrawString("Date:___________", smallFont, Brushes.Black, middleX + 170, currentY + 30);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al imprimir: " + ex.Message);
                }
            }
        }
    }
