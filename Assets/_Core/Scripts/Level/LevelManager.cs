using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public int coins = 0;
    public static LevelManager Ins; 
    public Player player;
    public TextMeshProUGUI coinText;
    public GameObject gameOverMenu;
    public GameObject levelCompleteMenu;
    public GameObject levelSelecMenu;
    public GameObject levelLoadingMenu;
    public GameObject pauseMenu;
    public GameObject lootUI;
    public KeyOn key;
    
    public void ResetGame(){
        player.ResetPlayer();
        for (int i = 0; i < lifeList.Count; i++)
        {
            lifeList[i].PrenderVida();
        }
    }

    public void ShowPause(){
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }
    
    public void ShowLevelSelect(){
        levelSelecMenu.gameObject.SetActive(true);
    }
    public List<Life> lifeList;
    
    private void Awake() {
        Ins = this;
        SceneManager.sceneUnloaded +=OnSceneUnloaded;
        SceneManager.sceneLoaded +=OnSceneLoaded;
    }
    private void OnSceneUnloaded(Scene scene){
        SceneManager.LoadScene("Level_"+currentLevel, LoadSceneMode.Additive);
    }

    private void OnSceneLoaded(Scene current, LoadSceneMode mode){
        levelLoadingMenu.gameObject.SetActive(false);
    }

    public void OnLevelComplete(){
       Invoke("OnLevelCompleteDelay",1);
    }
    public void OnLevelCompleteDelay(){
        levelCompleteMenu.gameObject.SetActive(true);
    }

    public void GameOver(){
        gameOverMenu.gameObject.SetActive(true);
    }

    

    public void AddCoins() {
        coins ++;
        coinText.text = coins.ToString();
        Debug.Log("Coins: "+coins);
    }

    public int currentLifes = 3;


    public void OnDamagePlayer(int _lifes){
        if(_lifes<0){return;}
        currentLifes --;
        player.lifes=currentLifes;
        Debug.Log("vida menos"+currentLifes);
        lifeList[currentLifes].ApagarVida();
    }

    public void AddLife(int _life){
        if (_life<0 || _life>3){return;}
        Debug.Log(_life);
        lifeList[_life].PrenderVida();
        currentLifes++;
        player.lifes=currentLifes;
        Debug.Log("se añade vida"+currentLifes);
    }

     public void OnKeyTaked(){
        key.KeyTaked();
    }

    public void OnRetryClick(){
        // SceneManager.LoadScene("Game");
        ResetGame();
        currentLifes=3;
        player.BackToNormal();
        gameOverMenu.gameObject.SetActive(false);
        LoadLevel(currentLevel);
        
    }
    public int currentLevel = 1;

    public void LoadLevel(int _level){
        levelLoadingMenu.gameObject.SetActive(true);

        levelSelecMenu.gameObject.SetActive(false);
        levelCompleteMenu.gameObject.SetActive(false);

        Debug.Log(_level);

        SceneManager.UnloadSceneAsync("Level_"+currentLevel);

        currentLevel=_level;

        key.KeyOff();
        
    }
}
