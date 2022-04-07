using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        private Vector3 _startScale;
        private Vector3 _minScale;
        private void OnEnable()
        {
            _startScale = transform.localScale;
            _minScale = new Vector3(0.1f, 0.1f, 0.1f);
            transform.localScale = _minScale;
            OpenPanelAnimations();
        }

        private async void OpenPanelAnimations()
        {
            while (transform.localScale != _startScale)
            {
                await Task.Delay(25);
                transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.z + 0.1f, transform.localScale.z + 0.1f);
            }
        }
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(ConstantValues.MainMenuNameScene, LoadSceneMode.Single);
        }
    }
}
public static class ConstantValues
{
    public readonly static string MainMenuNameScene = "Main menu";
}