using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Brrrm;

namespace Brrm_GUI
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Core core = new Core();
            core.LoadConfig("config");
            var neco = core.Parser("data");
            StringBuilder sb = new StringBuilder();
            foreach(var item in neco)
            {
                
                Debug.Print(item.Name);
                sb.AppendLine(item.Name); // číslo bloku
                foreach(var i in item.columms)
                {
                    sb.Append(i.Key+" => "); // název sloupce
                    foreach (var c in i.Value)
                        sb.Append(c + "   "); // data
                    sb.AppendLine();
                }
                
            }
            tbSettingText.Text = sb.ToString();
        }
    }
}
