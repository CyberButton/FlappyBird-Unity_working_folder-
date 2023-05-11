using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private int currScore;

    public Text textScore;
    public GameObject buttonPlay;
    public GameObject gameOver;
    public Player player;
    
    private void Awake() {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play() {
        currScore = 0;
        textScore.text = currScore.ToString();

        gameOver.SetActive(false);
        buttonPlay.SetActive(false);

        Time.timeScale = 1f;      
        player.enabled = true;

        GameObject[] pipes = GameObject.FindGameObjectsWithTag("ToDestroy");

        foreach (GameObject pipe in pipes) {
            Destroy(pipe.gameObject);
        }

        // Pipes[] pipes = FindObjectsOfType<Pipes>();

        // // foreach (Pipes pipe in pipes) {
        // //     Destroy(pipe.gameObject);
        // // }
        // for(int i = 0; i < pipes.Length; i++) {
        //     Destroy(pipes[i].gameObject);
        // }
    }

    public void Pause() {
        //freeze game
        Time.timeScale = 0f;
        //disable player
        player.enabled = false;
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
