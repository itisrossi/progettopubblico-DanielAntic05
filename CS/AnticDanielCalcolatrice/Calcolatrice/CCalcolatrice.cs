using Frazioni;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calcolatrice
{
    class CCalcolatrice
    {
        public enum Operazioni
        {
            somma,
            prodotto,
            divisione,
            moltiplicazione
        }

        private CHugeNumber mPrimoOperando;
        private CHugeNumber mSecondoOperando;
        private CHugeNumber mRisultato;
        private Operazioni mOperatore;

        public CHugeNumber PrimoOperando
        {
            get { return mPrimoOperando; }
            set { mPrimoOperando = value;}
        }

        public CHugeNumber SecondoOperando
        {
            get { return mSecondoOperando;}
            set { mSecondoOperando = value; }
        }

        public CHugeNumber Risultato
        {
            get { return mRisultato; }
            set { mRisultato = value;}
        }
        public Operazioni Operatore
        {
            get { return mOperatore; }
            set { mOperatore = value; }
        }
    }
