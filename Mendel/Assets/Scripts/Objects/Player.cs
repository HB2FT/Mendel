using Mendel.Objects;
using System.Collections;
using UnityEngine;

namespace Mendel
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float fireTimeOffset;
        [SerializeField] private GameObject bulletSpawnPoint;
        private const float DEFAULT_FIRE_TIME_OFFSET = 1f;

        void Start()
        {
            if (fireTimeOffset == 0) fireTimeOffset = DEFAULT_FIRE_TIME_OFFSET;

            if (fireTimeOffset < 0)
            {
                Debug.LogWarning("Ateþ etmek için bekleme süresi negatif olamaz. Varsayýlan deðere döndürülüyor.");
                fireTimeOffset = DEFAULT_FIRE_TIME_OFFSET;
            }

            StartCoroutine(Fire());
        }

        void Update()
        {
        
        }

        IEnumerator Fire()
        {
            while (true)
            {
                Bullet.Create(bulletSpawnPoint.transform.position);
                yield return new WaitForSeconds(fireTimeOffset);
            }
        }

        private void CreateBullet()
        {

        }
    }
}
