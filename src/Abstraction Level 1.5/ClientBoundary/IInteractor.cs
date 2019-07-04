using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBoundary {
    public interface IInteractor {
        void SetAppContainer(Lamar.Container newContainer);

        string GetHelloFromInteractor(string myName);
        string GetHelloFromInteractorPlugin(string myName);
        string GetHelloFromDataStore(string myName);
    }
}