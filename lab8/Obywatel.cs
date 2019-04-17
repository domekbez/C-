using System;
using System.IO;
using System.Runtime.Serialization;

namespace p3z
{
    [Serializable]
	public class Obywatel:IDeserializationCallback
	{
		public string pesel;

        [NonSerialized]
        public string miasto;

        public string kodPocztowy;

        public void OnDeserialization(object sender)
        {
            string pom = kodPocztowy;
            StreamReader s = new StreamReader("kody.csv");
            while (s.EndOfStream == false)
            {
               
                string a = s.ReadLine();
                
                if (a.Contains(pom))
                {

                    miasto = "";
                    string[] w = a.Split(';');
                    for (int i = 1; i < w.Length; i++)
                    {
                        miasto += w[i];
                        
                    }
             
                    return;
                }
            }
            s.Close();
        }
    }
}
