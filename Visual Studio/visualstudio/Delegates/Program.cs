using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate void Func();

        static void PrintName()
        {
            Console.WriteLine("My name is what?");
        }



        static void Main(string[] args)
        {

            Func myFunction = new Func(PrintName);

            myFunction += PrintName;
            myFunction += PrintName;
            myFunction += PrintName;
            myFunction += PrintName;
            myFunction += PrintName;
            myFunction += PrintName;

            myFunction.Invoke();
            Console.ReadLine();
        }
    }
}
