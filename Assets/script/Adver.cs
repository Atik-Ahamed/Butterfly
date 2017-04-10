using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class Adver : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        if(Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo");
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
