using UnityEngine;
using System.Collections;

public class MovableContainers : MonoBehaviour
{
   
    bool rightSideReached = false;
    bool leftSideReached = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 2.60)
        {
            rightSideReached = true;
            leftSideReached = false;
        }
        if (transform.position.x <= 2.60f && rightSideReached == false)
        {
            transform.Translate(new Vector3(1 * Time.deltaTime, 0, 0));
        }
        else if (transform.position.x >= -.10f && leftSideReached == false)
        {
            transform.Translate(new Vector3(-1 * Time.deltaTime, 0, 0));
        }
        if (transform.position.x <= -.10f)
        {
            leftSideReached = true;
            rightSideReached = false;
        }

    }
}
    
