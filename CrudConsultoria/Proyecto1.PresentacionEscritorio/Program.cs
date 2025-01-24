using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1.PresentacionEscritorio
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application. SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIParent1());
        }
    }
}
