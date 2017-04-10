using UnityEngine;
using System.Collections;

public class DestroyDropCOin : MonoBehaviour{
    
    

	void Start () {
       
	
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="greenBox")
        {
           
            
            Destroy(this.gameObject);
            Player.setScore();
        }
        else if(col.gameObject.tag=="redBox")
        {
            Player.decreMentScore();
            Destroy(this.gameObject);
        }
    }
    }
