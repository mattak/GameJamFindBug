using TMPro;
using UnityEngine;

namespace FindBug.UI
{
    public class SquareRenderer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void Render(string message)
        {
            text.text = message;
        }
    }
}