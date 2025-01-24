using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cinecop
{
    public partial class frmCartelera : Cinecop.frmBase
    {
        public frmCartelera()
        {
            InitializeComponent();
        }
        private void usu_Click(object sender, EventArgs e)
        {
            frmInicio invitado = new frmInicio();
            this.Hide();
            invitado.Show();
        }
        private void frmInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void spibtn_Click(object sender, EventArgs e)
        {
            frmAsientos invitado = new frmAsientos();
            this.Hide();
            invitado.Show();
        }
        private void barbtn_Click(object sender, EventArgs e)
        {
            frmAsientos invitado = new frmAsientos();
            this.Hide();
            invitado.Show();
        }
        private void marbtn_Click(object sender, EventArgs e)
        {
            frmAsientos invitado = new frmAsientos();
            this.Hide();
            invitado.Show();
        }
        private void fnafbtn_Click(object sender, EventArgs e)
        {
            frmAsientos invitado = new frmAsientos();
            this.Hide();
            invitado.Show();
        }
        private void sirbtn_Click(object sender, EventArgs e)
        {
            frmAsientos invitado = new frmAsientos();
            this.Hide();
            invitado.Show();
        }
        private void frmAsientos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
