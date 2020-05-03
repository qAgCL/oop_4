using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlugIn
{
    public interface IHost
    {
        void AddComboBox(Control ctrl);
    }

    public interface IPlugin
    {
        string Name { get; }
        string Extension { get; }
        void Compress(string sourceFile);
        string Decompress(string sourceFile);
    }
}
