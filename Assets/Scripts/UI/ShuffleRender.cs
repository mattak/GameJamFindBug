using FindBug.Application;
using UnityEngine;

namespace FindBug.UI
{
    public class ShuffleRender : MonoBehaviour
    {
        [SerializeField] private GameObject[] objects = default;

        private void OnEnable()
        {
            if (objects.Length > 1)
            {
                Shuffle(objects);
            }
        }

        public void Shuffle(GameObject[] targets)
        {
            var newObjects = targets.DShuffle();

            foreach (Transform t in this.transform)
            {
                t.SetParent(null);
            }

            foreach (var t in newObjects)
            {
                t.transform.SetParent(this.transform);
            }
        }
    }
}