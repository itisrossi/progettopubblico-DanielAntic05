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
            CFrazione f1, f2, f3, f4, f5, r;
            f1 = new CFrazione();
            f2 = new CFrazione(7,8);
            f3 = new CFrazione(4,9);
            f4 = new CFrazione("4/9");
            f5 = new CFrazione();

            r = CFrazione.Somma(f1, f2);
            r = f1.Somma(f2);

            r = ((f1 + f2) * f3) / (f4 - f5); 
            Console.WriteLine("Hai creato la frazione {0} e ka frazione {1} somma {2}", f1.ToString(), f2, r);
            Console.WriteLine("Hello World");
        }
    }
}