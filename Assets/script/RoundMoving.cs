using UnityEngine;
using System.Collections;

public class RoundMoving : MonoBehaviour {
 
    public GameObject throneHibrid;
    private float orbitDegreePerSec=180.0f;
    private float orbitDistance = 2.0f;
    private Transform cointransform;
    private Transform throneTransform;
    public Player player;
    private bool flagForCoinMoving=false;
    void Start()
    {
       
        cointransform = this.GetComponent<Transform>();
        throneTransform = throneHibrid.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        
       
        throneTransform.position = cointransform.position + (throneTransform.position - cointransform.position).normalized * orbitDistance;
        throneTransform.RotateAround(cointransform.position, new Vector3(0,0,1), orbitDegreePerSec * Time.deltaTime);
      
        int playerScore = player.getScore();
       
        if (playerScore % 5 == 0 &&playerScore!=0&&flagForCoinMoving==false)
        {
            cointransform.position = new Vector3(Random.Range(-2f, 1.5f),cointransform.position.y,cointransform.position.z);
            flagForCoinMoving = true;
            
        }
        if (flagForCoinMoving == true)
        {
            transform.position += new Vector3(0, -1, 0) * Time.deltaTime;
        }
        if (cointransform.position.y<-5)
        {
            cointransform.position = new Vector3(0, 15, 0);

        }
    }
    public void setFlagForcoinMoving(bool setter)
    {
        this.flagForCoinMoving = setter;
    }
}
