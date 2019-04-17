using System;
using System.Collections.Generic;

namespace p3z
{

    class Program
    {
        static void Main(string[] args)
        {
            Obywatel o1 = new Obywatel() { pesel = "63060683413", miasto = "Warszawa",
                kodPocztowy = "04-141" };

            Obywatel o2 = new Obywatel() { pesel = "69032628127", miasto = "Dziergowice",
                kodPocztowy = "47-244" };

            Obywatel o3 = new Obywatel() { pesel = "69032679961", miasto = "Wierzchlas",
                kodPocztowy = "98-324" };

            Obywatel o4 = new Obywatel() { pesel = "93061635317", miasto = "Radom",
                kodPocztowy = "26-603" };

            Obywatel o5 = new Obywatel() { pesel = "93060187461", miasto = "Białystok",
                kodPocztowy = "15-010" };

            Obywatel o6 = new Obywatel() { pesel = "79090899762", miasto = "Nowe Miasto Lubawskie",
                kodPocztowy = "13-300" };

            Obywatel o7 = new Obywatel() { pesel = "62041961188", miasto = "Kisielice",
                kodPocztowy = "14-220" };

            Obywatel o8 = new Obywatel() { pesel = "89110954452", miasto = "Ostrołęka",
                kodPocztowy = "07-400" };

            Obywatel o9 = new Obywatel() { pesel = "89010957853", miasto = "Piaseczno",
                kodPocztowy = "05-500" };

            Obywatel o10 = new Obywatel() { pesel = "6106061578", miasto = "Płock",
                kodPocztowy = "09-405" };

            List<Obywatel> obywatele = new List<Obywatel>() { o1, o2, o3, o4, o5, o6, o7, o8, o9, o10 };

            // ================ ETAP I ================
            Console.WriteLine("*** ETAP I ***");
            EwidencjaLundosci el = new EwidencjaLundosci();
            el.SerializujObywatela(o1, el.name + "\\testO1.bin");
            Obywatel s1Copy = el.DeserializujObywatela(el.name + "\\testO1.bin");

            if (o1.pesel == s1Copy.pesel
                && o1.kodPocztowy == s1Copy.kodPocztowy)
                Console.WriteLine("Serializacja OK");
            else
                Console.WriteLine("Błąd serializacji");

            // ================ ETAP II ================
            Console.WriteLine("*** ETAP II ***");
            el.SerializujObywatela(o2, el.name + "\\testO2.bin");
            Obywatel o2Copy = el.DeserializujObywatela(el.name + "\\testO2.bin");
            el.SerializujObywatela(o3, el.name + "\\testO3.bin");
            Obywatel o3Copy = el.DeserializujObywatela(el.name + "\\testO3.bin");
            if (o2.miasto == o2Copy.miasto && o3.miasto == o3Copy.miasto)
                Console.WriteLine("ZnajdzMiasto OK");
            else
                Console.WriteLine("Błąd ZnajdzMiasto");

            // ================ ETAP III ================
            Console.WriteLine("*** ETAP III ***");
            foreach (Obywatel o in obywatele)
                el.DodajObywatela(o);
            el.DodajObywatela(o1);

            // ================ ETAP IV ================
            Console.WriteLine("*** ETAP IV ***");
            el.UsunObywatela("93060187461");
            el.UsunObywatela("79090899762");
            el.UsunObywatela("93061635317");
            el.UsunObywatela("63060683413");
            el.UsunObywatela("93060187461");
            el.UsunObywatela("13091344999");

            // ================ ETAP V ================
            Console.WriteLine("*** ETAP V ***");
            Console.WriteLine("Liczba obywateli urudzonych w poniedziałek: " + el.IleUrodzonychWDniuTygodnia(DayOfWeek.Monday));
            Console.WriteLine("Liczba obywateli urudzonych w środę: " + el.IleUrodzonychWDniuTygodnia(DayOfWeek.Wednesday));
            Console.WriteLine("Liczba obywateli urudzonych w niedzielę: " + el.IleUrodzonychWDniuTygodnia(DayOfWeek.Sunday));

            Console.WriteLine("*** KONIEC ***");
        }
    }
}
