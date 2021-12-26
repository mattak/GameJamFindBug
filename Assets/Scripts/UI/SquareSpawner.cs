using UnityEngine;

namespace FindBug.UI
{
    public class SquareSpawner : MonoBehaviour
    {
        [SerializeField] private string[] messages;
        [SerializeField] private SquareRenderer okPrefab;
        [SerializeField] private SquareRenderer ngPrefab;

        private void Start()
        {
            var squares = new GameObject[messages.Length];
            
            for (var i = 0; i < messages.Length; i++)
            {
                var prefab = i == 0 ? okPrefab : ngPrefab;
                var square = Instantiate(prefab, this.transform);
                square.Render(messages[i]);
                squares[i] = square.gameObject;
            }

            this.GetComponent<ShuffleRender>()?.Shuffle(squares);
        }
    }
}