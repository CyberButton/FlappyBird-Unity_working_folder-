using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private int currScore;

    public Text textScore;
    public GameObject buttonPlay;
    public GameObject gameOver;
    public Player player;
    public InfinitePipes spawner;
    
    private void Awake() {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);  
        Pause();
    }

    public void Play() {
        currScore = 0;
        textScore.text = currScore.ToString();

        gameOver.SetActive(false);
        buttonPlay.SetActive(false);

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
    }

    public void IncrementScore() {
        currScore++;
        textScore.text = currScore.ToString();
    }

    public void HitObstacle() {
        gameOver.SetActive(true);
        buttonPlay.SetActive(true);

        Pause();
    }
}
