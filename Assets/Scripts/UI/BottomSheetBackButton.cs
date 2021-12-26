using FindBug.Application;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using UnityHooks;

namespace FindBug.UI
{
    [RequireComponent(typeof(Image))]
    public class BottomSheetBackButton : MonoBehaviour
    {
        private void Start()
        {
            this.GetComponent<Image>().OnPointerDownAsObservable()
                .Subscribe(_ => Handle())
                .AddTo(this);
        }

        private void Handle()
        {
            Hooks.UseState(HookKeys.BottomSheet).Update(null);
        }
    }
}