using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppGenerics
{
    class Test<T>
    {
        readonly T _value;

        public Test(T t)
        {
            this._value = t;
        }

        public void Write()
        {
            Console.WriteLine(this._value);
        }
    }
    class Perl<V> where V : class, new()
    {
    }


    class Program
    {
        public delegate T add<T>(T param1, T param2);

        static void Main(string[] args)
        {
            Test<int> test1 = new Test<int>(5);
            test1.Write();

            Test<string> test2 = new Test<string>("Hello World!");
            test2.Write();

            List<bool> list1 = GetInitializedList(true, 5);
            List<string> list2 = GetInitializedList("Perls", 3);
            foreach(bool value in list1)
            {
                Test<bool> test = new Test<bool>(value);
                test.Write();
            }
            foreach (string value in list2)
            {
                Test<string> test = new Test<string>(value);
                test.Write();
            }

            Perl<Program> perl = new Perl<Program>();

            add<int> sum = AddNumber;
            new Test<int>(sum(10, 20)).Write();

            add<string> conct = Concate;
            new Test<string>(conct("Hello", "World!!")).Write();
        }

        static List<T> GetInitializedList<T>(T value, int count)
        {
            List<T> list = new List<T>();
            for(int i = 0; i < count; i++)
            {
                list.Add(value);
            }
            return list;
        }

        public static int AddNumber(int val1, int val2)
        {
            return val1 + val2;
        }

        public static string Concate(string str1, string str2)
        {
            return str1 + str2;
        }
    }
}
