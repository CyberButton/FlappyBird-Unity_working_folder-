using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
