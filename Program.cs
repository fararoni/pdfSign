using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nekdu
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Splash());
            } catch (Exception ex) {
                //TODO. Mostrar todos los mensajes acumulados.
                MessageBox.Show(
                       "Se ha presentado un error, reporte el siguiente error a su administrador:" + ex.Message + "."
                       , "Precaución"
                       , MessageBoxButtons.OK
                       , MessageBoxIcon.Warning);
            }
        }
    }
}
