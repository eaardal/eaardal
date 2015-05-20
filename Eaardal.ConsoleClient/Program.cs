using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Eaardal.Startup;

namespace Eaardal.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = Bootstrapper.Wire();

            Console.ReadLine();
        }


    }
}
