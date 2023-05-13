using UnityEngine;

/*  
    this could be implemented using events and delegates
    but for small game my implementation is "ok"
*/

public class MenuColor : MonoBehaviour
{
    private Renderer renderer1;
    void Start()
    {
        renderer1 = GetComponent<Renderer>();
        renderer1.material.color = Color.yellow;
    }

    void Update()
    {
        if(GameManager.isDarkMode) {
            renderer1.material.color = Color.blue;
        } else {
            renderer1.material.color = Color.yellow;
        }     
    }
}
