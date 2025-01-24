using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinecop
{
    public partial class frmCompra : Form
    {
        public frmCompra()
        {
            InitializeComponent();
        }
        public int numDig = 8;
        public double creditNumbers;
        public string fec;
        public int co;
        static public int numA=Class1.numConfi;

        private void button2_Click(object sender, EventArgs e)
        {
            frmAsientos Asientos = new frmAsientos();
            this.Hide();
            Asientos.Show();
        }
        static public int f = frmAsientos.F;
        private void button1_Click(object sender, EventArgs e)
        {
            if (tarjetaCredito.Text.Length == 8 && fechaVen.Text.Length==5 && cod.Text.Length==3)
            {
                creditNumbers = double.Parse(tarjetaCredito.Text);
                fec = fechaVen.Text;
                co = int.Parse(cod.Text);
                MessageBox.Show("jaja ya te robe la tarjeta.");

                frmAsientos.numAsientoMarcados= frmAsientos.asientos;
                frmAsientos.r = 0;
                
            }
            else { 
                MessageBox.Show("   uno de los datos que proporciono no es valido    ");
                MessageBox.Show("                        .....                       ");
                MessageBox.Show("no me pidas que te diga cual porque nmms que flojera");
            }

        }
    }
}
