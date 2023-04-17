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

        // num è una variabile pubblica, quindi si può usare nei costruttori
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
        // servono per controllare se i valori 
        // dati in input sono accettabili
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
// _____________________________________________________________________________________________________________
// da qui iniziano i costruttori ai quali accedono f1, f2, f3, f4, f5 nel file "Program.cs"
        public CFrazione(int num, int den) //overloading costruttore = diamo più informazioni
        {
            // num property è uguale a num parametro
            this.num = num; 
            this.den = den;
        }
// __________________________________________________________________________________________________________________________
// Da qui si calcola il risultato --> r

    // Somma
        // static = di classe
        public static CFrazione Somma(CFrazione f1, CFrazione f2)
        {
            CFrazione ris;
            ris = new CFrazione();
            ris.den = f1.den * f2.den;
        // Se il denominatore è pari, basta dividere per 2 ris.den (mcm) per ottenere il denominatore ai minimi termini
            if (f1.den % 2 == 0 && f2.den % 2 == 0)
                ris.den /= 2;
            // Console.WriteLine("Il denominatore è " + ris.den); --> 48  (check)

            ris.num = (ris.den / f1.den) * f1.num + (ris.den / f2.den) * f2.num;
            return ris;
        }
        // Altro modo per fare la somma:

        // public CFrazione Somma(CFrazione f1) // da fare sull'oggetto
        // {
        //     CFrazione ris = CFrazione.Somma(this, f1); //per non ricopiare il codice 
        //                                                // this = l'oggetto su cui applico la funzione
        //     return ris;
        // }

        //override dell'operatore +:
        // si esegue da solo come un normale override,
        // solo che deve essere tra due variabili,
        // siccome e' un operazione
        public static CFrazione operator +(CFrazione f1, CFrazione f2) // static = di classe
        {
            CFrazione ris = CFrazione.Somma(f1, f2);
            return ris;
        }

         // override sovrascrive il ToString:

         /* permette di estendere o modificare l'implementazione 
            astratta o virtuale di un metodo, una proprietà,
            un indicizzatore o un evento ereditato.

            Infatti, siccome esiste gia' il metodo ToString(),
            per farne uno nostro usiamo l'override.
        */

        // Poiché è un override si esegue da solo !!!
        public override string ToString() // da warning perchè è già presente in ogni classe il metodo ToString
        { // override per sovrascrivere e togliere il warning :)
            string risultato = "";
            risultato = this.num.ToString() + "/" + this.den.ToString();
            return risultato;
        }

        // // non c'e' l'override perche' c'e' un bool
        // public string ToString(bool json)
        // {
        //         string risultato = "";
        //         if (json)
        //                         // JsonSerializer classe che permette di trasformare una stringa json
        //             risultato = JsonSerializer.Serialize(this);
        //         else
        //             risultato = risultato.ToString();

        //         return risultato;
        // }

        //Sottrazione
        public static CFrazione Sottrazione(CFrazione f1, CFrazione f2) // static = di classe
        {
            CFrazione ris;
            ris = new CFrazione();
            ris.den = f1.den * f2.den;

            if (f1.den % 2 == 0 && f2.den % 2 == 0)
                ris.den /= 2;
                
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
            mcd = MCD(this.num, this.den);
                this.num /= mcd;
                this.den /= mcd;
            // return dell'oggetto cambiato
                return this;
            }   
        private int MCD(int n1, int n2)
        {
            // Math.Abs() restituisce il valore assoluto di un numero!
            
            n1 = Math.Abs(n1);
            n2 = Math.Abs(n2);

            while (n1 != 0 && n2 != 0){
                if (n1 > n2)
                    n1 %= n2;
                else
                    n1 %= n2;
            }
            return n1 | n2;
        }
    }
}