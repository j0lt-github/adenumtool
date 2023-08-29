using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.Net;
using System.Security.Cryptography;
using System.Dynamic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;

namespace adenumtool
{
    internal class Program
    {
        private static HashSet<string> ValidInputs = new HashSet<string>() {
            "Get-Domain",
            "Get-ForestDomain",
            "Get-DomainController",
            "Get-DomainControllerAll",
            "EveryThing",
            "NeedOutput"
        };
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a valid command.");
                return;
            }
            if (args.Any(arg => !ValidInputs.Contains(arg)))
            {
                Console.WriteLine("Invalid input");
                return;
            }
            EnumerationClass enumerationClass = new EnumerationClass();
            foreach (string input in args) {
            switch (input)
                {
                    case "Get-Domain":
                        enumerationClass.GetDomain();
                        break;
                    case "Get-ForestDomain":
                        enumerationClass.GetForestDomain();
                        break;
                    case "Get-DomainController":
                        enumerationClass.GetDomainController();
                        break;
                    case "Get-DomainControllerAll":
                        enumerationClass.GetDomainControllerAll();
                        break;
                    case "EveryThing":
                        enumerationClass.GetDomain();
                        enumerationClass.GetForestDomain();
                        enumerationClass.GetDomainControllerAll();
                        break;
                }
            }
            if (args.Contains("NeedOutput"))
            {
                File.WriteAllText("./output.txt", enumerationClass.output);
            }
        }
    }
}
