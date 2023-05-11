using UnityEngine;

public class InfinitePipes : MonoBehaviour
{
    //refrence to pipes
    public GameObject prefab;
    
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    //create new obstacles repetadely 
    private void OnEnable() {
        InvokeRepeating(nameof(CreateObstacle), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(CreateObstacle));
    }

    private void CreateObstacle() {
        //Quaternion.identity == no rotation
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);        
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
