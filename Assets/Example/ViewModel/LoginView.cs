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


        private void BindEvent()
        {
            mViewModel.Tips.SubscribeToText(mTips);
            mInputName.OnEndEditAsObservable().Subscribe(x => mViewModel.InputNameCommand.Execute(x));
        }


        private void BindUI()
        {
            mTips = transform.Find("Panel/Tips").GetComponent<Text>();
            mInputName = transform.Find("Panel/InputName").GetComponent<InputField>();
        }
    }
}