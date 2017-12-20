using NUnit.Framework;
using UniRx;


namespace Example.ViewModel.Editor
{
    public class LoginViewModelTests
    {
        [Test]
        public void InputPassword_Success()
        {
            var viewModel = new LoginViewModel();

            Observable.Return(LoginViewModel.PASSWORD).Subscribe(x => viewModel.InputPasswordCommand.Execute(x));

            Assert.AreEqual(LoginViewModel.SUCCESS_TIPS, viewModel.Tips.Value);
        }


        [Test]
        public void InputPassword_Error()
        {
            var viewModel = new LoginViewModel();

            Observable.Return("ErrorPassword").Subscribe(x => viewModel.InputPasswordCommand.Execute(x));

            Assert.AreEqual(LoginViewModel.ERROR_TIPS, viewModel.Tips.Value);
        }
    }
}