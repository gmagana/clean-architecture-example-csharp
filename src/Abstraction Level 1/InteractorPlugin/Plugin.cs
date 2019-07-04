using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interactor;

namespace InteractorPlugin {
    public class Plugin : IPlugin {
        public string GetHello(string myName) {
            return $"Hello from Plugin, {myName}!";
        }
    }
}
