using UnityEngine;

namespace Mendel.Objects
{
    public class ScreenBorder : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D boxCollider;

        void Start()
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        void Update()
        {
            ResizeCollider();
        }

        void ResizeCollider()
        {
            float height = 2f * Camera.main.orthographicSize;
            float width = height * Camera.main.aspect;

            boxCollider.size = new Vector2(width, height);
        }
    }
}
