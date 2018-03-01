using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Logging
{
    /// <summary>
    /// Interaction logic for BlueLogger.xaml
    /// </summary>
    public partial class BlueLogger : Window, ILogger
    {
        private static BlueLogger instance = null;

        private BlueLogger()
        {
            Entries = new List<Tuple<string, string>>();
            InitializeComponent();
            Show();
        }

        public IList<Tuple<string, string>> Entries { get; private set; }

        public static BlueLogger GetInstance()
        {
            return instance ?? (instance = new BlueLogger());
        }

        public void AddLogEntry(string tag, string entry)
        {
            Entries.Add(new Tuple<string, string>(tag, entry));
            LogTextBox.AppendText(tag + ": " + entry + "\n");
        }
    }
}
