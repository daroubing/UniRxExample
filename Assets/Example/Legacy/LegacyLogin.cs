using Example.ViewModel;
using UniRx;
using UnityEngine;
using UnityEngine.UI;


namespace Example.Legacy
{
    public class LegacyLogin : MonoBehaviour
    {
        private Text mTips;
        private InputField mInputName;


        private void Start()
        {
            BindUI();

            BindEvent();

            Init();
        }


        private void BindUI()
        {
            mTips = transform.Find("Panel/Tips").GetComponent<Text>();
            mInputName = transform.Find("Panel/InputName").GetComponent<InputField>();
        }


        private void BindEvent()
        {
            //难以测试
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

            //较易测试
//            mInputName.onEndEdit.AddListener(name =>
//            {
//                mTips.text = InputPassword(name);
//            });
        }


        internal string InputPassword(string name)
        {
            if (name.Equals("ABC"))
            {
                return "密码输入正确";
            }
            else
            {
                return "密码输入错误";
            }
        }


        private void Init()
        {
            mTips.text = "请输入密码";
        }
    }
}