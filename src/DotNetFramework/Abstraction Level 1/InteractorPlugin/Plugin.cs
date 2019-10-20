using Interactor;

namespace InteractorPlugin {
    public class Plugin : IPlugin {
        public string GetHello(string myName) {
            return $"Hello from Plugin, {myName}!";
        }
    }
}
