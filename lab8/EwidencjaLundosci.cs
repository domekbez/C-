using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace p3z
{
    public class EwidencjaLundosci
    {
        public readonly string name = "Ewidencja Ludnosci";
        public EwidencjaLundosci()
        {
            if(Directory.Exists(name))
            {
                Directory.Delete(name, true);
            }
            Directory.CreateDirectory(name);
        }
        public void SerializujObywatela(Obywatel o, string path)
        {
            FileStream f = new FileStream(path, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(f, o);
            f.Close();
        }
        public Obywatel DeserializujObywatela(string path)
        {
            FileStream f = new FileStream(path, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            Obywatel o = (Obywatel)b.Deserialize(f);
            f.Close();
            return o;
        }
        public void DodajObywatela(Obywatel o)
        {
            string path = name;

            string[] p = new string[3];
            p[0] = o.pesel.Substring(0, 2);
            p[1] = o.pesel.Substring(2, 2);
            p[2] = o.pesel.Substring(4, 2);
            for (int i = 0; i < 3; i++)
            {
                path += "/" + p[i];

                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }
            }
            

            path += "/" + o.pesel + ".bin";

            if (File.Exists(path))
            {
                Console.WriteLine("Obywatel o podanym peselu istnieje już w bazie");
                return;
            }

            FileStream sw = new FileStream(path, FileMode.OpenOrCreate);
            BinaryFormatter sf = new BinaryFormatter();
            sf.Serialize(sw, o);
            sw.Close();
        }
        public void UsunObywatela(string r)
        {
            

            string path = name + "/" + r.Substring(0, 2) + "/" + r.Substring(2, 2) + "/" + r.Substring(4, 2);
            
            if (!File.Exists(path + "/" + r + ".bin"))
            {
                Console.WriteLine("Obywatel o peselu {0} nie istnieje w bazie", r);
                return;
            }
            File.Delete(path + "/" + r + ".bin");
            Console.WriteLine("Usunięto obywatela o peselu {0}", r);

            while (path != name)
            {
                string temp = Directory.GetParent(path).FullName;
                if (Directory.GetFiles(path).Length != 0 || Directory.GetDirectories(path).Length != 0)
                {
                    return;
                }
                Directory.Delete(path);
                path = temp;
            }


        }
        public int IleUrodzonychWDniuTygodnia(DayOfWeek d)
        {
            int it = 0;

            foreach (var el in Directory.EnumerateFiles(name, "*", SearchOption.AllDirectories))
            {
                string p = el.Substring(el.Length - 15, 6);
                string a = p.Substring(0, 2);
                string b = p.Substring(2, 2);
                string c = p.Substring(4, 2);
                

                if (a[0] == 'o' || a[0] == '\\' || b[0] == 'o' || b[0] == '\\' || c[0] == 'o' || c[0] == '\\') continue;
                
                
                DateTime dat = new DateTime(int.Parse(a)+1900, int.Parse(b), int.Parse(c));
                if (dat.DayOfWeek == d) it++;

            }
            
            
            
            return it;
        }
    }
}
