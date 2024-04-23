using Mendel.Objects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Mendel
{
    public class EnemyManager : MonoBehaviour
    {
        // Enemy grid
        public const int HORIZONTAL_ENEMY_COUNT = 8;
        public const int VERTICAL_ENEMY_COUNT = 2;

        [SerializeField] private int rowOffset;
        [SerializeField] private int columnOffset;

        [SerializeField] private List<Enemy> enemies;

        public static EnemyManager instance;
        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Found more than one Enemy Manager in the scene.");
            }
            instance = this;
        }

        void Start()
        {
            enemies = new List<Enemy>();

            CalculateRowsAndColumns();
            CreateEnemies();
        }

        
        void Update()
        {
        
        }

        private void CalculateRowsAndColumns()
        {
            rowOffset = Screen.width / HORIZONTAL_ENEMY_COUNT;
            columnOffset = Screen.height / VERTICAL_ENEMY_COUNT;
        }

        private void CreateEnemies()
        {
            for (int i = 0; i < HORIZONTAL_ENEMY_COUNT; i++)
            {
                for (int j = 0; j < VERTICAL_ENEMY_COUNT; j++)
                {
                    InstantiateEnemy(i, j);
                }
            }
        }

        private void InstantiateEnemy(int i, int j)
        {
            int enemyIndex = GenerateRandom();

            GameObject enemy = Resources.Load<GameObject>("Prefabs/Enemy" + enemyIndex);
            enemy.transform.position = new Vector3((-CameraWidth / 2) + ((CameraWidth / (HORIZONTAL_ENEMY_COUNT - 1)) -.75f) * (i + 1), (CameraHeight / 2) - (1.5f * j) - 1);

            Instantiate(enemy);
        }

        int temp;
        private int GenerateRandom()
        {
            int num = Random.Range(1, 5);

            if (temp == num)
            {
                return GenerateRandom();
            }
            else
            {
                Debug.Log("Generated random number for enemy sprite: " + num);
                temp = num;
                return num;
            }


        }

        private float CameraHeight
        {
            get
            {
                return Camera.main.orthographicSize * 2;
            }
        }

        private float CameraWidth
        {
            get
            {
                return Camera.main.aspect * CameraHeight;
            }
        }
    }
}
