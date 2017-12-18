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


            mTips = transform.Find("Panel/Tips").GetComponent<Text>();
            mInputName = transform.Find("Panel/InputName").GetComponent<InputField>();

            Old();
//            mViewModel.Tips.SubscribeToText(mTips);
//            mInputName.OnEndEditAsObservable().Subscribe(x => mViewModel.InputNameCommand.Execute(x));
        }


        private void Old()
        {
            mTips.text = "请输入密码";

            mInputName.onEndEdit.AddListener(name =>
            {
                if (name.Equals("ABC"))
                {
                    mTips.text = "密码输入正确";
                }
                else
                {
                    mTips.text = "密码输入错误";
                }
            });
        }
    }
}