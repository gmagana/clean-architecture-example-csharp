using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using ClientBoundary;
using ClientConsoleScriptContainer;

namespace ClientConsoleScript {
    class Program {
        static void Main(string[] args) {
            // Set up the IoC framework
            var reg = new ConsoleScriptContainer();
            reg.DoRegister();
            var appContainer = new Lamar.Container(reg);
            var interactor = appContainer.GetInstance<IInteractor>();
            interactor.SetAppContainer(appContainer);

            // Make some calls
            Console.WriteLine($"Pinging interactor: {interactor.GetHelloFromInteractor("Console Application")}");
            Console.WriteLine($"Pinging interactor: {interactor.GetHelloFromInteractorPlugin("Console Application")}");
            Console.WriteLine($"Pinging interactor: {interactor.GetHelloFromDataStore("Console Application")}");
        }
    }
}
