using UnityEngine;
using TMPro;

namespace UI
{
    public class MaxLevelNumber : MonoBehaviour
    {
        private TextMeshProUGUI _maxLeveltext;
        private void Start()
        {
            _maxLeveltext = GetComponent<TextMeshProUGUI>();
            _maxLeveltext.text= "Max level\n"+ PlayerPrefs.GetInt("Maxlevel").ToString();
        }
    }
}