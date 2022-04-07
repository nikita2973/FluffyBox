using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using DG.Tweening;
namespace UI
{
    public class PlayButton : MonoBehaviour, IPointerClickHandler
    {
     [SerializeField] private int _levelLoad= 1;

     [SerializeField] private float _scaleSpeed;
     
        private  void Start()
        {
            DOTween.Init();
            ResizeButton();
        }
        private  void ResizeButton()
        {
            var sequence = DOTween.Sequence()
             .Append(transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), _scaleSpeed, 1, 2));
            sequence.SetLoops(-1, LoopType.Incremental);
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(_levelLoad,LoadSceneMode.Single);
        }
   
    }
}