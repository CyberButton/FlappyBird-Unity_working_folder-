using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currScore;

    public void IncrementScore() {
        currScore++;
    }

    public void HitObstacle() {
        Debug.Log("Game over");
    }
}
