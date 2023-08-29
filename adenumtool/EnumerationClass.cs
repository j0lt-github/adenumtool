using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace adenumtool
{
    class EnumerationClass
    {
        public string output { get; set; }

        public void GetDomain()
        {
            try
            {
                Domain domain = Domain.GetCurrentDomain();

                var dcNames = from DomainController dc in domain.DomainControllers
                              select dc.Name;

                var childNames = from Domain child in domain.Children
                                 select child.Name;

                string result = $"###################### Current Domain Information ######################\n" +
                                    $"Forest                  : {domain.Forest.Name}\n" +
                                    $"DomainControllers       : {{ {string.Join(", ", dcNames)} }}\n" +
                                    $"Children                : {{ {string.Join(", ", childNames)} }}\n" +
                                    $"DomainMode              : {domain.DomainMode}\n" +
                                    $"DomainModeLevel         : {(int)domain.DomainMode}\n" +
                                    $"Parent                  : {domain.Parent}\n" +
                                    $"PdcRoleOwner            : {domain.PdcRoleOwner}\n" +
                                    $"RidRoleOwner            : {domain.RidRoleOwner}\n" +
                                    $"InfrastructureRoleOwner : {domain.InfrastructureRoleOwner}\n" +
                                    $"Name                    : {domain.Name}\n" +
                                    "--------------------------------------------------";

                output += result + "\n";
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Fetching Current Domain Information");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void GetForestDomain()
        {
            try
            {
                Forest currentForest = Forest.GetCurrentForest();
                
                foreach (Domain domain in currentForest.Domains)
                {
                    var dcNames = from DomainController dc in domain.DomainControllers
                                  select dc.Name;

                    var childNames = from Domain child in domain.Children
                                     select child.Name;
                    string result = $"###################### Forest Domain Information For Domain -  {domain.Name} ######################\n" +
                                    $"Forest                  : {domain.Forest.Name}\n" +
                                    $"DomainControllers       : {{ {string.Join(", ", dcNames)} }}\n" +
                                    $"Children                : {{ {string.Join(", ", childNames)} }}\n" +
                                    $"DomainMode              : {domain.DomainMode}\n" +
                                    $"DomainModeLevel         : {(int)domain.DomainMode}\n" +
                                    $"Parent                  : {domain.Parent}\n" +
                                    $"PdcRoleOwner            : {domain.PdcRoleOwner}\n" +
                                    $"RidRoleOwner            : {domain.RidRoleOwner}\n" +
                                    $"InfrastructureRoleOwner : {domain.InfrastructureRoleOwner}\n" +
                                    $"Name                    : {domain.Name}\n" +
                                    "--------------------------------------------------";

                    output += result + "\n";
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Fetching Forest Domain Information");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void GetDomainControllerAll()
        {
            try
            {
                Forest currentForest = Forest.GetCurrentForest();

                foreach (Domain domain in currentForest.Domains)
                {
                    foreach (DomainController dc in domain.DomainControllers)
                    {
                        string result = $"########## Domain Controller Information For DC -  {dc.Name} for Domain - {domain.Name} ##########\n" +
                            $"Forest    : {dc.Forest}\n" +
                                        $"Domain    : {dc.Domain}\n" +
                                        $"Name      : {dc.Name}\n" +
                                        $"OSVersion : {dc.OSVersion}\n" +
                                        "--------------------------------------------------";
                        output += result + "\n";
                        Console.WriteLine(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Fetching All Domain Controller Information");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public void GetDomainController()
        {
            try
            {
                Domain domain = Domain.GetCurrentDomain();

                foreach (DomainController dc in domain.DomainControllers)
                {
                    string result = $"###################### Domain Controller Information For DC -  {dc.Name} for Domain - {domain.Name} ######################" +
                        $"Forest    : {dc.Forest}\n" +
                                    $"Domain    : {dc.Domain}\n" +
                                    $"Name      : {dc.Name}\n" +
                                    $"OSVersion : {dc.OSVersion}\n" +
                                    "--------------------------------------------------";
                    output += result + "\n";
                    Console.WriteLine(result);
                }
            
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Fetching Domain Controller Information of Current Domain");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

