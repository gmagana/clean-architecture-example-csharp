using ClientBoundary;
using Interactor;
using InteractorPlugin;
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

            // Add all Plugin instances here
            this.For<IPlugin>()
                .Use<Plugin>();
        }
    }
}
