using UniRx;


namespace Example.ViewModel
{
    public class LoginViewModel
    {
        public const string PASSWORD = "ABC";

        public const string INPUT_TIPS = "请输入密码";
        public const string SUCCESS_TIPS = "密码正确";
        public const string ERROR_TIPS = "密码错误,请重新输入";

        public StringReactiveProperty Tips { get; private set; }

        public ReactiveCommand<string> InputNameCommand { get; private set; }


        public LoginViewModel()
        {
            Tips = new StringReactiveProperty(INPUT_TIPS);

            InputNameCommand = new ReactiveCommand<string>();
            InputNameCommand.Subscribe(InputName);
        }


        private void InputName(string name)
        {
            if (name.Equals(PASSWORD))
            {
                Tips.Value = SUCCESS_TIPS;
            }
            else
            {
                Tips.Value = ERROR_TIPS;
            }
        }
    }
}