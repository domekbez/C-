using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3z
{
    public static class ChristmasFactory
    {
        public static long NumberFactorization(long a)
        {

            if (IsPrime(a))
                return -1;
            for (long i = 3; i <= Math.Sqrt(a); i += 1)
              {
                    if (a % i == 0&&IsPrime(i))
                        return i;
                
                }
            
            return -1;
        }
        public static bool IsPrime(long number)
        {
            for (long i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        public static async Task<List<Tuple<int,long>>> ManageLetters(List<Letter> lista)
        {
            List<Tuple<int, long>> nowa = new List<Tuple<int, long>>();
            foreach (var l in lista)
            {
               
                long a = await Task.Run(()=>NumberFactorization(l.Number));
                Tuple<int, long> t = new Tuple<int, long>(l.Id, a);
                

                nowa.Add(t);

            }
            return nowa;

        }
    }
}
