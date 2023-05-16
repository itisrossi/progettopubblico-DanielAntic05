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
            char[] stringArray = numero.ToCharArray();
            Array.Reverse(stringArray);
            numero = new string(stringArray);
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
                            // throw new OverflowException();
                            Riporto = 0;
                    } else
                        Riporto = 0;
            }
            return risultato;
        }

        // Sottrazione
        public static CHugeNumber operator -(CHugeNumber n1, CHugeNumber n2){
            CHugeNumber risultato = new CHugeNumber();

            risultato = n1 + n2.complemento();

            if (risultato.Cifre[0] == 9)
            {
                risultato = risultato.complemento();
                for (int i = 0; i < risultato.Cifre.Length && risultato.Cifre[i] == 0; i++)
                {
                    if (i + 1 < risultato.Cifre.Length && risultato.Cifre[i + 1] != 0)
                        risultato.Cifre[i + 1] = 0 - risultato.Cifre[i + 1];
                }
                return risultato;
            }
            else
            {
                return risultato;
            }
        }
        private CHugeNumber complemento()
        {
            CHugeNumber risultato = new CHugeNumber();
            CHugeNumber uno = new CHugeNumber("1");

            for (int i = N - 1; i >= 0; i--)
            {
                risultato.Cifre[i] = 9 - this.Cifre[i];
            }
            return risultato + uno;
        }
        public static CHugeNumber operator * (CHugeNumber n1, CHugeNumber n2)
        {
            CHugeNumber ris = new CHugeNumber();
            CHugeNumber uno = new CHugeNumber("1");
            CHugeNumber zero = new CHugeNumber("0");
            while (compare(n2, zero) == true)
            {
                ris += n1;
                n2 = n2 - uno;
            }
            return ris;
        }

        public static CHugeNumber operator / (CHugeNumber n1, CHugeNumber n2)
        {
            CHugeNumber ris = new CHugeNumber("0");
            CHugeNumber uno = new CHugeNumber("1");
            CHugeNumber zero = new CHugeNumber("0");
            if (compare(n2, n1) == true)
            {
                return ris;
            }
            else
            {
                while (compare(n1, zero) == true)
                {
                    n1 = n1 - n2;
                    // if (compare(n1, zero) == true)
                    // {
                        ris += uno;
                    // }
                }
                return ris;
                }
            }

        static int lunghezza(CHugeNumber n)
        {
            int len = 0;
            if (n.Cifre[0] != 0)
                return 0;
            else{
                int i = 0, state = 1;
                while (i < N && state == 1)
                {
                    if (n.Cifre[i] == 0){
                        len++;
                    } else
                        state = 0;

                    i++;
                }
                if (len == N)
                    return N;
            }
            return len;
        }
        public static bool compare (CHugeNumber n1, CHugeNumber n2)
        {
            int len = N - lunghezza(n1), len2 = N - lunghezza(n2);
            // se il primo numero nell'array e' negativo
            if (len != 0){
            if (n1.Cifre[N - len] >= 0){
            if (len > len2)
                return true;
            else if (len == len2){
                int i = 0, state = 1;
                while (state == 1 && i < N - 1){
                    if (n1.Cifre[N - len + i - 1] > n2.Cifre[N - len + i - 1])
                        return true;
                    else if (n1.Cifre[N - len + i - 1] < n2.Cifre[N - len + i - 1])
                        return false;
                    else
                        state = 1;
                    i++;
                }
            }
            }
        }
            return false;
        }

        public override string ToString()
        {
            // CHugeNumber zero = new CHugeNumber();
            string ris = "";
            int counter = 0;
            
                for (int i = 0; i < N; i++)
                {
                    if (this.Cifre[i] == 0)
                        counter++;

                    if (this.Cifre[i] == 99)
                        ris += ".";
                    else
                        ris += this.Cifre[i];
                }
                if (counter == N)
                    return "0";
                else
                    return ris.TrimStart('0');
        }
        }
    }