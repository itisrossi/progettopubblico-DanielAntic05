using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
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
        String operation = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
            calcolatrice = new CCalcolatrice();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    display.Text += "0";
        //}

        //private void button18_Click(object sender, EventArgs e)
        //{
        //    display.Text += "1";
        //}
        //per inserire i numeri, in questo modo non devo scrivere per ogni bottone cosa far vedere
        //nel display
        private void numeroPremuto(object sender, EventArgs e)
        {
            //canellare lo zero dopo aver inserito un numero
            if (display.Text == "0" || isOperationPerformed)
                display.Clear();

            isOperationPerformed = false;
            Button tmp = sender as Button;

            if (tmp != null)
                display.Text += tmp.Text;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            display.Text += e.KeyChar;

        }
        //operazioni
        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            // segno
            operation = button.Text;
            // prendo il primo numero dall'display
            calcolatrice.PrimoOperando = new CHugeNumber(display.Text);
            labelCurrentOperation.Text = calcolatrice.PrimoOperando + " " + operation;
            isOperationPerformed = true;
            //calcolatrice.Operazione = /*CCalcolatrice.Operazioni =*/ CCalcolatrice.Operazioni.somma;
        }
        private void button24_Click(object sender, EventArgs e)
        {
            // prendo il secondo numero dal display
            calcolatrice.SecondoOperando = new CHugeNumber(display.Text);
            switch (operation)
            {
                case /*CCalcolatrice.Operazioni.somma*/ "+":
                    calcolatrice.Risultato = calcolatrice.PrimoOperando + calcolatrice.SecondoOperando;
                    break;

                case /*CCalcolatrice.Operazioni.prodotto*/ "*":
                    calcolatrice.Risultato = calcolatrice.PrimoOperando * calcolatrice.SecondoOperando;
                    break;

                case /*CCalcolatrice.Operazioni.prodotto*/ "-":
                    calcolatrice.Risultato = calcolatrice.PrimoOperando - calcolatrice.SecondoOperando;
                    break;

                case /*CCalcolatrice.Operazioni.prodotto*/ "/":
                    calcolatrice.Risultato = calcolatrice.PrimoOperando / calcolatrice.SecondoOperando;
                    break;

                /*case "√":
                    calcolatrice.Risultato = CHugeNumber.sqrt(calcolatrice.PrimoOperando);
                    break;*/

                default:
                    break;
            }
            display.Text = calcolatrice.Risultato.ToString();
        }
        // CE
        private void button3_Click(object sender, EventArgs e)
        {
            display.Text = "0";
        }
        // C
        private void button4_Click(object sender, EventArgs e)
        {
            display.Text = "0";
            labelCurrentOperation.Text = "";
            //resultValue = "0";
        }

        private void canc_Click(object sender, EventArgs e)
        {
            if (display.Text.Length > 1)
                display.Text = display.Text.Remove(display.Text.Length - 1);
            else
                display.Text = "0";
        }

        private void click_sqrt(object sender, EventArgs e)
        {
            calcolatrice.PrimoOperando = new CHugeNumber(display.Text);
            calcolatrice.Risultato = CHugeNumber.sqrt(calcolatrice.PrimoOperando);
            display.Text = calcolatrice.Risultato.ToString();
        }
    }
}
