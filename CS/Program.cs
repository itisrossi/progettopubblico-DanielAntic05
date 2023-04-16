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
            CHugeNumber prova = new CHugeNumber("32456754");
            CFrazione f1, f2, f3, f4, f5, r;
            f1 = new CFrazione(5, 6);
            f2 = new CFrazione(7, 8);
            f3 = new CFrazione(4, 9);
            f4 = new CFrazione(7, 15);
            f5 = new CFrazione(34, 78);

            // Console.WriteLine("{0} ", f1);

            // Primo modo per fare la somma
            r = CFrazione.Somma(f1, f2);
            // Controllo
            Console.WriteLine("Somma " + r);
            
            // Secondo modo per fare la somma:
            // r = f1.Somma(f2);
            // Console.WriteLine("Somma di 5/6 + 7/8 = {0} ", r);

            // Terzo modo per fare la somma e anche altre operazioni:
            r = ((f1 + f2) * f3) / (f4 - f5); 
            
            // Console.WriteLine("Hai creato la frazione {0} e la frazione {1} somma {2}", f1.ToString(), f2, r);
            Console.WriteLine("La somma totale e' = {0}", r);
        }
    }
}