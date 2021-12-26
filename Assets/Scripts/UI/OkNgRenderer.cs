using System;
using AnimeTask;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace FindBug.UI
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(AudioSource))]
    public class OkNgRenderer : MonoBehaviour
    {
        public async UniTask Animate()
        {
            var image = this.GetComponent<Image>();
            var audioSource = this.GetComponent<AudioSource>();
            
            image.enabled = true;
            audioSource.Play();
            await Easing.Create<InQuad>(start: 1f, end: 0f, duration: 0f).ToColorA(image);
            await Easing.Create<InQuad>(start: 0f, end: 1f, duration: 0.1f).ToColorA(image);
            await Easing.Create<InQuad>(start: 1f, end: 1f, duration: 0.6f).ToColorA(image);
            await Easing.Create<InQuad>(start: 1f, end: 0f, duration: 0.1f).ToColorA(image);
            image.enabled = false;
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        }
    }
}