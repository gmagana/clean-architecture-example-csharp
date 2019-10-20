using Lamar;

namespace ClientBoundary {
    public interface IInteractor {
        void SetAppContainer(Container newContainer);

        string GetHelloFromInteractor(string myName);
        string GetHelloFromInteractorPlugin(string myName);
        string GetHelloFromDataStore(string myName);
    }
}
