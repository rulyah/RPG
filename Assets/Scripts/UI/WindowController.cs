namespace UI
{
    using UnityEngine;
    using UnityEngine.UI;
    public class WindowController : MonoBehaviour
        {
            [SerializeField] private Button _exitButton;
            [SerializeField] private Button _openButton;
            [SerializeField] private CanvasGroup _canvasGroup;
            
        
            public virtual void Init()
            {
                _openButton.onClick.AddListener(Show);
                _exitButton.onClick.AddListener(Hide);
            }
        
            private void Show()
            {
                _canvasGroup.alpha = 1;
                _canvasGroup.interactable = true;
                _canvasGroup.blocksRaycasts = true;
            }


            private void Hide()
            {
                _canvasGroup.alpha = 0;
                _canvasGroup.interactable = false;
                _canvasGroup.blocksRaycasts = false;
            }

        }
}
