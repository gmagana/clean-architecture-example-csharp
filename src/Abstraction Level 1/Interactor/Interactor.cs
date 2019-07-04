using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientBoundary;

namespace Interactor {
    public class Interactor : IInteractor {

        private Lamar.Container appContainer;

        public void SetAppContainer(Lamar.Container newContainer) {
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
