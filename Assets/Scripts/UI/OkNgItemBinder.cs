using System;
using FindBug.Application;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityHooks;

namespace FindBug.UI
{
    [RequireComponent(typeof(Image))]
    public class OkNgItemBinder : MonoBehaviour
    {
        [SerializeField] private bool isCorrect = false;

        private void Start()
        {
            this.GetComponent<Image>()
                .OnPointerDownAsObservable()
                .Do(x => UnityEngine.Debug.Log($"onClick: {isCorrect}"))
                .ThrottleFirst(TimeSpan.FromSeconds(1f))
                .Subscribe(this.Handle)
                .AddTo(this);
        }

        private void Handle(PointerEventData _)
        {
            Hooks.UseState(HookKeys.IsOkNg).Update(isCorrect);
        }
    }
}