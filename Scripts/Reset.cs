using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public Text textHighScore;

    public void ResetScore() {
        PlayerPrefs.SetInt("HighestScore", 0);
        PlayerPrefs.Save();
        textHighScore.text = "highscore:0";
    }
}
