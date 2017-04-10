using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Player : MonoBehaviour {
 
    public GameObject destroyAudioContainer;
    private AudioSource destroyAudio;
    private AudioSource coinAudio;
    private static AudioSource cointainerAudio;
    private GameObject instanceOfdropCoin;
    private bool dropButtonPressed = false;
    public GameObject dropableCoin;
    private bool dropableCoinInstantiated = false;
    private static int counterForDropCoin;
  

    public RoundMoving roundMoving;
    private bool flagforroundmoving;

    public GameObject hibridCoin;
    public GameObject hibridThrone;
    private Transform hibiridcoinTransform;
    private Transform hibridThroneTransform;

    public Text scoreText;
    private static int score;
    public GameObject rePlayPanel;

    public GameObject coin;
    public GameObject throne;
    private GameObject instance;//for making transformation to one position to another of coin
    private GameObject instanOfThrone;//for making transformation to one position to another of the throne

    private float jumpForc = 67.0f;
    private float acceleration = 5.0f;
    private float xposofcoin, yposofcoin;
    private float xPositionOfThrone, yPositionOfThrone;

    Rigidbody rb;
    Vector3 playerPosition;

    public GameObject particle;

   
   
	// Use this for initialization
	void Awake () {
        Time.timeScale = 1;
        counterForDropCoin = 0;
        score = 0;

        flagforroundmoving = true;
        rePlayPanel.SetActive(false);
        
       playerPosition = transform.position;
        rb = GetComponent<Rigidbody>();

        xposofcoin = Random.Range(-2.85f, 2.34f);
        yposofcoin = Random.Range(4.27f, 7.35f);

        xPositionOfThrone = Random.Range(xposofcoin - 0.63f, xposofcoin + 0.63f);

        if (Mathf.Abs(rb.transform.position.x- xPositionOfThrone) <=1 && Mathf.Abs(rb.transform.position.y-yPositionOfThrone)<=1)
        {
            xPositionOfThrone -= 0.68f;
        }
        if (xPositionOfThrone<=xposofcoin)
        {
           xPositionOfThrone-= 0.67f;
        }
        else if(xPositionOfThrone > xposofcoin)
        {
            xPositionOfThrone+= 0.67f;
        }
        yPositionOfThrone = Random.Range(yposofcoin- 0.67f, yposofcoin + 0.67f);
      

        instance =Instantiate(coin, new Vector3(xposofcoin, yposofcoin, 0), Quaternion.identity)as GameObject;//first time instantiating one coin
        
        instanOfThrone = Instantiate(throne, new Vector3(xPositionOfThrone, yPositionOfThrone, 0), Quaternion.identity) as GameObject;//first time instantiating of one throne

        hibiridcoinTransform = hibridCoin.GetComponent<Transform>();
        coinAudio = instance.GetComponent<AudioSource>();
        AudioSource[] aSources = this.GetComponents<AudioSource>();
        cointainerAudio = aSources[1];
        destroyAudio = destroyAudioContainer.GetComponent<AudioSource>();
     
    }



    // Update is called once per frame
    void Update()
    {

        if (dropableCoin == null || instanceOfdropCoin == null)
        {
            dropableCoinInstantiated = false;
        }


        scoreText.text = score.ToString();//updating score
        transform.rotation = Quaternion.identity;



        instance.transform.position = new Vector3(xposofcoin, yposofcoin, 0);//for making remainable to one place of the coin

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);//for making z 0 to every frame of the player

        if (score > 6)
        {
            instanOfThrone.transform.position = instance.transform.position + (instanOfThrone.transform.position - instance.transform.position).normalized * 1.3f;
            if (counterForDropCoin > 3)
            {
                instanOfThrone.transform.RotateAround(instance.transform.position, new Vector3(0, 0, 1), (score+counterForDropCoin) * 2 * Time.deltaTime);

            }
            else if(counterForDropCoin<=3)
            {
                instanOfThrone.transform.RotateAround(instance.transform.position, new Vector3(0, 0, 1), score * 3* Time.deltaTime);

            }
        }
        else
        {
            instanOfThrone.transform.position = new Vector3(xPositionOfThrone, yPositionOfThrone, 0);//making remainable to one place of the throne
        }


        //jumping
        if (Input.touchCount > 0) {
            if (Input.GetTouch(0).phase == TouchPhase.Began){
                //transform.position += new Vector3(0, 1, 0)* jumpForc*Time.deltaTime;
                transform.Translate(new Vector3(0, 1 * Time.deltaTime * jumpForc, 0));
            }
        }
        ////jumping withkeyboard
        //if (Input.GetKeyDown("space"))
        //{
        //    transform.Translate(new Vector3(0, 1 * Time.deltaTime * jumpForc, 0));
        //    //transform.position += new Vector3(0, 1, 0) * jumpForc * Time.deltaTime;
        //}
        ////moving withkeyboard
        //if (Input.GetAxis("Horizontal") > 0)
        //{
        //    transform.position += new Vector3(Input.GetAxis("Horizontal") * acceleration, 0, 0) * Time.deltaTime;
        //}
        //else if (Input.GetAxis("Horizontal") < 0)
        //{
        //    transform.position += new Vector3(Input.GetAxis("Horizontal") * acceleration, 0, 0) * Time.deltaTime;
        //}


        float x = Input.acceleration.x;//accleration input

        
        //moving left and right
        if (x > 0.1){
            transform.position += new Vector3(x*acceleration , 0, 0)*Time.deltaTime;
        }
        else if (x < -0.1){
            transform.position += new Vector3(x*acceleration , 0, 0)*Time.deltaTime;
        }
        //for clamping
        playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(rb.position.x, -3.42f, 2.9f);
        playerPosition.y = Mathf.Clamp(rb.position.y, -5f, 8.674f);
        transform.position = playerPosition;
        //clamping done

        if (transform.position.y <= -1.05)
        {
            destroyAudio.Play();
            if (score >= PlayerPrefs.GetInt("PlayerScore"))
            {
                PlayerPrefs.SetInt("PlayerScore", score);
            }
            Destroy(gameObject);
            
                if (instanOfThrone != null && instance!= null)
                {
                    Destroy(instanOfThrone);
                    Destroy(instance);
                }
        
            Destroy(GameObject.FindGameObjectWithTag("thronehibrid"));
            Destroy(GameObject.FindGameObjectWithTag("coinhibrid"));
            if (instanceOfdropCoin != null)
            {
                Destroy(instanceOfdropCoin);
               
            }
            if (rePlayPanel.activeSelf == false)
            {
                rePlayPanel.SetActive(true);
            }

            else if (rePlayPanel.activeSelf == true)
                rePlayPanel.SetActive(false);
        }


        if (instanceOfdropCoin!=null&&dropableCoinInstantiated==true)
        {
            if(dropButtonPressed==true)
            {
                instanceOfdropCoin.transform.Translate(new Vector3(0, -7 * Time.deltaTime, 0));

            }
            else if (dropButtonPressed == false)
            {
                instanceOfdropCoin.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y -0.17f, 0);
            }
            if (instanceOfdropCoin.transform.position.y <= -3.5f)
            {
                counterForDropCoin = 0;
                dropableCoinInstantiated = false;
                Destroy(instanceOfdropCoin);
            }
        }
        if(score<0)
        {
            destroyAudio.Play();
            score = 0;
            if (score >= PlayerPrefs.GetInt("PlayerScore"))
            {
                PlayerPrefs.SetInt("PlayerScore", score);
            }
            Destroy(gameObject);
            if (instanOfThrone != null && instance != null)
            {
                Destroy(instanOfThrone);
                Destroy(instance);
            }

            Destroy(GameObject.FindGameObjectWithTag("thronehibrid"));
            Destroy(GameObject.FindGameObjectWithTag("coinhibrid"));
            if (instanceOfdropCoin != null)
            {
                Destroy(instanceOfdropCoin);

            }
            if (rePlayPanel.activeSelf == false)
            {
                rePlayPanel.SetActive(true);
            }

            else if (rePlayPanel.activeSelf == true)
                rePlayPanel.SetActive(false);
        }


    
}

   
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "coin")
        {
            coinAudio.Play();
           

            Instantiate(particle, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

            if (dropableCoinInstantiated==false)
            {
                instanceOfdropCoin=Instantiate(dropableCoin, new Vector3(transform.position.x, transform.position.y - 0.17f, 0), Quaternion.identity) as GameObject;
                dropableCoinInstantiated = true;
                dropButtonPressed = false;
           
            }
            if(dropableCoinInstantiated==true)
            {
                counterForDropCoin++;
            }
            xposofcoin = Random.Range(-2.85f, 2.34f);
            if(yposofcoin<=4.27&&yposofcoin>=-1.19)
            {
                yposofcoin = Random.Range(4.27f, 7.35f);
            }
            else if(yposofcoin>=4.27&&yposofcoin<=7.35)
            {
                yposofcoin = Random.Range(-1.19f,4.27f);
            }
            
            instance.transform.Translate(xposofcoin, yposofcoin, 0);


            xPositionOfThrone = Random.Range(xposofcoin - 0.67f, xposofcoin + 0.67f);
            if (Mathf.Abs(rb.transform.position.x - xPositionOfThrone) <= 1 && Mathf.Abs(rb.transform.position.y - yPositionOfThrone) <= 1)
            {
                xPositionOfThrone -= 0.68f;
            }
            if (xPositionOfThrone <= xposofcoin)
            {
                xPositionOfThrone -= 0.67f;
            }
            else if (xPositionOfThrone > xposofcoin)
            {
                xPositionOfThrone += 0.67f;
            }
            yPositionOfThrone = Random.Range(yposofcoin - 0.67f, yposofcoin + 0.67f);


            if (counterForDropCoin <= 3)
            {
                score++;
            }
            else if(counterForDropCoin>3)
            {
                score--;
            }


        }
        //Game Over Condition
        if (col.gameObject.tag == "throne")
        {
           
            destroyAudio.Play();
            if (score >= PlayerPrefs.GetInt("PlayerScore"))
            {
                PlayerPrefs.SetInt("PlayerScore", score);
            }
            Destroy(gameObject);
            Destroy(col.gameObject);
              if (instanOfThrone!= null && instance!= null)
                {
                    Destroy(instanOfThrone);
                    Destroy(instance);
                }
            Destroy(GameObject.FindGameObjectWithTag("thronehibrid"));
            Destroy(GameObject.FindGameObjectWithTag("coinhibrid"));
            if(instanceOfdropCoin!=null)
            {
                Destroy(instanceOfdropCoin);
               
            }
     
            if (rePlayPanel.activeSelf == false)
            {
                rePlayPanel.SetActive(true);
            }

            else if (rePlayPanel.activeSelf == true)
                rePlayPanel.SetActive(false);
        }
        if (col.gameObject.tag == "coinhibrid")
        {
            coinAudio.Play();
            if (counterForDropCoin <= 3)
            {
                score += 3;
            }
            else if(counterForDropCoin>3)
            {
                score--;
            }
            hibiridcoinTransform.position=new Vector3(0, 15, 0);
            roundMoving.setFlagForcoinMoving(false);
            Instantiate(particle, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);


        }
        if (col.gameObject.tag == "thronehibrid")
        {
            destroyAudio.Play();
            if (score >= PlayerPrefs.GetInt("PlayerScore"))
            {
                PlayerPrefs.SetInt("PlayerScore", score);
            }
            Destroy(gameObject);
            Destroy(col.gameObject);
          
                if (instanOfThrone!= null && instance != null)
                {
                    Destroy(instanOfThrone);
                    Destroy(instance);
                }
            Destroy(hibridCoin);
            if (instanceOfdropCoin != null)
            {
                Destroy(instanceOfdropCoin);
               
            }

        
            if (rePlayPanel.activeSelf == false)
            {
                rePlayPanel.SetActive(true);
            }

            else if (rePlayPanel.activeSelf == true)
                rePlayPanel.SetActive(false);
        }

    }
    public int getScore() { return score; }

    public static void  setScore() {

        score++;
        cointainerAudio.Play();
        
    }
    public static void decreMentScore()
    {
        score--;
        cointainerAudio.Play();
    }


    public void dropCoin()
    {
        if(dropableCoinInstantiated==true&&instanceOfdropCoin!=null)
        {
             //dropableCoinInstantiated = false;
            dropButtonPressed = true;
            counterForDropCoin = 0;
        }
    }
}
