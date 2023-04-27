/* 
Scrivere un programma che riesce a stampare un 
numero molto grande (esempio: con 300 cifre).
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Frazioni
{
    class CHugeNumber
    {
        private const int N = 300;
        private int[] mCifre;

        public int[] Cifre
        {
            get { return mCifre; }
            set { mCifre = value; }
        }

        public CHugeNumber()
        {
            // metti un puntatore a un oggetto che è un vettore di tipo int
            Cifre = new int[N]; // cosi' si crea anche un vettore con 0 in tutte le celle
        }
        // usiamo una stringa perche' puo' possedere piu' caratteri di un int, double, ecc.
        public CHugeNumber(string numero)
        {
            Cifre = new int[N];
            if (numero.Length < N) {
                for (int i = 0; i < numero.Length; i++)
                {
                    // Cifre[N - i - 1] = numero[numero.Length - i - 1] - "0";
                    Cifre[N - i - 1] = Convert.ToInt32(numero[i]) - 48;
                }
            }   else {
                    throw new InvalidOperationException();
                }
        }
        
        // Somma
        public static CHugeNumber operator +(CHugeNumber n1, CHugeNumber n2){
            // si crea l'array con lunghezza N tramite il costruttore public CHugeNumber()
            CHugeNumber risultato = new CHugeNumber();

            int Riporto = 0;

            for (int i = N - 1; i >= 0; i--)
            {
                risultato.Cifre[i] = n1.Cifre[i] + n2.Cifre[i] + Riporto;
                    if (risultato.Cifre[i] > 9)
                    {
                        Riporto = 1;
                        risultato.Cifre[i] -= 10;
                        // Controllo overflow
                        if (i == 0)
                            throw new OverflowException();
                    } else
                        Riporto = 0;
                    }
            return risultato;
        }

        // Sottrazione
        public static CHugeNumber operator -(CHugeNumber n1, CHugeNumber n2){
            CHugeNumber risultato = new CHugeNumber();

            risultato = n1 + n2.complemento();
            return risultato;
        }
        private CHugeNumber complemento()
        {
            CHugeNumber risultato = new CHugeNumber();
            CHugeNumber uno = new CHugeNumber("+1");

            for (int i = N - 1; i >= 0; i--)
            {
                risultato.Cifre[i] = 9 - this.Cifre[i];
            }
            return risultato + uno;
        }

    }
}