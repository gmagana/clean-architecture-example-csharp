using Xunit;
using Xunit.Abstractions;

namespace InteractorTest {
    [Collection("InteractorTestCommon")]
    public class GeneralTest {
        public GeneralTest(ITestOutputHelper outputHelper, InteractorTestCommon common) {
            this._common = common;
            this._common.Initialize(outputHelper);
        }

        private readonly InteractorTestCommon _common;

        [Fact]
        public void Test1() {
            Assert.Equal(
                "Interactor here, hello 'Interactor Unit Test1'!",
                this._common.Interactor?.GetHelloFromInteractor("Interactor Unit Test1"));

            Assert.Equal(
                "Hello from Plugin, Interactor Unit Test2!",
                this._common.Interactor?.GetHelloFromInteractorPlugin("Interactor Unit Test2"));

            Assert.Equal(
                "Data store, reporting for duty, Interactor Unit Test3!",
                this._common.Interactor?.GetHelloFromDataStore("Interactor Unit Test3"));
        }
    }
}
