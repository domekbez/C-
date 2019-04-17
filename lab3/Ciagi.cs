using System;
using System.Collections;

namespace Lab8
{
    class Naturalne:IEnumerable
    {
        int a;
        public Naturalne(int i=0)
        {
            a = i;
        }
        public IEnumerator GetEnumerator()
        {
            int p = a;
            while(true)
            {
                yield return p++;
            }
        }
    }


    class Losowe : IEnumerable
    {
        int max, ziarno;
        public Losowe(int b, int a)
        {
            max = a;
            ziarno = b;

        }
        public IEnumerator GetEnumerator()
        {
            Random r = new Random(ziarno);
            while (true)
            {
                yield return r.Next(0, max);
            }
        }

    }

    class Tetranacci : IEnumerable
    {
        public Tetranacci()
        {            
        }
        public IEnumerator GetEnumerator()
        {
            int a, b, c, d;
            d = 1;
            a = b = c = 0;
            int pom = 1;
            yield return a;
            yield return b;
            yield return c;
            yield return d;


            while (true)
            {
                yield return a + b + c + d;
                
                pom = a + b + c + d;
                a = b;
                b = c;
                c = d;
                d = pom; 
            }

        }

    }

    class Catalan : IEnumerable
    {
        public Catalan()
        {
        }
        public IEnumerator GetEnumerator()
        {
            int a = 1;

            yield return a;
            for (int i = 0; ; i++)
            {
                a = a * 2 * (2 * i + 1) / (i + 2);
                yield return a;
            }

        }
    }

    class Wielomian : IEnumerable
    {
        int[] wsp;
        public Wielomian(int[] w)
        {
            wsp = w;
        }
        public int Horner(int x, int[] wsp)
        {
            int n = wsp.GetLength(0);
            int pom = wsp[n - 1];
            for(int i=n-2;i>=0;i--)
            {
                pom *= x;
                pom += wsp[i];
            }
            return pom;
        }
        public IEnumerator GetEnumerator()
        { 
            for (int i = 0; ; i++)
            {

                yield return Horner(i, wsp);
            }

        }

    }
}
