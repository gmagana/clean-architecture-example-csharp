using ClientBoundary;
using Lamar;

namespace Interactor {
    public class Interactor : IInteractor {
        private Container appContainer;

        public void SetAppContainer(Container newContainer) {
            this.appContainer = newContainer;
        }

        public string GetHelloFromInteractor(string myName) {
            return $"Interactor here, hello '{myName}'!";
        }

        public string GetHelloFromInteractorPlugin(string myName) {
            var plugin = this.appContainer.GetInstance<IPlugin>();
            return plugin.GetHello(myName);
        }

        public string GetHelloFromDataStore(string myName) {
            var dataStore = this.appContainer.GetInstance<IDataStore>();
            return dataStore.HelloOperation(myName);
        }
    }
}
