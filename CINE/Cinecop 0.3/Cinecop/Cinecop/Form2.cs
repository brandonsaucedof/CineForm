using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cinecop
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea salir de la aplicacion?", "Aviso", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnInvitado_Click(object sender, EventArgs e)
        {
            frmCartelera invitado = new frmCartelera();
            this.Hide();
            invitado.Show();
        }
        private void frmCartelera_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void frmInicio_Load(object sender, EventArgs e)
        {

        }
    }
}
