using System;

namespace Lab08_a
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------ETAP I----------------------------");
            string s1 = " ";
            string duplicated = s1.DuplicateCharacters();
            Console.WriteLine(duplicated);
            s1 = "a";
            duplicated = s1.DuplicateCharacters();
            Console.WriteLine(duplicated);
            s1 = "abcdefghijklmno";
            duplicated = s1.DuplicateCharacters();
            Console.WriteLine(duplicated);
            s1 = "Programowanie Zaawansowane";
            duplicated = s1.DuplicateCharacters();
            Console.WriteLine(duplicated);


            Console.WriteLine("\n---------------ETAP III----------------------------\n");

            MyList<int> test1 = new MyList<int>();
            Random rnd = new Random(555);
            for (int i = 0; i < 10; i++)
                test1.Add(rnd.Next(100));
            test1.ToString();

            Console.WriteLine(test1);
            Console.WriteLine("Size is: " + test1.Size);
            test1.RemoveLast();
            Console.WriteLine(test1.ToString());
            Console.WriteLine("Size is: " + test1.Size);

            test1.RemoveLast();
            Console.WriteLine(test1.ToString());
            Console.WriteLine("Size is: " + test1.Size);

            test1.RemoveLast();
            Console.WriteLine(test1.ToString());
            Console.WriteLine("Size is: " + test1.Size);

            var first = test1.Get(0);
            Console.WriteLine("first: {0}, Size is: {1} ", first, test1.Size);
            var second = test1.Get(1);
            Console.WriteLine("second: {0}, Size is: {1} ", second, test1.Size);

            MyList<int> test2 = new MyList<int>();
            for (int i = 0; i < 10; i++)
                test2.Add(rnd.Next(100));

            // no exception expected
            while (test2.Size != 0)
            {
                test2.RemoveLast();
                Console.WriteLine(test2.ToString());
            }
            try
            {
                test2.RemoveLast();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception! : " + e.Message);
            }

            try
            {
                var head = test2.Get(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception! : " + e.Message);
            }

            test2.Add(3);
            test2.Add(3);
            test2.Add(3);
            Console.WriteLine(test2.ToString());

            Console.WriteLine("\n---------------ETAP IV----------------------------\n");

            SortedMyList<int> sorted = new SortedMyList<int>();
            for (int i = 0; i < 15; i++)
            {
               // Console.WriteLine("{0}", rnd.Next(100));
                sorted.Add(rnd.Next(100));
            }

            Console.WriteLine(sorted.ToString());

            Console.WriteLine();
            sorted.RemoveLast();
            Console.WriteLine(sorted.ToString());
            Console.WriteLine("Size is: " + sorted.Size);

            sorted.RemoveLast();
            Console.WriteLine(sorted.ToString());
            Console.WriteLine("Size is: " + sorted.Size);

            Console.WriteLine();

            first = sorted.Get(0);
            Console.WriteLine("first: {0}, Size is: {1} ", first, sorted.Size);
            second = sorted.Get(1);
            Console.WriteLine("second: {0}, Size is: {1} ", second, sorted.Size);
            Console.WriteLine();


            Console.WriteLine("test1 not sorted:");
            Console.WriteLine(test1.ToString());
            Console.WriteLine("test1 sorted:");
            SortedMyList<int> sortedTest1 = new SortedMyList<int>();
            for (int i = 0; i < test1.Size; i++)
                sortedTest1.Add(test1.Get(i));
            Console.WriteLine(sortedTest1.ToString());

            while (sorted.Size != 0)
            {
                sorted.RemoveLast();
                Console.WriteLine(sorted.ToString());
            }
            try
            {
                sorted.RemoveLast();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception! : " + e.Message);
            }

            try
            {
                var head = sorted.Get(0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception! : " + e.Message);
            }

            sorted.Add(3);
            Console.WriteLine(sorted.ToString());

            Console.WriteLine("\n---------------ETAP V----------------------------\n");

            SortedMyList<int> test3 = new SortedMyList<int>();
            ////test3.GetPeopleCountPowerOfTwoAge(); //this line should give compile error

            SortedMyList<Person> people = new SortedMyList<Person>();
            people.Add(new Person { Name = "Anthony", Age = 22 });
            people.Add(new Person { Name = "John", Age = 32 });
            people.Add(new Person { Name = "Gabriel", Age = 25 });
            people.Add(new Person { Name = "Natalia", Age = 27 });
            people.Add(new Person { Name = "Jenny", Age = 16 });
            people.Add(new Person { Name = "Joe", Age = 19 });
            people.Add(new Person { Name = "Goerge", Age = 128 });
            people.Add(new Person { Name = "Jesus", Age = 2048 });
            people.Add(new Person { Name = "Anthony", Age = 50 });
            people.Add(new Person { Name = "Joe", Age = 15 });
            Console.WriteLine(people.ToString());
            //int numberOfPeople = people.GetPeopleCountPowerOfTwoAge();
            //Console.WriteLine("Age power of two: " + numberOfPeople);
            people.RemoveLast();
            people.RemoveLast();
            people.RemoveLast();
            Console.WriteLine(people.ToString());
            //numberOfPeople = people.GetPeopleCountPowerOfTwoAge();
            //Console.WriteLine("Age power of two: " + numberOfPeople);
        }
    }
}
