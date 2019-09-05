using UnityEngine;
using System.Collections;
using admob;
public class AdManager : MonoBehaviour {


	public static AdManager Instance{ set; get; }
	public string bannerId;
	public string videoId;
	public void Start()
	{

		Instance = this;
		DontDestroyOnLoad (gameObject);

		Admob.Instance ().initAdmob (bannerId, videoId);

		Admob.Instance ().loadInterstitial ();

	}

	public void ShowBanner()
	{

		Admob.Instance ().showBannerRelative (AdSize.Banner, AdPosition.TOP_CENTER, 3);

	}

	public void ShowVideo()
	{

		Admob.Instance ().loadInterstitial ();
			if (Admob.Instance ().isInterstitialReady ()) {
				Admob.Instance ().showInterstitial ();
			}
			
	}



}
