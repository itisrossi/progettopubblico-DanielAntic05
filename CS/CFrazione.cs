using System;
using System.Collections.Generic;
using System.Text;

namespace TestFrazioni{
    // le classi le chiamiamo CNomeclasse
    class CFrazioni{
        // andiamo a d aggiungere delle variabili che saranno visibili dentro la classe
        // per indicare questo diciamo che sono private
        // le variabili le chiamiamo con mNomeVariabile oppure con _NomeVariabile (tutto questo quando sono private)
        private int mNumeratore;
        private int mDenominatore;

        // dobbiamo creare delle property (pubbliche in questo caso), una per il Num una per il Den
        public int Numeratore{
            // get serve per prendere/leggere
            get {
                return mNumeratore;
            }
            // serve per mettere un valore
            set {
                // serve per ottenere il valore
                mNumeratore = value;
            }
        }
        public int Denominatore{
            get {
                return mDenominatore;
            }
            set {
                // questo non si può fare se la variabile mDenominatore fosse stata pubblica
                if (value != 0)
                    mDenominatore = value;
                else
                    mDenominatore = 1;
            }
        }
        public CFrazioni(){
            this.Numeratore = 0;
            this.Denominatore = 0;
        }   
        public CFrazioni(int Numeratore, int Denominatore){
            this.Numeratore = Numeratore;
            this.Denominatore = Denominatore;
        }
        
    }
}
