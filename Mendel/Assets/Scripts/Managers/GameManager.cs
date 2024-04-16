using UnityEngine;

namespace Mendel.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Found more than one Game Manager in the scene.");
            }

            Instance = this;
        }
    }

}