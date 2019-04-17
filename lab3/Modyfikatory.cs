using System;
using System.Collections;
namespace Lab8
{
    /// <summary>
    /// Interfejs klas modyfikujących sekwencje
    /// </summary>
    public interface IModifier
    {
        /// <summary>
        /// Nazwa modyfikatora
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Metoda modyfikuje sekwencje
        /// </summary>
        /// <param name="sequence">Sekwencja do modyfikacji</param>
        /// <returns>Zmodyfikowana sekwencja</returns>
        IEnumerable Modify(IEnumerable sequence);
    }

    public class PoczatkoweN : IModifier
    {
        string IModifier.Name { get { return "Poczatkowe "+ ile.ToString() + " liczb"; } }

        int ile;

        public PoczatkoweN(int n)
        {
            ile = n;
        }

        public IEnumerable Modify(IEnumerable sequence)
        {
            int i = 0;
            foreach (var k in sequence)
            {
                if (i == ile) yield break;
                yield return k;
                i++;
            }
        }
    }
    public class TransformacjaLiniowa : IModifier
    {
        int a, b;
        string IModifier.Name { get { return "Transformacja liniowa"; } }

        public TransformacjaLiniowa(int c,int d)
        {
            a = c;
            b = d;
        }
        public IEnumerable Modify(IEnumerable sequence)
        {
            foreach (var k in sequence)
            {
                yield return (int)k * a + b;
            }
        }
    }
    public class TylkoRozne : IModifier
    {
        string IModifier.Name { get { return "Unikalne wartosci"; } }

        public IEnumerable Modify(IEnumerable sequence)
        {
            int i = 0;
            int poprz = 0;
            foreach (var k in sequence)
            {
                if (i == 0)
                {
                    yield return k;
                    i++;
                }

                else
                {
                    if (poprz != (int)k)
                    {
                        yield return k;
                    }
                }

                poprz = (int)k;

            }
        }
    }


    public class LiczbyPierwsze : IModifier
    {
        string IModifier.Name { get { return "Liczby pierwsze z sekwencji"; } }

        public bool LiczbaPierw(int n)
        {
            if (n == 0 || n == 1)
                return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public IEnumerable Modify(IEnumerable sequence)
        {
            foreach (var k in sequence)
            {
                if (LiczbaPierw((int)k))
                {
                    yield return k;
                }

            }
        }
    }
    public class MinimaLokalne : IModifier
    {
        string IModifier.Name { get { return "Minima lokalne"; } }

        public bool LiczbaPierw(int n)
        {
            if (n == 0 || n == 1)
                return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public IEnumerable Modify(IEnumerable sequence)
        {
            int i = 0;
            int minim = 0;
            int poprz = 0;
            int ost=0;
            bool flaga = true;
            bool flaga2 = false;
            foreach (var k in sequence)
            {
                if (i == 0)
                {
                    flaga2 = true;
                    ost=poprz = minim = (int)k;
                }
                else
                {
                    if ((int)k <= poprz)
                    {
                        minim = (int)k;
                    }
                    else
                    {
                        if (flaga||minim != ost)
                        {
                            yield return minim;
                            ost = minim;
                            flaga = false;
                        }
                    }
                }
                i++;
                poprz = (int)k;
            }
            if (flaga2&&minim==poprz)
            {
                yield return minim;
            }
        }
    }

}
