using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QUẢN_LÝ_SẢN_PHẨM
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_MAIN());
        }
    }
}
