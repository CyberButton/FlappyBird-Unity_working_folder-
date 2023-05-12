using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private int currScore;

    public GameObject currentScore;
    public GameObject BG;
    public Text textScore;
    public GameObject buttonPlay;
    public GameObject gameOver;
    public Player player;
    public InfinitePipes spawner;
    
    private void Awake() {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);  
        currentScore.SetActive(false);
        BG.SetActive(false);
        Pause();
    }
 
    public void Play() {
        resetScoreX();
        currScore = 0;
        textScore.text = currScore.ToString();

        gameOver.SetActive(false);
        buttonPlay.SetActive(false);
        currentScore.SetActive(false);
        BG.SetActive(false);    

        Time.timeScale = 1f;      
        player.enabled = true;

        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe-bottom");
        GameObject[] hBoxes = GameObject.FindGameObjectsWithTag("Score");


        foreach (GameObject pipe in pipes) {
            Destroy(pipe.gameObject);
        }

        foreach (GameObject box in hBoxes) {
            Destroy(box.gameObject);
        }

        spawner.enabled = true;
    }

    public void Pause() {
        //freeze game
        Time.timeScale = 0f;
        //disable player
        player.enabled = false;
        spawner.enabled = false;
        MoveScore();
    }

    public void IncrementScore() {
        currScore++;
        textScore.text = currScore.ToString();
    }

    public void HitObstacle() {
        gameOver.SetActive(true);
        buttonPlay.SetActive(true);
        currentScore.SetActive(true);
        BG.SetActive(true);
        Pause();
    }

    private void MoveScore() {
        // Get the RectTransform component of the text component
        RectTransform textTransform = textScore.GetComponent<RectTransform>();
        // Move the text by 417.62 units
        Vector2 newPosition = textTransform.anchoredPosition + new Vector2(417.62f, 0f);
        textTransform.anchoredPosition = newPosition;
    }
    private void resetScoreX() {
        RectTransform textTransform = textScore.GetComponent<RectTransform>();
        Vector2 newPosition = new Vector2(16.3f, -158.2f);
        textTransform.anchoredPosition = newPosition;
    }
}
