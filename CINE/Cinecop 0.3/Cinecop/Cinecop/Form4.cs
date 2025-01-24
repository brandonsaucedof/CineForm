using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace Cinecop
{
    public partial class frmAsientos : Cinecop.frmBase
    {
        private bool buttonSelected = false;
        public frmAsientos()
        {
            InitializeComponent();
            result = 0;
            for(int contador=0; contador < y.Length; contador++)
            {
                if (y[contador] == 100)
                {
                    button2.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button3.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button4.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button5.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button6.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button7.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button8.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button9.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button10.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button11.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button21.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button20.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button19.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button18.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button17.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button16.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button15.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button14.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button13.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button12.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button31.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button30.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button29.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button28.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button27.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button26.BackColor = Color.Red;
                }
                if(y[contador] == 100)
                {
                    button25.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button24.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button23.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button22.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button41.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button40.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button39.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button38.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button37.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button36.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button35.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button34.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button33.BackColor = Color.Red;
                }
                if (y[contador] == 100)
                {
                    button32.BackColor = Color.Red;
                }

            }
            
               
        }

        static public int x=100;
        static public int F;
        static public bool confir = false;
        static public int[] asientos=new int[40];
        static public int[] numAsientoMarcados = new int[40];
        static public int cont = 0;
        static public int lol = 0;
        public int conta = 0;
        static public int r = 0;
        static public int result;
        static public int precio;
        static public int[] asi;
        static public int contadorAsientos=0;
        static public int[] y = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39};
        static public int[] yF = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 };


        private void ToggleButtonColor(Button button)
        {
            if (buttonSelected)
            {
                button.BackColor = Color.Lime;
            }
            else
            {
                button.BackColor = Color.Red;
            }
            buttonSelected = !buttonSelected;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            /*Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);*/
            x = 0; /*numero de asiento*/
            button3.BackColor = Color.Lime;
            if (y[x] == 100)
            {
                button3.BackColor = Color.Red;
            }
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
            cont = 1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            /*Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);*/
            button3.BackColor= Color.Lime;
            x = 1;
            if (y[x] == 100)
            {
                button3.BackColor = Color.Red;
            }
            numeroAsiento.Text = Convert.ToString(x);
            F = x;
            
            asientos[r] = x;
            result = (r+1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
            cont=2;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 2;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
            cont = 3;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 3;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 4;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 5;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 6;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 7;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 8;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 9;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button21_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 10;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button20_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 11;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button19_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 12;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 13;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 14;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 15;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 16;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button14_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 17;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 18;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 19;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button31_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 20;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button30_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 21;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button29_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
                x = 22;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button28_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 23;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button27_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 24;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button26_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 25;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button25_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
                x = 26;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button24_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 27;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button23_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 28;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button22_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 29;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button41_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 30;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button40_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 31;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button39_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 32;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button38_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 33;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button37_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 34;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button36_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 35;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button35_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 36;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = (r + 1) * 21;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button34_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 37;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = ((r + 1) * 21) -r;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button33_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 38;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = ((r + 1) * 21);
            precioTotal.Text = Convert.ToString(result);
            r++;
        }
        private void button32_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            ToggleButtonColor(clickedButton);
            x = 39;
            numeroAsiento.Text = Convert.ToString(x);
            asientos[r] = x;
            result = ((r + 1) * 21) ;
            precioTotal.Text = Convert.ToString(result);
            r++;
        }

        private void usu_Click(object sender, EventArgs e)
        {
            frmCartelera invitado = new frmCartelera();
            this.Hide();
            invitado.Show();

        }
        private void frmCartelera_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int contador = 0;
            lol = r;
           frmCompra compra=new frmCompra();
            this.Hide();
            compra.Show();
            
        }

        private void actualizar_Click(object sender, EventArgs e)
        {


            for(int contador=0; contador < y.Length; contador++)
            {  
                

                if (y[x] == 100)
                {
                    MessageBox.Show("asiento ya reservado");
                    break;
                }
                
                if (y[x] == 0)
                {
                    button2.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 1)
                {
                    button3.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 2)
                {
                    button4.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 3)
                {
                    button5.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 4)
                {
                    button6.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 5)
                {
                    button7.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 6)
                {
                    button8.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 7)
                {
                    button9.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 8)
                {
                    button10.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 9)
                {
                    button11.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 10)
                {
                    button21.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 11)
                {
                    button20.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 12)
                {
                    button19.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 13)
                {
                    button18.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 14)
                {
                    button17.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 15)
                {
                    button16.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 16)
                {
                    button15.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 17)
                {
                    button14.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 18)
                {
                    button13.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 19)
                {
                    button12.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 20)
                {
                    button31.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 21)
                {
                    button30.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 22)
                {
                    button29.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 23)
                {
                    button28.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 24)
                {
                    button27.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 25)
                {
                    button26.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 26)
                {
                    button25.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 27)
                {
                    button24.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 28)
                {
                    button23.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 29)
                {
                    button22.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 30)
                {
                    button41.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 31)
                {
                    button40.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 32)
                {
                    button39.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 33)
                {
                    button38.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 34)
                {
                    button37.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 35)
                {
                    button36.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 36)
                {
                    button35.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 37)
                {
                    button34.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 38)
                {
                    button33.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                if (y[x] == 39)
                {
                    button32.BackColor = Color.Red;
                    y[x] = 100;
                    break;
                }
                

            }


            
            



        }

        private void quitarReserva_Click(object sender, EventArgs e)
        {
            for (int contador = 0; contador < y.Length; contador++)
            {


                

                if (y[x] == 100)
                {
                    button2.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button3.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button4.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button5.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button6.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button7.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button8.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button9.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == x)
                {
                    button10.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button11.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button21.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button20.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button19.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button18.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button17.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button16.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button15.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button14.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button13.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button12.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button31.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button30.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button29.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button28.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button27.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button26.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button25.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button24.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button23.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button22.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button41.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button40.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button39.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button38.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button37.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button36.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button35.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button34.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button33.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }
                if (y[x] == 100)
                {
                    button32.BackColor = Color.Lime;
                    y[x] = x;
                    break;
                }


            }
        }
    }
}