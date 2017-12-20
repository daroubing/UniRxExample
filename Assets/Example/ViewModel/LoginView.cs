using UniRx;
using UnityEngine;
using UnityEngine.UI;


namespace Example.ViewModel
{
    public class LoginView : MonoBehaviour
    {
        private LoginViewModel mViewModel;

        private Text mTips;
        private InputField mInputName;

        private void Start()
        {
            mViewModel = new LoginViewModel();
            BindUI();
            BindEvent();
        }

        private void BindUI()
        {
            mTips = transform.Find("Panel/Tips").GetComponent<Text>();
            mInputName = transform.Find("Panel/InputName").GetComponent<InputField>();
        }

        private void BindEvent()
        {
            //绑定提示信息,显示到提示栏
            mViewModel.Tips.SubscribeToText(mTips);
            //订阅输入完成,执行输入命令
            mInputName.OnEndEditAsObservable().Subscribe(x => mViewModel.InputPasswordCommand.Execute(x));
        }
    }
}