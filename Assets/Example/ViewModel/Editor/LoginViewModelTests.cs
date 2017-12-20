using NUnit.Framework;
using UniRx;


namespace Example.ViewModel.Editor {
    public class LoginViewModelTests {

        [Test]
        public void InputName_Pass()
        {
            var viewModel = new LoginViewModel();

            Observable.Return("ABC").Subscribe(x => viewModel.InputPasswordCommand.Execute(x));

            Assert.AreEqual(LoginViewModel.SUCCESS_TIPS, viewModel.Tips.Value);
        }


    }
}
