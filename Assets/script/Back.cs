using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(0, -2, 329);
        this.transform.rotation = Quaternion.identity;

    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(0.0f, -2.0f, 329.0f);
        //Debug.Log("static position " + this.transform.position);
	}
}
