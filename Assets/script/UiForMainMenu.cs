using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class UiForMainMenu : MonoBehaviour {
    public GameObject discriptionPanel;
    public GameObject LoadingPanel;
    private int highscoresaved;
    public Text highscore;
    // Use this for initialization
    void Awake () {
        
        discriptionPanel.SetActive(false);
        LoadingPanel.SetActive(false);
     
        highscoresaved = PlayerPrefs.GetInt("PlayerScore");
        highscore.text = "High Score: " + highscoresaved.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Menu()
    {
        LoadingPanel.SetActive(true);
       
        SceneManager.LoadScene("MainScene");
       
    }
    public void Exit()
    {
        Application.Quit();
    }
    
    public void loadDescription()
    {
        discriptionPanel.SetActive(true);
    }
    public void unLoadDiscriptionPanel()
    {
        discriptionPanel.SetActive(false);
    }
    public void showAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo");
        }
    }
}
