using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brrrm
{
    public class Block
    {     
        public string Name { get; private set; }
        public List<string> time = new List<string>();
        public Dictionary<string, List<double>> columms = new Dictionary<string, List<double>>();

       public Block(string name)
       {
            this.Name = name;
       }
      public void Add(string name, double value)
      {
          if (columms.Keys.Contains(name))
                columms[name].Add(value);
          else
               columms.Add(name, new List<double>() { value });

         }
       
    }
}
