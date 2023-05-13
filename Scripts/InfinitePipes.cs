using UnityEngine;

public class InfinitePipes : MonoBehaviour
{
    public GameObject bottomPipePrefab; 
    public GameObject bottomPipePrefabRed; 
    public GameObject scoreHitboxPrefab;
    
    public float initialSpawnRate = 1.5f;
    public float minSpawnRate = 0.5f;
    public float spawnRateDecrement = 0.015f;

    private float currentSpawnRate;

    // create new obstacles repetadely 
    private void OnEnable() {
        currentSpawnRate = initialSpawnRate;
        if(GameManager.isDarkMode) {
            InvokeRepeating(nameof(CreateObstacleRed), currentSpawnRate, currentSpawnRate);
        } else {
            InvokeRepeating(nameof(CreateObstacleGreen), currentSpawnRate, currentSpawnRate);
        }
    }
    // stop generating obstacles
    private void OnDisable() {
        CancelInvoke(nameof(CreateObstacleGreen));
        CancelInvoke(nameof(CreateObstacleRed));
    }

    // spawn pipes at random hights
    private void CreateObstacleGreen() {
        GameObject bottomPipe = Instantiate(bottomPipePrefab, transform.position, Quaternion.identity);
        float randomYPosition = Random.Range(-7.5f, -10f);
        bottomPipe.transform.position = new Vector3(bottomPipe.transform.position.x, bottomPipe.transform.position.y + randomYPosition, bottomPipe.transform.position.z);

        GameObject topPipe = Instantiate(bottomPipePrefab, transform.position, Quaternion.identity);
        randomYPosition = Random.Range(7.5f, 10f); 
        topPipe.transform.Rotate(new Vector3(0f, 0f, 180f));
        topPipe.transform.position = new Vector3(topPipe.transform.position.x, topPipe.transform.position.y + randomYPosition, topPipe.transform.position.z);

        GameObject scoreHitbox = Instantiate(scoreHitboxPrefab, transform.position, Quaternion.identity);
        scoreHitbox.transform.localScale = new Vector3(0.2f, 10f, 1f);
        
        // gradually decrease spawn rate over time
        currentSpawnRate = Mathf.Max(minSpawnRate, currentSpawnRate - spawnRateDecrement);
        CancelInvoke(nameof(CreateObstacleGreen));
        InvokeRepeating(nameof(CreateObstacleGreen), currentSpawnRate, currentSpawnRate);
    }

    // same but with red
    private void CreateObstacleRed() {
        GameObject bottomPipe = Instantiate(bottomPipePrefabRed, transform.position, Quaternion.identity);
        float randomYPosition = Random.Range(-7.5f, -10f);
        bottomPipe.transform.position = new Vector3(bottomPipe.transform.position.x, bottomPipe.transform.position.y + randomYPosition, bottomPipe.transform.position.z);

        GameObject topPipe = Instantiate(bottomPipePrefabRed, transform.position, Quaternion.identity);
        randomYPosition = Random.Range(7.5f, 10f); 
        topPipe.transform.Rotate(new Vector3(0f, 0f, 180f));
        topPipe.transform.position = new Vector3(topPipe.transform.position.x, topPipe.transform.position.y + randomYPosition, topPipe.transform.position.z);

        GameObject scoreHitbox = Instantiate(scoreHitboxPrefab, transform.position, Quaternion.identity);
        scoreHitbox.transform.localScale = new Vector3(0.2f, 10f, 1f);
        
        // gradually decrease spawn rate over time
        currentSpawnRate = Mathf.Max(minSpawnRate, currentSpawnRate - spawnRateDecrement);
        CancelInvoke(nameof(CreateObstacleRed));
        InvokeRepeating(nameof(CreateObstacleRed), currentSpawnRate, currentSpawnRate);
    }
}