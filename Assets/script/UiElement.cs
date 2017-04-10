using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class UiElement : MonoBehaviour {
     
    public GameObject PauseMenu;
    public GameObject rePlayPanl;
    void Awake()
    {
        
        PauseMenu.SetActive(false);
        
       
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)&&rePlayPanl.activeSelf==false)
        {
            Pause();
           }
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
           
            Time.timeScale = 0;
            if (Advertisement.IsReady())
            {
                Advertisement.Show("rewardedVideo");
            }
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        if (PauseMenu.activeSelf== false)
        {
            PauseMenu.SetActive(true);
        }
        
        else if (PauseMenu.activeSelf == true)
            PauseMenu.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
}
