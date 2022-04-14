using CodeBase.Services.SceneLoaderService;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.View
{
    public class WinWindowView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Button _restartButton;

        private SceneLoader _sceneLoader;
        
        public void Constructor(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        public void Show()
        {
            _animator.Play("Show");
        }

        private void OnRestartButtonClicked()
        {
            _sceneLoader.RestartLevel();
        }
    }
}