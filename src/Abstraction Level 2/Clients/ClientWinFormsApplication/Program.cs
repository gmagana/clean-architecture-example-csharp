using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientBoundary;
using ClientWinFormsApplicationContainer;

namespace ClientApplication {
    static class Program {

        public static IInteractor Interactor { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set up the IoC framework
            var reg = new WinformsApplicationContainer();
            reg.DoRegister();
            var appContainer = new Lamar.Container(reg);
            Program.Interactor = appContainer.GetInstance<IInteractor>();
            Program.Interactor.SetAppContainer(appContainer);

            Application.Run(new FrmMain());
        }
    }
}
