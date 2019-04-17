using System.Collections;
using System.Collections.Generic;


namespace Lab8
{
    /// <summary>
    /// Interfejs łączenia dwóch sekwencji w jedną według jakiejś reguły
    /// </summary>
    public interface IMerger
    {
        /// <summary>
        /// Nazwa metody łączenia sekwencji
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Metoda łącząca sekwencji
        /// </summary>
        /// <param name="IEnumerable1">Pierwsza sekwencji</param>
        /// <param name="IEnumerable2">Druga sekwencji</param>
        /// <returns>Sekwencja będąca wynikiem połączenia pierwszej i drugiej sekwencji</returns>
        IEnumerable Merge(IEnumerable sequence1, IEnumerable sequence2);
    }


    public class Mnoz: IMerger
    {
        string IMerger.Name { get { return "Mnozenie"; } }

        

        public IEnumerable Merge(IEnumerable s1, IEnumerable s2)
        {
            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();
            
            int duzo = 0;
            foreach (var k in s1)
            {
                duzo++;
                l1.Add((int)k);
                if (duzo > 20) break;
            }
            duzo = 0;
            foreach (var k in s2)
            {
                duzo++;
                l2.Add((int)k);
                if (duzo > 20) break;
            }
            int ile = l1.Count < l2.Count ? l1.Count : l2.Count;

            for (int i = 0; i < 10; i++)
            {
                yield return l1[i] * l2[i];
            }




        }
    }

}
