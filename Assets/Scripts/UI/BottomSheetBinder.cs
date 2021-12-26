using AnimeTask;
using Cysharp.Threading.Tasks;
using FindBug.Application;
using UniRx;
using UnityEngine;
using UnityHooks;

namespace FindBug.UI
{
    public class BottomSheetBinder : MonoBehaviour
    {
        [SerializeField] private RectTransform referenceWindow;
        [SerializeField] private RectTransform rootSheet;


        private RectTransform pushSheet = null;

        private void Start()
        {
            Hooks.UseState(HookKeys.BottomSheet).Value
                .Skip(1)
                .Subscribe(x => this.Render(x).Forget())
                .AddTo(this);
        }

        private async UniTask Render(RectTransform sheet)
        {
            if (sheet != null)
            {
                sheet.gameObject.SetActive(true);
                await UniTask.WhenAll(
                    Easing.Create<Linear>(0f, referenceWindow.rect.height, .5f).ToAnchoredPositionY(rootSheet),
                    Easing.Create<Linear>(-referenceWindow.rect.height, 0f, .5f).ToAnchoredPositionY(sheet)
                );
                pushSheet = sheet;
            }
            else if (pushSheet != null)
            {
                rootSheet.gameObject.SetActive(false);
                rootSheet.gameObject.SetActive(true);
                await UniTask.WhenAll(
                    Easing.Create<Linear>(referenceWindow.rect.height, 0f, .5f).ToAnchoredPositionY(rootSheet),
                    Easing.Create<Linear>(0f, -referenceWindow.rect.height, .5f).ToAnchoredPositionY(pushSheet)
                );
                pushSheet.gameObject.SetActive(false);
                pushSheet = null;
            }
        }
    }
}