
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Monetization;
using ShowResult = UnityEngine.Monetization.ShowResult;
using UnityEngine.Events;

public class AdsManager : MonoBehaviour
{  
    private static string placementId = "Rewarded_Android";
#if UNITY_IOS
   private static string gameId = "4658918";
#elif UNITY_ANDROID
    private static string gameId = "4658919";
#endif
   
    [SerializeField] private Button _adButton;
    [SerializeField] private UnityEvent _restartE;
  private  void Start()
    {

        if (_adButton)
        {
            _adButton.onClick.AddListener(ShowAd);
        }

        if (Monetization.isSupported)
        {
            Monetization.Initialize(gameId, true);
        }
    }

   private void FixedUpdate()
    {
        if (_adButton)
        {
            _adButton.interactable = Monetization.IsReady(placementId);
        }
    }

   private void ShowAd()
    {
        ShowAdCallbacks options = new ShowAdCallbacks();
        options.finishCallback = HandleShowResult;
        ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;
        ad.Show(options);
    }

  private  void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            _restartE.Invoke();
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("The player skipped the video - DO NOT REWARD!");
        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }
}
