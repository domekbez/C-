using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace p3z
{
	class SantaClause
	{
		Random rand = new Random(7);

		public List<Tuple<int, string>> decodedLetters = new List<Tuple<int, string>>(); //lista par: (identyfikator listu, zdekodowane imię dziecka)

        private List<Task> tasks = new List<Task>(); 

		private string DecodeChildName(long number)
		{
			Dictionary<long, string> childrenList = new Dictionary<long, string>() { { 3, "Marek" },
				{ 195421207, "Andrzej" }, { 32416189859, "Agnieszka" }, { 247531, "Kamil" },
				{ 4743953, "Dżesika" }, { 1536839, "Zuzia" }, { 21887587, "Brajanek" },
				{ 1503401, "Ola" }, { 12653723, "Janusz" }, { 522211, "Grażyna" }, {59464991, "Grześ" },
				{ 86281861, "Tomek" } };

			if (childrenList.ContainsKey(number))
				return childrenList[number];
			else
				return "UNKNOWN";
		}

		public void PrepareForChristmas(List<Letter> letters)
		{
			
            for (int day = 19; day < 24; day++)
            {
                    List<Letter> daylist = new List<Letter>();
                    foreach (Letter l in letters)
                    {
                        if (l.ReceivedDay == day) daylist.Add(l);
                    }
                    
                    tasks.Add(SendLettersToFactory(daylist, day));

                    GoSleep();

                    
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Ho! Ho! Ho! Wesołych świąt!");
        }

	

		public void GoSleep()
		{
			Console.WriteLine("Mikołaj śpi");
			System.Threading.Thread.Sleep(1000);
		}
        async public Task SendLettersToFactory(List<Letter> lista, int day)
        {
           
            Console.WriteLine("Wysłanie listów do fabryki z " + day + "grudnia");
         
            List<Tuple<int, long>> pom = await Task.Run(()=>ChristmasFactory.ManageLetters(lista));
            Console.WriteLine("Przetworzono wszystkie listy z " + day + "grudnia");

            for (int i=0;i<pom.Count;i++)
            {
                string s = DecodeChildName(pom[i].Item2);
             
                Tuple<int, string> t = new Tuple<int, string>(lista[i].Id, s);
                decodedLetters.Add(t);
            }
        }

	}

}