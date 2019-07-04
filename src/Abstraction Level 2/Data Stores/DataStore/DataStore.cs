using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interactor;

namespace DataStore {
    public class DataStore : IDataStore {
        public string HelloOperation(string myName) {
            return $"Data store, reporting for duty, {myName}!";
        }
    }
}
