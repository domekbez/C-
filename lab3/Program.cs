
using System;
using System.Collections;

namespace Lab8
{

    class Program
    {
        private static void PrintIEnumerable(IEnumerable Sequence, int limit = int.MaxValue)
        {
            int index = 0;
            foreach (var i in Sequence)
            {
                Console.Write("{0}\t", i);
                if (++index == limit) break;
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== Etap 1 ===\n");

            IEnumerable naturals = new Naturalne(1);
            Console.WriteLine("Liczby naturalne");
            PrintIEnumerable(naturals, 10);

            IEnumerable random = new Losowe(667, 1000);
            Console.WriteLine("Liczby losowe");
            PrintIEnumerable(random, 10);

            IEnumerable tetranacci = new Tetranacci();
            Console.WriteLine("Liczby Tetranacciego");
            PrintIEnumerable(tetranacci, 10);

            IEnumerable catalan = new Catalan();
            Console.WriteLine("Liczby Catalana");
            PrintIEnumerable(catalan, 10);

            int[] arr1 = { 56, 6, -9, 1 };
            IEnumerable polynomial = new Wielomian(arr1);
            Console.WriteLine("Wartosci wielomianu");
            PrintIEnumerable(polynomial, 10);

            Console.WriteLine("=== Etap 2 ===\n");

            IModifier first5 = new PoczatkoweN(5);
            Console.WriteLine(first5.Name);
            PrintIEnumerable(first5.Modify(random));

            IModifier linear = new TransformacjaLiniowa(10, 5);
            Console.WriteLine(linear.Name);
            PrintIEnumerable(linear.Modify(naturals), 10);

            int[] arr2 = { 3, 5, 4, 4, 4, 1, 1, 2, 3, 5, 3, 4, 2, 2, 2 };
            IModifier unique = new TylkoRozne();
            Console.WriteLine(unique.Name);
            PrintIEnumerable(unique.Modify(arr2));

            IModifier prime = new LiczbyPierwsze();
            Console.WriteLine(prime.Name);
            PrintIEnumerable(prime.Modify(naturals), 10);

            Console.WriteLine("=== Etap 3 ===\n");

            IModifier localMin = new MinimaLokalne();
            Console.WriteLine(localMin.Name);
            PrintIEnumerable(localMin.Modify(new int[0]));
            PrintIEnumerable(localMin.Modify(new int[] { 3 }));
            PrintIEnumerable(localMin.Modify(new int[] { 4, 1 }));
            PrintIEnumerable(localMin.Modify(new int[] { 2, 5 }));
            PrintIEnumerable(localMin.Modify(arr2));

            Console.WriteLine("=== Etap 4 ===\n");

            IMerger multiply = new Mnoz();
            Console.WriteLine(multiply.Name);
            PrintIEnumerable(multiply.Merge(naturals, prime.Modify(naturals)), 10);

            Console.WriteLine("=== Etap 5 ===\n");

            //naturals = new Naturalne();
            //IModifier[] modifiers = {first5, linear, prime};
            //IModifier composed = new ModyfikatorZlozony(modifiers);
            //Console.WriteLine(composed.Name);
            //PrintIEnumerable(composed.Modify(naturals),10);

            //IModifier[] modifiers2 = {first5, prime, linear};
            //IModifier composed2 = new ModyfikatorZlozony(modifiers2);
            //Console.WriteLine(composed2.Name);
            //PrintIEnumerable(composed2.Modify(naturals),10);

            //TabliczkaDodawania table = new TabliczkaDodawania();
            //Console.WriteLine("Tabliczka Dodawania\n");
            //foreach ( IEnumerable seq in table )
            //    PrintIEnumerable(seq);

        }

    }

}
