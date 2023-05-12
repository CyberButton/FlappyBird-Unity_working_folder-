using UnityEngine;

public class ThemeControl : MonoBehaviour
{
    public GameObject lightBG;
    public GameObject darkBG;
    public GameObject yellowBird;
    public GameObject blueBird;


    public void Awake() {
        darkBG.SetActive(false);
        blueBird.SetActive(false);
        yellowBird.SetActive(true);
        lightBG.SetActive(true);
    }
    public void Update() {
        if(GameManager.isDarkMode) {
            darkBG.SetActive(true);
            lightBG.SetActive(false);
            blueBird.SetActive(true);
            yellowBird.SetActive(false);
        } else {
            darkBG.SetActive(false);
            lightBG.SetActive(true);
            blueBird.SetActive(false);
            yellowBird.SetActive(true);
        }
    }
}
