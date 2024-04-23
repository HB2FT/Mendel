using Mendel.Objects;
using UnityEngine;

namespace Mendel
{
    public class DragManager : MonoBehaviour
    {
        [SerializeField] private bool isDragActive;

        [SerializeField] private Vector2 screenPosition;
        [SerializeField] private Vector3 worldPosition;

        [SerializeField] private Draggable lastDragged;

        public static DragManager instance;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Found more than one Drag Manager in the scene.");
            }
            instance = this;
        }

        void Start()
        {

        }

        void Update()
        {
            StayInScreen(); 

            if (isDragActive && (Input.GetMouseButtonUp(0) 
                || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
            {
                Drop();
                return;
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;
                screenPosition = new Vector2(mousePos.x, mousePos.y);
            }

            else if (Input.touchCount > 0)
            {
                screenPosition = Input.GetTouch(0).position;
            }

            else
            {
                return;
            }

            worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            if (isDragActive)
            {
                Drag();
            }

            else
            {
                RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
                if (hit.collider != null)
                {
                    Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                    if (draggable != null)
                    {
                        lastDragged = draggable;
                        InitDrag();
                    }
                }
            }
        }

        void StayInScreen()
        {
            
        }

        void InitDrag()
        {
            isDragActive = true;
        }

        void Drag()
        {
            if (worldPosition.x > Screen.width / 2) return;

            lastDragged.transform.position = new Vector2(worldPosition.x, lastDragged.transform.position.y);
        }

        void Drop()
        {
            isDragActive = false;
        }
    }
}
