using System;
using Cysharp.Threading.Tasks;
using FindBug.Application;
using UniRx;
using UnityEngine;
using UnityHooks;

namespace FindBug.UI
{
    public class OkNgBinder : MonoBehaviour
    {
        [SerializeField] private OkNgRenderer okRenderer;
        [SerializeField] private OkNgRenderer ngRenderer;

        private void Start()
        {
            Hooks.UseState(HookKeys.IsOkNg).Value
                .Where(x => x.HasValue)
                .Select(x => x.Value)
                .ThrottleFirst(TimeSpan.FromSeconds(1f))
                .Subscribe(isOK => this.Render(isOK).Forget())
                .AddTo(this);
        }

        private async UniTask Render(bool isOk)
        {
            if (isOk)
            {
                await okRenderer.Animate();
                Next();
            }
            else
            {
                await ngRenderer.Animate();
            }
        }

        private void Next()
        {
            var slidePosition = Hooks.UseState(HookKeys.SlidePosition);
            var slideMax = Hooks.UseState(HookKeys.SlideMax);
            var nextPosition = (slidePosition.Current + 1) % slideMax.Current;
            slidePosition.Update(nextPosition);
        }
    }
}