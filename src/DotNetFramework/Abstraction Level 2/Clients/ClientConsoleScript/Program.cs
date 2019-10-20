using System;
using ClientBoundary;
using ClientConsoleScriptContainer;
using Lamar;

namespace ClientConsoleScript {
    internal class Program {
        private static void Main(string[] args) {
            // Set up the IoC framework
            var reg = new ConsoleScriptContainer();
            reg.DoRegister();
            var appContainer = new Container(reg);
            var interactor = appContainer.GetInstance<IInteractor>();
            interactor.SetAppContainer(appContainer);

            // Make some calls
            Console.WriteLine($"Pinging interactor: {interactor.GetHelloFromInteractor("Console Application")}");
            Console.WriteLine($"Pinging interactor: {interactor.GetHelloFromInteractorPlugin("Console Application")}");
            Console.WriteLine($"Pinging interactor: {interactor.GetHelloFromDataStore("Console Application")}");
        }
    }
}
