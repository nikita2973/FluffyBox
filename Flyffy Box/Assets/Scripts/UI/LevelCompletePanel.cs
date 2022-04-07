using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class LevelCompletePanel : MonoBehaviour
    {
        private Vector3 _startScale;
        
        [SerializeField] private UnityEvent _OnOpenE;

        [SerializeField] private Button _nextLevelButton;

        private void OnEnable()
        {
            _startScale = transform.localScale;
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            _OnOpenE.Invoke();
            OpenPanelAnimations();
            CheckHasNextlevel();
        }

        private void CheckHasNextlevel()
        {
          if(SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCountInBuildSettings-1)
            {
                _nextLevelButton.interactable = false;
            }
            else
            {
                _nextLevelButton.onClick.AddListener(NextLevel);
            }
        }

        private async void OpenPanelAnimations()
        {
            while (transform.localScale != _startScale)
            {
                await Task.Delay(25);
                transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.z + 0.1f, transform.localScale.z + 0.1f);
            }
        }
           
        private void NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
    }
}