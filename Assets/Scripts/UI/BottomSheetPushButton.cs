using FindBug.Application;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityHooks;

namespace FindBug.UI
{
    [RequireComponent(typeof(Image))]
    public class BottomSheetPushButton : MonoBehaviour
    {
        [SerializeField] private RectTransform pushSheet;

        private void Start()
        {
            Assert.IsNotNull(pushSheet);

            this.GetComponent<Image>().OnPointerDownAsObservable()
                .Subscribe(_ => Handle())
                .AddTo(this);
        }

        private void Handle()
        {
            Hooks.UseState(HookKeys.BottomSheet).Update(pushSheet);
        }
    }
}