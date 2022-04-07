using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelNumber : MonoBehaviour
    {
        private TextMeshProUGUI _levelNumberText;

        private void Start()
        {
            int _levelNumber = SceneManager.GetActiveScene().buildIndex;
           
            _levelNumberText = GetComponent<TextMeshProUGUI>();
            _levelNumberText.text = _levelNumber.ToString() ;
            if (_levelNumber > PlayerPrefs.GetInt("Maxlevel"))
            {
                PlayerPrefs.SetInt("Maxlevel", _levelNumber);
                PlayerPrefs.Save();
            }

        }
    }
}
