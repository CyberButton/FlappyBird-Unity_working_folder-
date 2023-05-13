
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    private MeshRenderer mRenderer;

    // this script is used for both background and ground, each has its own offsetSpeed
    public float offsetSpeed = 1f;

    private void Awake() {
        mRenderer = GetComponent<MeshRenderer>();
    }

    // change the offset of the mesh to make it look like player is moving
    private void Update() {
        // only moving in x-axis so y = 0
        Vector2 offset = new Vector2(offsetSpeed * Time.deltaTime, 0);
        mRenderer.material.mainTextureOffset += offset;
    }
}
