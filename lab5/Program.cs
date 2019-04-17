using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab09_a
{
    class Program
    {
        public static Func<double> RandomNumberGenerator(int seed,int min, int max)
        {
            Random a = new Random(seed);

            return new Func<double>(() => a.Next(min, max));

        }
        public static Func<double> FibonacciNumbers()
        {


            int a = 0;
            int aprev = 0;
            int c = 1;
            return new Func<double>(() =>
            {
                if(a!=0)
                    c = aprev + a;
                aprev = a;
                a = c;
                return aprev;
            }
            );
        }
        public static void PrintArray<T>(T[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
                Console.Write(tab[i] + " ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //ETAP I - 1.0p za napisanie funkcji do generowania
            Console.WriteLine("ETAP I\n");
            Func<double> rndGen = RandomNumberGenerator(1500, 1, 100);
            Func<double> rndGen2 = RandomNumberGenerator(1500, 1, 100);
            Func<double> fibonacciNumbersGen1 = FibonacciNumbers();
            Func<double> fibonacciNumbersGen2 = FibonacciNumbers();

            double[] randoms = new double[30];
            double[] fibonacciNumbers1 = new double[30];
            double[] fibonacciNumbers2 = new double[30];

            for (int i = 0; i < 30; i++)
            {
                randoms[i] = rndGen();
                var tmp = rndGen2();
                if (randoms[i] != tmp)
                    Console.WriteLine("Error, values should be equal");
                fibonacciNumbers1[i] = fibonacciNumbersGen1();
                fibonacciNumbers2[i] = fibonacciNumbersGen2();
            }

            PrintArray(randoms);
            PrintArray(fibonacciNumbers1);

            Console.WriteLine("\nETAP II\n");

            //ETAP II - 1.0p

            Console.WriteLine();
            randoms.MyEach(x => Console.Write(x + " "));
            Console.WriteLine();
            fibonacciNumbers1.MyEach(x => Console.Write(x + " "));
            Console.WriteLine();
            fibonacciNumbers2.MyEach(x => Console.Write(x + " "));
            Console.WriteLine();
            int k = 5;
            ////TODO:
            //// here use MyWhere on fibonacciNumbers2 to get elements divisable by k
            ////Use transformed2 variable for values matching delegate

            var transformed2 = fibonacciNumbers2.MyWhere(x => { if (x % k == 0) return true; else return false; });
            transformed2.MyEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine();

            ////TODO:
            //// here use ToTransformedArray on fibonacciNumbers1 to obtain modified collection with elements divided by 2.
            ////Use transformed variable to store values matching delegate
            var transformed = fibonacciNumbers1.ToTransformedArray(x => { return x / 2; });
            transformed.MyEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine();

            ////TODO:
            ////here use ToTransformedArray on fibonacciNumbers1 collection to replace elements using rndGen delegate
            ////Use "transformed" to return values.
            transformed = fibonacciNumbers1.ToTransformedArray(x => { return rndGen(); });
            transformed.MyEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine();

            double[] values = new double[35];
            var randomGenerator3 = RandomNumberGenerator(450, 10, 100);
            for (int i = 0; i < values.Length; i++)
                values[i] = randomGenerator3();

            Console.WriteLine();
            double sum = 0;
            //TODO:
            //write Code responsible for summing elements from values collection.
            foreach (var v in values)
                sum += v;
            Console.WriteLine("Sum is: " + sum);

            int[] tableNull = null;
            tableNull.ToTransformedArray(x => x);

            var fib4 = FibonacciNumbers();
            var fibTmp = FibonacciNumbers();
            var toArrayTest = values.ToTransformedArray(x => fib4());
            for (int i = 0; i < values.Length; i++)
                fibTmp();
            toArrayTest.MyEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine("Original Length: " + values.Length + " ToTransformedArray Length: " + toArrayTest.Length);
            Console.WriteLine();
            //test to check if both number generators are in correct place
            for (int i = 0; i < 10; i++)
            {
                var x1 = (int)fib4();
                var x2 = (int)fibTmp();
                if (x1 != x2)
                    Console.WriteLine("Error, values should be equal");
            }


            Console.WriteLine("\nETAP III\n");

            //ETAP III - 1.0p
            //testing occurences
            Dictionary<string, int> dic=new Dictionary<string, int>();
            var text = File.ReadAllLines("TextToRead.txt");
            
            text.MyEach((x =>
            {
                string[] tab=x.Split(' ');
                foreach (var el in tab)
                {
                    if (el == "") return;
                    if (dic.ContainsKey(el) == true)
                        dic[el]++;

                    else
                    {
                        dic.Add(el, 1);
                    }
                }
            }));

            var list = dic.ToList();
            list.Sort((x, y) => x.Key.CompareTo(y.Key));
           
            list.MyEach((x =>
            {
                Console.WriteLine(x.Key + " " + x.Value);
            }));
            //TODO write code to count words from file
            
            Console.WriteLine("\nETAP IV\n");
            //ETAP IV - 2.0p
            //testing polynomials

            //List<Func<double, double>> polynomials = new List<Func<double, double>>();
            //List<Func<double, double>> polynomialDerivatives = new List<Func<double, double>>();

            //var p0 = Polynomial.CreatePolynomial(out Func<double, double> p0Dx, 1, 2, 3);
            //var p1 = Polynomial.CreatePolynomial(out Func<double, double> p1Dx, 2, 3);
            //var p2 = Polynomial.CreatePolynomial(out Func<double, double> p2Dx, 2, 2, 2, 2);
            //var p3 = Polynomial.CreatePolynomial(4, FibonacciNumbers(), out Func<double, double> p3Dx);
            //var psum = Polynomial.SumOfPolynomials(p0, p1, p2, p3);

            //Console.WriteLine(psum(10));
            //Console.WriteLine(p3(0));
            //Console.WriteLine(p3(1));
            //Console.WriteLine(p3(2));

            //polynomials.Add(p0);
            //polynomials.Add(p1);
            //polynomials.Add(p2);
            //polynomials.Add(p3);
            //polynomialDerivatives.Add(p0Dx);
            //polynomialDerivatives.Add(p1Dx);
            //polynomialDerivatives.Add(p2Dx);
            //polynomialDerivatives.Add(p3Dx);

            //var randomGenerator5 = RandomNumberGenerator(1500, 1, 6);
            //int[] polynomialsDegrees = new int[3];
            //for (int i = 0; i < 3; i++)
            //    polynomialsDegrees[i] = (int)randomGenerator5();


            //var randomGenerator6 = RandomNumberGenerator(1500, 1, 10);
            //for (int i = 0; i < polynomialsDegrees.Length; i++)
            //{
            //    polynomials.Add(Polynomial.CreatePolynomial(polynomialsDegrees[i], randomGenerator6, out Func<double, double> ithDerivative));
            //    polynomialDerivatives.Add(ithDerivative);
            //}

            //int[] testValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //for (int i = 0; i < polynomials.Count; i++)
            //{
            //    foreach (var x in testValues)
            //        Console.WriteLine("value: " + polynomials[i](x) + ", derivative: " + polynomialDerivatives[i](x));
            //    Console.WriteLine();
            //}

            //polynomials.Add(Polynomial.SumOfPolynomials(polynomials.ToArray()));
            //polynomials.Add(Polynomial.SumOfPolynomials(polynomialDerivatives.ToArray()));

            //for (int i = 0; i < testValues.Length; i++)
            //{
            //    int x = testValues[i];
            //    Console.WriteLine("summed value: " + polynomials[polynomials.Count - 2](x) + ", summed derivative: " + polynomials[polynomials.Count - 1](x));
            //}
        }
    }
}
