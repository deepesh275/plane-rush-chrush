using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RewardAds : MonoBehaviour
{
    [SerializeField] private GoogleAdMobController gameAds;
    public TMP_Text coinText;

    public int currentCoins;
    // Start is called before the first frame update
    void Start()
    {

      gameAds.RequestAndLoadInterstitialAd();
		  gameAds.RequestAndLoadRewardedAd();
		  gameAds.RequestAndLoadRewardedInterstitialAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RewardAddGetCoins () {
		gameAds.ShowRewardedAd();
		// gameAds.ShowRewardedInterstitialAd();

    }
}
