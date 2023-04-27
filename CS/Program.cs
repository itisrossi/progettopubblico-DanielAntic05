using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Frazioni{
    // le classi le chiamiamo CNomeclasse
    class Program{
        static void Main(string[] args)
        {
            CHugeNumber n1 = new CHugeNumber("32456754");
            CHugeNumber n2 = new CHugeNumber("32456754");
            CHugeNumber risultato = new CHugeNumber();

            CFrazione f1, f2, f3, f4, f5, r;
            f1 = new CFrazione(1, 3);
            f2 = new CFrazione(1, 6);
            f3 = new CFrazione(4, 9);
            f4 = new CFrazione(7, 15);
            f5 = new CFrazione(34, 78);

            // Console.WriteLine("{0} ", f1);

            // Primo modo per fare la somma
            r = CFrazione.Somma(f1, f2);
            // Controllo
            Console.WriteLine("Somma " + f1 + " + " + f2 + " = " + r);
            
            // Primo modo per fare la sottrazione
            r = CFrazione.Sottrazione(f1, f2);
            // Controllo
            Console.WriteLine("Sottrazione {0} - {1} = {2}", f1, f2, r);

            // Primo modo per fare la moltiplicazione
            r = CFrazione.Moltiplicazione(f1, f2);
            // Controllo
            Console.WriteLine("Moltiplicazione {0} * {1} = {2}", f1, f2, r);

            // Primo modo per fare la divisione
            r = CFrazione.Divisione(f1, f2);
            // Controllo
            Console.WriteLine("Divisione {0} : {1} = {2}", f1, f2, r);

            // Secondo modo per fare la somma:
            // r = f1.Somma(f2);
            // Console.WriteLine("Somma di 5/6 + 7/8 = {0} ", r);

            // Terzo modo per fare la somma e anche altre operazioni:
            r = ((f1 + f2) * f3) / (f4 - f5); 
            
            // Console.WriteLine("Hai creato la frazione {0} e la frazione {1} somma {2}", f1.ToString(), f2, r);
            Console.WriteLine("La somma totale e' = {0}", r);

            // controllo operazioni CHugeNumber
            risultato = (n1 + n2);
            Console.WriteLine("La somma totale e' = {0}", risultato);

        }
    }
}