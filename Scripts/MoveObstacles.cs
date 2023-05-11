using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    public float speed = 5f;
    private float ScreenEnd;

    void Start(){
        // left adge of screen to destory pipes(-1f, after they pass the screen)
        // Vector3.zero(0,0,0) == bottom-left corner of screen
        ScreenEnd = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    void Update(){
        transform.position += Vector3.left * speed * Time.deltaTime;

        //delet pipes once they pass screen
        if(transform.position.x < ScreenEnd) {
            Destroy(gameObject);
        }
    }
}
