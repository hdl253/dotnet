using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syntax
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal.Dogs.Single(o => o.name.Contains("3")).run();
            string a = Animal.Dogs.Single(o => o.name.Contains("3")).name;

            int intA = 'a';
            int intB = new Random().Next(1, 10000);
            int [] arrayA=new int[10];
            int [] arrayB=new int[intB];
        }
    }
    class Animal
    {
        public string name { get; set; }

        public void test() {

            Dogs.Single(o => o.name.Contains("3")).run();
        }
        private static List<Dog> mDogs = new List<Dog>();
        public static List<Dog> Dogs
        {
            get
            {
                if (mDogs == null || mDogs.Count<1)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        mDogs.Add(new Dog { name = "dog" + i });
                    }
                }
                return mDogs;
            }
        }
    }
    class Dog : Animal
    {
        public void run() {
            Console.WriteLine(this.name+" are running!");
        }
    }
}
