using System.Text;

namespace Lab08_a
{
    public static class ExtensionMethods
    {
        public static string DuplicateCharacters(this string a)
        {
            string c = "";
            for (int i=0,j=0; i<a.Length;i++,j+=2)
            {
                c=c.Insert(j, a.Substring(i, 1));
                c=c.Insert(j+1, a.Substring(i, 1));
            }
            return c;
        }
    }
}
