using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuCLI
{
    internal class Program
    {
        class Feladvany
        {
            public string Kezdo { get; private set; }
            public int Meret { get; private set; }

            public Feladvany(string sor)
            {
                Kezdo = sor;
                Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
            }
            public void Kirajzol()
            {
                for (int i = 0; i < Kezdo.Length; i++)
                {
                    if (Kezdo[i] == '0')
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write(Kezdo[i]);
                    }
                    if (i % Meret == Meret - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
        static List<Feladvany> adatok = new List<Feladvany>();
        public static void beolvasas()
        {
            StreamReader reader = new StreamReader("feladvanyok.txt");
            string sor = "";

            while (!reader.EndOfStream)
            {
                sor = reader.ReadLine();
                adatok.Add(new Feladvany(sor));
            }
        }
        static void Main(string[] args)
        {
            beolvasas();
            foreach (var adat in adatok)
            {
                Console.WriteLine(adat.Kezdo);
            }
            Console.WriteLine($"Összesen: {adatok.Count} adat található.");
            Console.ReadKey();
        }
    }
}
