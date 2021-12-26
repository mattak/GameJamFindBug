using FindBug.Application;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityHooks;

namespace FindBug.UI
{
    [RequireComponent(typeof(Button))]
    public class SlideNextButton : MonoBehaviour
    {
        private void Start()
        {
            this.GetComponent<Button>()
                .OnClickAsObservable()
                .Subscribe(_ => Next())
                .AddTo(this);
        }

        private void Next()
        {
            var hook = Hooks.UseState(HookKeys.SlidePosition);
            var slideMax = Hooks.UseState(HookKeys.SlideMax).Current;
            hook.Update(hook.Current + 1 % slideMax);
        }
    }
}