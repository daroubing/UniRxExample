using UniRx;


namespace Example.ViewModel
{
    public class LoginViewModel
    {
        /// <summary>
        /// 正确的密码
        /// </summary>
        public const string PASSWORD = "ABC";

        /// <summary>
        /// 提示初始化文字
        /// </summary>
        public const string INPUT_TIPS = "请输入密码";

        //正确提示与错误提示
        public const string SUCCESS_TIPS = "密码正确";

        public const string ERROR_TIPS = "密码错误,请重新输入";

        public ReadOnlyReactiveProperty<string> Tips { get; private set; }

        public ReactiveCommand<string> InputPasswordCommand { get; private set; }


        public LoginViewModel()
        {
            InputPasswordCommand = new ReactiveCommand<string>();

            //绑定输入命令,检查密码,转换为提示内容
            Tips = InputPasswordCommand.Select(CheckName).StartWith(INPUT_TIPS).ToReadOnlyReactiveProperty();
        }


        private string CheckName(string name)
        {
            return name.Equals(PASSWORD) ? SUCCESS_TIPS : ERROR_TIPS;
        }
    }
}