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
    public partial class FrmTramite : Form
    {
        public FrmTramite()
        {
            InitializeComponent();
            this.Load += FrmTramite_Load;
        }
        private void FrmTramite_Load(object sender, EventArgs e)
        {
            CargarComboTipoTramite();
            CargarComboClientes();
            CargarComboEmpleados();
            CargarComboSustancias();
            CargarComboEntidadReguladora();
            ConfigurarControlesIniciales();
        }

        private void ConfigurarControlesIniciales()
        {
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now.AddDays(30);

            // Configurar estados posibles
            cmbEstado.Items.AddRange(new string[] { "Pendiente", "En Proceso", "Finalizado" });
            cmbEstado.SelectedIndex = 0;

            // Configurar unidades de medida
            cmbUnidadMedida.Items.AddRange(new string[] { "Kilogramos", "Litros", "Unidades" });
        }

        private void CargarComboTipoTramite()
        {
            try
            {
                RNTipoTramite objRNTipoTramite = new RNTipoTramite();
                cmbTipoTramite.DataSource = objRNTipoTramite.TraerTipoTramite(0);
                cmbTipoTramite.DisplayMember = "Nombre";
                cmbTipoTramite.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de trámite: " + ex.Message);
            }
        }

        private void CargarComboClientes()
        {
            try
            {
                RNCliente objRNCliente = new RNCliente();
                cmbClienteAsociado.DataSource = objRNCliente.ListarClientes();
                cmbClienteAsociado.DisplayMember = "Nombre";
                cmbClienteAsociado.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void CargarComboEmpleados()
        {
            try
            {
                RNEmpleado objRNEmpleado = new RNEmpleado();
                cmbResponsable.DataSource = objRNEmpleado.ListarEmpleados();
                cmbResponsable.DisplayMember = "Nombre";
                cmbResponsable.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        private void CargarComboSustancias()
        {
            try
            {
                RNSustanciaControlada objRNSustancia = new RNSustanciaControlada();
                cmbSustanciaControlada.DataSource = objRNSustancia.ListarSustancias();
                cmbSustanciaControlada.DisplayMember = "Nombre";
                cmbSustanciaControlada.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sustancias: " + ex.Message);
            }
        }

        private void CargarComboEntidadReguladora()
        {
            try
            {
                RNEntidadReguladora objRNEntidad = new RNEntidadReguladora();
                cmbEntidadReguladora.DataSource = objRNEntidad.ListarEntidades();
                cmbEntidadReguladora.DisplayMember = "Nombre";
                cmbEntidadReguladora.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar entidades reguladoras: " + ex.Message);
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                RNTramite objRNTramite = new RNTramite();

                Tramite objTramite = new Tramite
                {
                    Id = (int)objRNTramite.GenerarId(),
                    IdTipoTramite = (int)cmbTipoTramite.SelectedValue,
                    Descripcion = txtDescripcion.Text.Trim(),
                    IdCliente = (int)cmbClienteAsociado.SelectedValue,
                    IdEmpleado = (int)cmbResponsable.SelectedValue,
                    FechaInicio = dtpFechaInicio.Value,
                    FechaFin = dtpFechaFin.Value,
                    Estado = cmbEstado.Text,
                    Id_Prioridad = 1, // Definir lógica de prioridad si es necesario
                    IdEntidadReguladora = (int)cmbEntidadReguladora.SelectedValue
                };

                // Guardar el trámite
                if (objRNTramite.InsertarTramite(objTramite))
                {
                    // Si es un trámite de sustancia controlada, guardar los detalles
                    if (cmbSustanciaControlada.SelectedValue != null)
                    {
                        TramiteSustancia objTramiteSustancia = new TramiteSustancia
                        {
                            IdTramite = objTramite.Id,
                            IdSustancia = (int)cmbSustanciaControlada.SelectedValue,
                            CantidadSolicitada = decimal.Parse(txtCantidadSolicitada.Text),
                            Justificacion = txtJustificacion.Text,
                            Tipo = "Normal"
                        };

                        // Aquí necesitarías una clase RNTramiteSustancia para manejar esto
                        // RNTramiteSustancia.InsertarTramiteSustancia(objTramiteSustancia);
                    }

                    MessageBox.Show("Trámite registrado exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el trámite: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if (cmbTipoTramite.SelectedIndex == -1 ||
                string.IsNullOrEmpty(txtDescripcion.Text) ||
                cmbClienteAsociado.SelectedIndex == -1 ||
                cmbResponsable.SelectedIndex == -1 ||
                cmbEntidadReguladora.SelectedIndex == -1)
            {
                MessageBox.Show("Debe completar todos los campos obligatorios",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpFechaFin.Value < dtpFechaInicio.Value)
            {
                MessageBox.Show("La fecha de fin no puede ser menor a la fecha de inicio",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarControles()
        {
            cmbTipoTramite.SelectedIndex = -1;
            txtDescripcion.Clear();
            cmbClienteAsociado.SelectedIndex = -1;
            cmbResponsable.SelectedIndex = -1;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now.AddDays(30);
            cmbEstado.SelectedIndex = 0;
            cmbSustanciaControlada.SelectedIndex = -1;
            txtCantidadSolicitada.Clear();
            cmbUnidadMedida.SelectedIndex = -1;
            cmbEntidadReguladora.SelectedIndex = -1;
            txtJustificacion.Clear();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirTramite);

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

        private void ImprimirTramite(object sender, PrintPageEventArgs e)
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
                int currentY = startY;

                // Título principal
                e.Graphics.DrawString("GESTIÓN DE TRÁMITE", titleFont, Brushes.Black,
                    new Rectangle(startX, currentY, e.PageBounds.Width - 100, 30),
                    new StringFormat { Alignment = StringAlignment.Center });
                currentY += offsetY * 2;

                // Datos generales del trámite
                DibujarCampo("Tipo de trámite:", cmbTipoTramite.Text, normalFont, startX, ref currentY, e);
                DibujarCampo("Descripción:", txtDescripcion.Text, normalFont, startX, ref currentY, e);
                DibujarCampo("Cliente Asociado:", cmbClienteAsociado.Text, normalFont, startX, ref currentY, e);
                DibujarCampo("Responsable:", cmbResponsable.Text, normalFont, startX, ref currentY, e);
                DibujarCampo("Fecha de inicio:", dtpFechaInicio.Value.ToShortDateString(), normalFont, startX, ref currentY, e);
                DibujarCampo("Fecha de fin:", dtpFechaFin.Value.ToShortDateString(), normalFont, startX, ref currentY, e);
                DibujarCampo("Estado:", cmbEstado.Text, normalFont, startX, ref currentY, e);

                currentY += offsetY;

                // Sección de Sustancia Controlada
                e.Graphics.DrawString("Detalles de Sustancia Controlada", subtitleFont, Brushes.Black,
                    new Rectangle(startX, currentY, e.PageBounds.Width - 100, 30),
                    new StringFormat { Alignment = StringAlignment.Center });
                currentY += offsetY * 2;

                DibujarCampo("Sustancia:", cmbSustanciaControlada.Text, normalFont, startX, ref currentY, e);
                DibujarCampo("Cantidad Solicitada:", txtCantidadSolicitada.Text, normalFont, startX, ref currentY, e);
                DibujarCampo("Unidad de medida:", cmbUnidadMedida.Text, normalFont, startX, ref currentY, e);
                DibujarCampo("Entidad Reguladora:", cmbEntidadReguladora.Text, normalFont, startX, ref currentY, e);

                currentY += offsetY;

                // Justificación
                e.Graphics.DrawString("Justificación:", normalFont, Brushes.Black, startX, currentY);
                currentY += 25;

                Rectangle justificacionRect = new Rectangle(startX, currentY, e.PageBounds.Width - 100, 100);
                e.Graphics.DrawString(txtJustificacion.Text, normalFont, Brushes.Black, justificacionRect);

                currentY = justificacionRect.Bottom + offsetY * 2;

                // Firmas
                int middleX = e.PageBounds.Width / 2;
                currentY += 50;

                // Línea de firma del solicitante
                e.Graphics.DrawLine(Pens.Black, startX, currentY, startX + 200, currentY);
                e.Graphics.DrawString("Solicitante", normalFont, Brushes.Black, startX + 60, currentY + 10);
                e.Graphics.DrawString("Date:___________", smallFont, Brushes.Black, startX + 50, currentY + 30);

                // Línea de firma del responsable
                e.Graphics.DrawLine(Pens.Black, middleX + 100, currentY, middleX + 300, currentY);
                e.Graphics.DrawString("Responsable", normalFont, Brushes.Black, middleX + 160, currentY + 10);
                e.Graphics.DrawString("Date:___________", smallFont, Brushes.Black, middleX + 170, currentY + 30);

                // Agregar número de trámite en la parte inferior
                currentY += offsetY * 3;
                e.Graphics.DrawString("N° de Trámite: _____________", normalFont, Brushes.Black,
                    new Rectangle(startX, currentY, e.PageBounds.Width - 100, 30),
                    new StringFormat { Alignment = StringAlignment.Center });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message);
            }
        }

        private void DibujarCampo(string label, string valor, Font font, int startX, ref int currentY, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(label, font, Brushes.Black, startX, currentY);
            e.Graphics.DrawString(valor, font, Brushes.Black, startX + 220, currentY);
            currentY += 30;
        }
    }
}