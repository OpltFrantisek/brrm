using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Brrrm
{
    public class Class1
    {


    }
    public class Core
    {
        List<Block> blocks = new List<Block>();
        Dictionary<int, List<string>> colummns_Names = new Dictionary<int, List<string>>();
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
                int name = -1;
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
                            if (!colummns_Names.ContainsKey(int.Parse(data[1])))
                            {
                                name = int.Parse(data[1]);
                                colummns_Names.Add(name, new List<string>());
                            }
                        ; break;
                        case "Pocet":
                            pocet = int.Parse(data[1]);
                            ; break;
                        case "Sloupce":
                            if (pocet != -1)
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
        }
        public List<Block> Parser(string path)
        {
            path = @"D:\vento.LOG";
            List<string> names = new List<string>();
            using (TextReader tx = new StreamReader(path))
            {
                for (int i = 0; i < 5; i++)
                    tx.ReadLine();
                string line;
                while ((line = tx.ReadLine()) != null)
                {
                  
                    var neco = line.Split(new [] { "BL:" },StringSplitOptions.RemoveEmptyEntries);
                    string[] sloupce;
                    for (int i = 1; i < neco.Length; i++)
                    {

                        sloupce = neco[i].Split(new[] { "   " },StringSplitOptions.RemoveEmptyEntries);
                        string number;
                        if (i == 1)
                            number = sloupce[0];
                        else
                            number = sloupce[0].Split(new[] { "  " },StringSplitOptions.RemoveEmptyEntries)[0];
                        var block = (from x in blocks where x.Name == number select x).ToArray();
                        Block bc = block.Count() == 0 ? new Block(number) : block[0];

                        for (int j = 1; j < sloupce.Length; j++)
                        {
                            if (sloupce[j] == "" || sloupce[j] == "  " || sloupce[j] == " ")
                            {
                                j = int.MaxValue - 1;
                                continue;
                            }

                            string name = colummns_Names[int.Parse(number)][j - 1];
                            string[] v = sloupce[j].Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries);
                            double value;
                            if (v.Count() > 2)
                                value = double.Parse(v[v.Count() - 2]);
                            else
                                value = double.Parse(v[0]);
                            bc.Add(name, value);
                        }
                        if (block.Count() == 0)
                            blocks.Add(bc);
                    }
                }
                return blocks;
            }
        }
    }
}
