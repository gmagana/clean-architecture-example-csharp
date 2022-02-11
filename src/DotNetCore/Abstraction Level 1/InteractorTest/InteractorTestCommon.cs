using System;
using ClientBoundary;
using Lamar;
using Xunit.Abstractions;

namespace InteractorTest {
    public class InteractorTestCommon : IDisposable {
        private ITestOutputHelper? OutputHelper { get; set; }

        internal IInteractor? Interactor { get; private set; }

        public void Dispose() {
        }

        public void Initialize(ITestOutputHelper outputHelper) {
            this.OutputHelper = outputHelper;

            // If we've already created the interactor, we have nothing else to do
            if (this.Interactor != null) {
                return;
            }

            // Set up the IoC framework
            var reg = new InteractorTestContainer.InteractorTestContainer();
            reg.DoRegister();
            var appContainer = new Container(reg);
            this.Interactor = appContainer.GetInstance<IInteractor>();
            this.Interactor.SetAppContainer(appContainer);
            // Do other Interactor configuration here
        }
    }
}
