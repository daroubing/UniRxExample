using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.Experimental.UIElements.Image;


namespace Example.AsyncViewModel
{
    public class AsyncLoginView : MonoBehaviour
    {
        private AsyncLoginViewModel mViewModel;

        private Text mTips;
        private InputField mInputName;

        private RectTransform mBusy;
        private Coroutine mDoBusy;


        private void Start()
        {
            mViewModel = new AsyncLoginViewModel();
            BindUI();
            BindEvent();
        }


        private void BindEvent()
        {
            mViewModel.Tips.SubscribeToText(mTips);
            mInputName.OnEndEditAsObservable().Subscribe(x => mViewModel.InputNameCommand.Execute(x));
            mViewModel.InputNameCommand.CanExecute.Select(x=>!x).Subscribe(ViewModel_Busy);
        }


        private void ViewModel_Busy(bool isBusy)
        {
            if (isBusy)
            {
                mBusy.gameObject.SetActive(true);
                mDoBusy = StartCoroutine(DoBusy());
            }
            else
            {
                mBusy.gameObject.SetActive(false);
                if (mDoBusy != null)
                {
                    StopCoroutine(mDoBusy);
                }
            }
        }


        private IEnumerator DoBusy()
        {
            while (true)
            {
                mBusy.Rotate(0, 0, -5);

                yield return null;
            }
            // ReSharper disable once IteratorNeverReturns
        }


        private void BindUI()
        {
            mTips = transform.Find("Panel/Tips").GetComponent<Text>();
            mInputName = transform.Find("Panel/InputName").GetComponent<InputField>();
            mBusy = transform.Find("Panel/Busy").GetComponent<RectTransform>();
        }
    }
}