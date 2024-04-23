using UnityEngine;

namespace Mendel.Objects
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public const float DEFAULT_SPEED = 5;   

        private void Start()
        {
            if (speed == 0)
            {
                speed = DEFAULT_SPEED;
            }
        }

        private void Update()
        {
            if (transform.position.y > (Camera.main.orthographicSize + Camera.main.transform.position.y))
            {
                Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            transform.position += speed * Time.deltaTime * transform.up;
        }

        public static void Create(Vector2 position)
        {
            GameObject bullet = Resources.Load<GameObject>("Prefabs/Bullet");
            bullet.transform.position = position;
            Instantiate(bullet);
        }
    }
}