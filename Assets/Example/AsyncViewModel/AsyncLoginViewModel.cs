using System;
using UniRx;


namespace Example.AsyncViewModel
{
    public class AsyncLoginViewModel
    {
        public const string PASSWORD = "ABC";

        public const string INPUT_TIPS = "请输入密码";
        public const string SUCCESS_TIPS = "密码正确";
        public const string ERROR_TIPS = "密码错误,请重新输入";

        public StringReactiveProperty Tips { get; private set; }

        public AsyncReactiveCommand<string> InputNameCommand { get; private set; }


        public AsyncLoginViewModel()
        {
            Tips = new StringReactiveProperty(INPUT_TIPS);

            InputNameCommand = new AsyncReactiveCommand<string>();
            InputNameCommand.Subscribe(InputPassword);
        }


        //TODO Byron 2017.12.18 使用回调进行消息,不好测试?
        //TODO Byron 2017.12.18 请求超时如何处理,使用回调?线程阻塞,或者异步?
        private IObservable<Unit> InputPassword(string password)
        {
            return Observable.Timer(TimeSpan.FromSeconds(3)).AsUnitObservable();
            return Observable.ReturnUnit().TakeUntil(Observable.Timer(TimeSpan.FromSeconds(3)));
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