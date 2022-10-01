using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mercado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int cod=0, qtd=0;
        float valorUn=0, valorfinal, desconto=5F, acrecimo=30F, resultado1, resultado2;

        

        private bool mover;
        private int cX, cY;

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mover = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Left += e.X - (cX - panel1.Left);
                this.Top += e.Y - (cY - panel1.Top);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cX = e.X;
                cY = e.Y;
                mover = true;
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.WindowState = FormWindowState.Minimized;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cb_vista.Checked == false && cb_credito.Checked == false)
            {
             
                MessageBox.Show("Selecione um método de pagamento", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            if(cb_vista.Checked == true && cb_credito.Checked == true)
            {
                
                MessageBox.Show("Cálculo interrompido", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Selecione APENAS um método de pagamento", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tb_codigo.Text = "";
                tb_qtd.Text = "";
                tb_valorUn.Text = "";
                tb_totalcredito.Text = "";
                tb_totalvista.Text = "";
                tb_resultado.Text = "";
                cb_credito.Checked = false;
                cb_vista.Checked = false;
                label7.Visible = false;
                tb_resultado.Visible = false;
                label8.Visible = false;
                tb_resultado1.Visible = false;

                
            }

            if(tb_codigo.Text == "" || tb_qtd.Text == "" || tb_valorUn.Text == "")
            {
                MessageBox.Show("Há espaços sem preencher", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(tb_codigo.Text == "" && tb_qtd.Text == "" && tb_valorUn.Text == "")
            {
                MessageBox.Show("Nada foi preenchido", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cb_vista.Checked == true)
            {
                valorUn = float.Parse(tb_valorUn.Text);
                qtd = int.Parse(tb_qtd.Text);

                resultado1 = qtd * valorUn;
                resultado2 = resultado1 * (desconto / 100);
                
                valorfinal = resultado1 - resultado2;

                tb_totalvista.Text = valorfinal.ToString("C");
                tb_resultado.Text = resultado2.ToString("C");

                tb_resultado1.Text = resultado1.ToString("C");

                label7.Text = "Desconto";
                label7.Visible = true;
                tb_resultado.Visible = true;
                label8.Visible = true;
                tb_resultado1.Visible = true;

            }

            else if(cb_credito.Checked == true)
            {
                valorUn = float.Parse(tb_valorUn.Text);
                qtd = int.Parse(tb_qtd.Text);

                resultado1 = qtd * valorUn;
                resultado2 = resultado1 * (acrecimo / 100);
                valorfinal = resultado1 + resultado2;

                

                tb_resultado1.Text = resultado1.ToString("C");

                tb_totalcredito.Text = valorfinal.ToString("C");
                tb_resultado.Text = resultado2.ToString("C");

                label7.Text = "Acréscimo";
                label7.Visible = true;
                tb_resultado.Visible = true;
                label8.Visible = true;
                tb_resultado1.Visible = true;



            }
            


        }

        private void cb_vista_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_vista.Checked == true)
            {
                
                MessageBox.Show("Para pagamento a vista --> 5% desconto", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                
            }

        }

        private void cb_credito_CheckedChanged(object sender, EventArgs e)
        {
            
            if (cb_credito.Checked == true)
            {
                
                MessageBox.Show("Pagamento crédito taxa de 30%", "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
               
            }

        }

        private void bt_limpar_Click(object sender, EventArgs e)
        {
            tb_codigo.Text = "";
            tb_qtd.Text = "";
            tb_valorUn.Text = "";
            tb_totalcredito.Text = "";
            tb_totalvista.Text = "";
            tb_resultado.Text = "";
            cb_credito.Checked = false;
            cb_vista.Checked = false;
            label7.Visible = false;
            tb_resultado.Visible = false;
            label8.Visible = false;
            tb_resultado1.Visible = false;

        }

        

        private void bt_fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
 
    }
}
