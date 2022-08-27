using UnityEngine;
using UnityEngine.EventSystems;
namespace UI
{
    public class DragWindow : MonoBehaviour, IBeginDragHandler, IDragHandler
    {
        [SerializeField] private Transform _window;
        private Vector2 startMousePosition, startWindowPosition;
        
        
        public void OnBeginDrag(PointerEventData eventData)
        {
        startMousePosition = eventData.position;
        startWindowPosition =  transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _window.position = (eventData.position - startMousePosition) + startWindowPosition;
        }
    }
}
