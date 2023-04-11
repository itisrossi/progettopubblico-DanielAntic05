using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HugeNumbers
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
        }

    }
}