using Example.ViewModel;
using NUnit.Framework;
using UniRx;


namespace Example.AsyncViewModel.Editor {
    public class AsyncLoginViewModelTests {

        [Test]
        public void InputName_Pass()
        {
            var viewModel = new LoginViewModel();

            Observable.Return("ABC").Subscribe(x => viewModel.InputNameCommand.Execute(x));

            Assert.AreEqual(LoginViewModel.SUCCESS_TIPS, viewModel.Tips.Value);
        }


    }
}
