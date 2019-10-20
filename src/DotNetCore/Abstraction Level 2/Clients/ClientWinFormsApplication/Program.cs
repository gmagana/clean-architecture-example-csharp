using System;
using System.Windows.Forms;
using ClientBoundary;
using ClientWinFormsApplicationContainer;
using Lamar;

namespace ClientWinFormsApplication {
    internal static class Program {
        public static IInteractor Interactor { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set up the IoC framework
            var reg = new WinformsApplicationContainer();
            reg.DoRegister();
            var appContainer = new Container(reg);
            Program.Interactor = appContainer.GetInstance<IInteractor>();
            Program.Interactor.SetAppContainer(appContainer);

            Application.Run(new Form1());
        }
    }
}
