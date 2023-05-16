using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcolatrice
{
    public partial class Form1 : Form
    {
        private CCalcolatrice calcolatrice;
        public Form1()
        {
            InitializeComponent();
            calcolatrice = new CCalcolatrice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            display.Text += "0";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            display.Text += "1";
        }

        private void numeroPremuto(object sender, EventArgs e)
        {
            Button tmp = sender as Button;
            if (tmp != null)
                display.Text += tmp.Text;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            display.Text += e.KeyChar;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            calcolatrice.PrimoOperando = new CHugeNumber(display.Text);
            calcolatrice.Operazione = CCalcolatrice.Operazioni = CCalcolatrice.Operazioni.somma;

        }

        private void button24_Click(object sender, EventArgs e)
        {
            calcolatrice.SecondoOperando = new CHugeNumber(display.Text);
            switch (calcolatrice.Operazione)
            {
                case CCalcolatrice.Operazioni.somma:
                    calcolatrice.Risultato = calcolatrice.PrimoOperando + calcolatrice.PrimoOperando;
                    break;
                case CCalcolatrice.Operazioni.prodotto:
                    calcolatrice.Risultato = calcolatrice.PrimoOperando * calcolatrice.PrimoOperando;

            }
            display.Text = calcolatrice.Risultato.ToString();
        }
    }
}
