using System;
using System.Collections.Generic;

namespace p3z
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("======= CZĘŚĆ 1 =======");
			Console.WriteLine("-- Konstruktor i ToString() --");
            FuzzySet f1 = new FuzzySet((1, 0.1f), (2, 0.2f), (3, 0.3f), (4, 0.4f), (5, 0.5f));
            Console.WriteLine($"f1: {f1}");
            FuzzySet f2 = new FuzzySet((4, 0.1f), (5, 0.5f), (6, 0.6f), (7, 0.7f), (9, 0.8f), (9, 0.9f), (10, 1.0f));
            Console.WriteLine($"f2: {f2}");
            FuzzySet f3 = new FuzzySet((1, 0.3f), (3, 0.1f), (6, 0.9f), (9, 0.6f));
            Console.WriteLine($"f3: {f3}");
            FuzzySet f4 = new FuzzySet((3, 0.8f));
            Console.WriteLine($"f4: {f4}");
            FuzzySet f5 = new FuzzySet();
            Console.WriteLine($"f5: {f5}");

            Console.WriteLine();
			Console.WriteLine("======= CZĘŚĆ 2 =======");
			Console.WriteLine("-- Operator + (v1) --");
            FuzzySet f6 = f1 + (1, 0.5f);
            Console.WriteLine($"f6: {f6}");
            f2 += (3, 0.3f);
            Console.WriteLine($"f2': {f2}");
            f3 += (9, 0.8f);
            f3 += (5, 0.55f);
            Console.WriteLine($"f3': {f3}");
            FuzzySet f7 = f4 + (3, 0.4f) + (3, 1.0f) + (3, 0.9f);
            Console.WriteLine($"f7: {f7}");

            Console.WriteLine();
            Console.WriteLine("-- Operator + (v2) --");
            Console.WriteLine($"f1+f2: {f1 + f2}");
            Console.WriteLine($"f1+f3: {f1 + f3}");
            Console.WriteLine($"f4+f5: {f4 + f5}");

            Console.WriteLine();
            Console.WriteLine("-- Operator / --");
            Console.WriteLine($"f1/f2: {f1 / f2}");
            Console.WriteLine($"f2/f3: {f2 / f3}");
            Console.WriteLine($"f5/f1: {f5 / f1}");

            Console.WriteLine();
            Console.WriteLine("-- Operator unarny minus --");
            Console.WriteLine($"-f1: {-f1}");
            Console.WriteLine($"-f3: {-f3}");
            Console.WriteLine($"-f5: {-f5}");

            Console.WriteLine();
			Console.WriteLine("======= CZĘŚĆ 3 =======");
			Console.WriteLine("-- Operatory porównywania --");
            FuzzySet f8 = new FuzzySet((3, 0.8f));
            Console.WriteLine($"f8: {f8}");
            FuzzySet f9 = new FuzzySet((3, 0.9f));
            Console.WriteLine($"f9: {f9}");
            FuzzySet f10 = new FuzzySet((5, 0.5f), (2, 0.2f), (3, 0.3f), (1, 0.1f), (4, 0.4f));
            Console.WriteLine($"f10: {f10}");

            Console.WriteLine();
            Console.WriteLine($"f10 == f1: {f10 == f1}");
            Console.WriteLine($"f4 == f8: {f4 == f8}");
            Console.WriteLine($"f1 != f6: {f1 != f6}");
            Console.WriteLine($"f4 != f9: {f4 != f9}");

            Console.WriteLine($"f1 < f5: {f5 < f1}");
            Console.WriteLine($"f8 < f9: {f8 < f9}");
            Console.WriteLine($"-f3 > f8: {-f3 > f8}");

            Console.WriteLine();
            Console.WriteLine($"f1 == f6: {f1 == f6}");
            Console.WriteLine($"f4 == f9: {f4 == f9}");
            Console.WriteLine($"f10 != f1: {f10 != f1}");
            Console.WriteLine($"f4 != f8: {f4 != f8}");

            Console.WriteLine($"f1 > f10: {f1 > f10}");
            Console.WriteLine($"f1 < f10: {f1 < f10}");
            Console.WriteLine($"f1 > f5: {f5 > f1}");
            Console.WriteLine($"f8 > f9: {f8 > f9}");
            Console.WriteLine($"f2 > f3: {f2 > f3}");
            Console.WriteLine($"f2 < f3: {f2 < f3}");

            Console.WriteLine();
			Console.WriteLine("======= CZĘŚĆ 4 =======");
			Console.WriteLine("-- Indeksator --");
			//Console.WriteLine($"f1[3]: {f1[3]}");
			//Console.WriteLine($"f1[10]: {f1[10]}");
			//Console.WriteLine($"f5[0]: {f5[0]}");
			//f1[3] = 0.1f;
			//Console.WriteLine($"f1[3]: {f1[3]}");
			//f1[10] = 0.5f;
			//Console.WriteLine($"f1[10]: {f1[10]}");
			//f5[0] = 1.0f;
			//Console.WriteLine($"f5[0]: {f5[0]}");

			//Console.WriteLine();
			//Console.WriteLine("-- Rzutowanie --");
			//List<int> l1 = new List<int>() { 1, 2, 3, 4, 5 };
			//FuzzySet f11 = l1;
			//Console.WriteLine($"f11: {f11}");

			//List<int> l2 = new List<int>() { 0 };
			//FuzzySet f12 = (FuzzySet)l2;
			//Console.WriteLine($"f12: {f12}");

			//List<int> l3 = (List<int>)f1;
			//for (int i = 0; i < l3.Count; i++)
			//	Console.Write(l3[i] + " ");
			//Console.WriteLine();

			//List<int> l4 = f1; //ta linijka powinna powodować błąd kompilacji
		}
	}
}
