using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlPanel : MonoBehaviour
{
    public void SinglePlayer(){
        SceneManager.LoadScene("FlappyBird");
    }
    public void TwoPlayer(){
        SceneManager.LoadScene("2PlayerMode");
    }
}
