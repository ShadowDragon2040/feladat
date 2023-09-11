using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
            Console.WriteLine($"Összesen: {adatok.Count} adat található.");
            int joszam = 0;
            do
            {
                Console.WriteLine("Adjon meg egy 3 és 10 közé eső számot!");
                joszam = int.Parse(Console.ReadLine());
            } while (joszam < 4 || joszam > 9);

            List<Feladvany> bekertfeladvany = new List<Feladvany>();
            int bekertdarab = 0;
            foreach (var adat in adatok)
            {
                if (joszam == adat.Meret)
                {
                    Feladvany newFeladvany = new Feladvany(adat.Kezdo);
                    bekertfeladvany.Add(newFeladvany);
                    bekertdarab++;
                }
            }
            Console.WriteLine($"{joszam}X{joszam} nagyságú feladványból {bekertdarab} van.");
            
            Random random = new Random();
            int randombekert = random.Next(bekertdarab);
            Feladvany randomFeladvany = bekertfeladvany[randombekert];
            Console.WriteLine(randomFeladvany.Kezdo);
            randomFeladvany.Kirajzol();
            double kitoltottdb = 0;
            for (int i = 0; i < randomFeladvany.Meret * randomFeladvany.Meret; i++)
            {
                if (randomFeladvany.Kezdo[i] != 0)
                {
                    kitoltottdb += 1;
                }
            }
            double arany = randomFeladvany.Meret / kitoltottdb;
            Console.WriteLine($"{arany * 100}% van kitöltve");
            Console.ReadKey();
        }
    }
}
