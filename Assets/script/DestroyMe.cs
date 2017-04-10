using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour {

    private float destroyTime=0.20f;
   private float startTime = 0f;
	void Start () {
        startTime=Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time-startTime>destroyTime)
        {
            Destroy(this.gameObject);
        }
	
	}
}
