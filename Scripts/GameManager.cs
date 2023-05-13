using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int currScore;

    public GameObject currentScore;
    public GameObject highScore;
    public Text textHighScore;
    public GameObject BG;
    public Text textScore;
    public GameObject buttonPlay;
    public GameObject gameOver;
    public Player player;
    public InfinitePipes spawner;
    public GameObject resetButton;
    public GameObject quitButton;    
    public GameObject switchThemeButton;    
    
    public static bool isDarkMode = false;

    // initialize game
    private void Awake() {
        Application.targetFrameRate = 60;

        gameOver.SetActive(false);  
        currentScore.SetActive(false);
        BG.SetActive(false);
        highScore.SetActive(false);
        resetButton.SetActive(false);
        quitButton.SetActive(false);
        switchThemeButton.SetActive(true);

        Pause();
        resetScoreX();
    }
    
    public void Play() {
        // reset score
        resetScoreX();
        currScore = 0;
        textScore.text = currScore.ToString();

        // disable menu window
        gameOver.SetActive(false);
        buttonPlay.SetActive(false);
        currentScore.SetActive(false);
        BG.SetActive(false);    
        highScore.SetActive(false);
        resetButton.SetActive(false);
        quitButton.SetActive(false);
        switchThemeButton.SetActive(false);

        // clear leftovers of previous game
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe-bottom");
        GameObject[] hBoxes = GameObject.FindGameObjectsWithTag("Score");

        foreach (GameObject pipe in pipes) {
            Destroy(pipe.gameObject);
        }

        foreach (GameObject box in hBoxes) {
            Destroy(box.gameObject);
        }

        // start new game
        Time.timeScale = 1f;      
        player.enabled = true;
        spawner.enabled = true;
    }

    public void Pause() {
        // freeze game & stop player
        Time.timeScale = 0f;
        player.enabled = false;
        spawner.enabled = false;
        MoveScore();
    }

    public void IncrementScore() {
        currScore++;
        textScore.text = currScore.ToString();
    }

    public void HitObstacle() {
        Pause();
        
        // activate main menu
        gameOver.SetActive(true);
        buttonPlay.SetActive(true);
        currentScore.SetActive(true);
        BG.SetActive(true);
        highScore.SetActive(true);
        resetButton.SetActive(true);
        quitButton.SetActive(true);
        switchThemeButton.SetActive(true);

        // update highscore
        int highestScore = PlayerPrefs.GetInt("HighestScore");
        if (currScore > highestScore) {
        PlayerPrefs.SetInt("HighestScore", currScore);
        PlayerPrefs.Save();
        highestScore = currScore;
        }
        textHighScore.text = "highscore:" + highestScore.ToString();
    }

    private void MoveScore() {
        RectTransform textTransform = textScore.GetComponent<RectTransform>();
        // Move the text by 417.62 units(hardcoded value for 16:9 build)
        Vector2 newPosition = textTransform.anchoredPosition + new Vector2(417.62f, 0f);
        textTransform.anchoredPosition = newPosition;
    }
    
    // used to reset socre text's x-axis position
    private void resetScoreX() {
        RectTransform textTransform = textScore.GetComponent<RectTransform>();
        Vector2 newPosition = new Vector2(16.3f, -158.2f);
        textTransform.anchoredPosition = newPosition;
    }

    public void switchTheme(){
        isDarkMode = !isDarkMode;
    }
}
