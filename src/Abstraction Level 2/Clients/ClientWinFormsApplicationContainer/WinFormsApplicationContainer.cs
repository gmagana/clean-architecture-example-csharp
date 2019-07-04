using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientBoundary;
using Interactor;
using Lamar;

namespace ClientWinFormsApplicationContainer {
    public class WinformsApplicationContainer : ServiceRegistry {
        public void DoRegister() {
            this.Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            this.For<IInteractor>()
                .Use<Interactor.Interactor>();
            this.For<IDataStore>().Use<DataStore.DataStore>();

            // Add all Suspicious Item Detector instances here
            this.For<IPlugin>()
                .Use<InteractorPlugin.Plugin>();
        }
    }
}
