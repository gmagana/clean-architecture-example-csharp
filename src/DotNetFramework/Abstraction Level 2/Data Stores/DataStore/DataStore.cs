using Interactor;

namespace DataStore {
    public class DataStore : IDataStore {
        public string HelloOperation(string myName) {
            return $"Data store, reporting for duty, {myName}!";
        }
    }
}
