using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Linq;
using System.Collections;

namespace Brrrm_Core
{
    class Block
    {
        public string Name { get; private set; }
        public List<string> time = new List<string>();
        public Dictionary<string, List<double>> columms = new Dictionary<string, List<double>>();

        public Block(string name){
            this.Name = name;
        }
 
    }
    class Core
    {
        Dictionary<string, List<string>> colummns_Names = new Dictionary<string, List<string>>();
        private bool config = false;
        public void LoadConfig(string path)
        {
            path = @"D:\config.neco";
            using (TextReader tx = new StreamReader(path))
            {
                string line = tx.ReadLine();
                if (line != "start")
                    return;             
                bool cont = false;
                string[] data = new string[1];
                string name = "neco";
                int pocet = -1;
                bool end = false;
                while (true)
                {
                    if (end)
                        break;
                    if (!cont)
                        data = tx.ReadLine().Split('=');
                    else
                        cont = false;                
                    switch (data[0])
                    {
                        case "Name":
                            if (!colummns_Names.ContainsKey(data[1]))
                            {
                                name = data[1];
                                colummns_Names.Add(name, new List<string>());
                            }                              
                        ; break;
                        case "Pocet":
                            pocet = int.Parse(data[1]);
                            ; break;
                        case "Sloupce":
                            if(pocet != -1)
                                for (int i = 0; i < pocet; i++)
                                {
                                   var n = tx.ReadLine().Split('=');
                                   colummns_Names[name].Add(n[1]);
                                }
                                    
                            else
                            {
                                data = tx.ReadLine().Split('=');
                                int a;
                                if (int.TryParse(data[0], out a))
                                {
                                    colummns_Names[name].Add(data[1]);
                                }
                                else
                                {
                                    cont = true;
                                    continue;
                                }

                            }
                            pocet = -1;
                            ; break;
                        default: if (data[0] == "end") { end = true; continue; } else { continue; };
                    }

                }

            }
            Console.ReadKey();
        }
        public  Dictionary<string,List<double>> Parser(string path)
        {
            path = @"D:\MSB.csv";
            List<string> names = new List<string>();
            using(TextReader tx = new StreamReader(path))
            {
                for (int i = 0; i < 5; i++)
                    tx.ReadLine();    
                
            }
          
         

            return null;

        }
        private static  char Nevim(ref bool first, char rtrn)
        {
            first = !first;
            
            return rtrn;
        }
    }
  
}
