using System;
using AnimeTask;
using Cysharp.Threading.Tasks;
using FindBug.Application;
using UniRx;
using UnityEngine;
using UnityHooks;

namespace FindBug.UI
{
    public class SlideShowBinder : MonoBehaviour
    {
        [SerializeField] private RectTransform slideWindow;

        [SerializeField] private RectTransform[] slides;
        private int current = 0;

        private void Start()
        {
            Hooks.UseState(HookKeys.SlidePosition).Value
                .Where(x => x >= 0 && x < slides.Length)
                .Where(x => x != current)
                .ThrottleFirst(TimeSpan.FromSeconds(1f))
                .Subscribe(next => this.Render(next).Forget())
                .AddTo(this);

            Hooks.UseState(HookKeys.SlideMax).Update(slides.Length);
        }

        private async UniTask Render(int next)
        {
            for (var i = 0; i < slides.Length; i++)
            {
                var isActive = i == current || i == next;
                slides[i].gameObject.SetActive(isActive);
            }


            await UniTask.WhenAll(
                Easing.Create<Linear>(0, -slideWindow.rect.width, 0.5f).ToAnchoredPositionX(slides[current]),
                Easing.Create<Linear>(slideWindow.rect.width, 0, 0.5f).ToAnchoredPositionX(slides[next])
            );
            
            slides[current].gameObject.SetActive(false);
            current = next;
        }
    }
}