using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Frazioni
{
    class CFrazione
    {
        private int _num, _den; // usabili solo in questa classe

        public int num // usabili anche da fuori = property dell'oggetto
        {
            get
            {
                return _num;
            }
            set
            {
                _num = value;
            }
        }
        // servono per controllare se i valori dati in input sono accettabili
        // 
        public int den
        {
            get
            {
                return _den;
            }
            set
            {
                if (value != 0)
                {
                    _den = value;
                } else
                {
                    _den = 1;
                }
            }
        }

        public CFrazione() //costruttore di default
        {
            num = 0; //è come mettere this.num = 0; 
            den = 0; //con la property me lo mette lui a 1
        }

        public CFrazione(int num, int den) //overloading costruttore = diamo più informazioni
        {
            this.num = num; // num property è uguale a num parametro
            this.den = den;
        }

        public override string ToString() // da warning perchè è già presente in ogni classe il metodo ToString = regalo
        { // override per sovrascrivere e togliere il warning :)
            string risultato = "";
            risultato = this.num.ToString() + "/" + this.den.ToString();
            return risultato;
        }

        // Somma
        public static CFrazione Somma(CFrazione f1, CFrazione f2) // static = di classe
        {
            CFrazione ris;
            ris = new CFrazione();
            ris.den = f1.den * f2.den;
            ris.num = (ris.den / f1.den) * f1.num + (ris.den / f2.den) * f2.num;
            return ris;
        }

        public CFrazione Somma(CFrazione f1) // da fare sull'oggetto
        {
            CFrazione ris = CFrazione.Somma(this, f1); //per non ricopiare il codice // this = l'oggetto su cui applico la funzione
            return ris;
        }

        public override string ToString(){
            string risultato = "";
            risultato = this.num.ToString() + "/" + this.den.ToString();
            return risultato;
        }

        public string ToString(bool json)
        {
                string risultato = "";
                if (json)
                                // JsonSerializer classe che permette di trasformare una stringa json
                    risultato = JsonSerializer.Serialize(this);
                else
                    risultato = ToString();

                return risultato;
        }

        //override dell'operatore +
        public static CFrazione operator +(CFrazione f1, CFrazione f2) // static = di classe
        {
            CFrazione ris = CFrazione.Somma(f1, f2);
            return ris;
        }

        //Sottrazione
        public static CFrazione Sottrazione(CFrazione f1, CFrazione f2) // static = di classe
        {
            CFrazione ris;
            ris = new CFrazione();
            ris.den = f1.den * f2.den;
            ris.num = (ris.den / f1.den) * f1.num - (ris.den / f2.den) * f2.num;
            return ris;
        }

        public CFrazione Sottrazione(CFrazione f1) // da fare sull'oggetto
        {
            CFrazione ris = CFrazione.Sottrazione(this, f1);
            return ris;
        }

        //override dell'operatore -
        public static CFrazione operator -(CFrazione f1, CFrazione f2) // static = di classe
        {
            CFrazione ris = CFrazione.Sottrazione(f1, f2);
            return ris;
        }

        //Moltiplicazione
        public static CFrazione Moltiplicazione(CFrazione f1, CFrazione f2) // static = di classe
        {
            CFrazione ris;
            ris = new CFrazione();
            ris.den = f1.den * f2.den;
            ris.num = f1.num * f2.num;
            return ris;
        }

        public CFrazione Moltiplicazione(CFrazione f1) // da fare sull'oggetto
        {
            CFrazione ris = CFrazione.Moltiplicazione(this, f1);
            return ris;
        }
        public CFrazione reciproco()
        {
            CFrazione risultato = new CFrazione (this.den, this.num);
            return risultato;
        }

        //override dell'operatore *
        public static CFrazione operator *(CFrazione f1, CFrazione f2) // static = di classe
        {
            CFrazione ris = CFrazione.Moltiplicazione(f1, f2);
            return ris;
        }

        //Divisione
        public static CFrazione Divisione(CFrazione f1, CFrazione f2) // static = di classe
        {
            CFrazione ris;
            ris = new CFrazione();
            ris.den = f1.den * f2.num;
            ris.num = f1.num * f2.den;
            return ris;
        }

        public CFrazione Divisione(CFrazione f1) // da fare sull'oggetto
        {
            CFrazione ris = CFrazione.Divisione(this, f1);
            return ris;
        }

        //override dell'operatore /
        public static CFrazione operator /(CFrazione f1, CFrazione f2) // static = di classe
        {
            CFrazione ris = CFrazione.Divisione(f1, f2);
            return ris;
        }
        public CFrazione semplifica()
        {
            int mcd = 0;
            mcd = MCD(this.num, this.den) != 1
                this.num /= mcd;
                this.den /= mcd;

            // return dell'oggetto cambiato
            return this;
        }
        private int MCD(int n1, int n2)
        {
            
        }

    }
}