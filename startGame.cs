using UnityEngine;
using UnityEngine.UI;

public class startGame : MonoBehaviour
{
    public Transform player;
    public Camera mainCamera;
    public Canvas openingScreen;
    public Canvas gameScreen;
    
    void Start() {
        gameScreen.gameObject.SetActive(false);
        Button playButton = GameObject.Find("Play Button").GetComponent<UnityEngine.UI.Button>();
        Button quitButton = GameObject.Find("Quit Button").GetComponent<UnityEngine.UI.Button>();
        playButton.onClick.AddListener(play);
        quitButton.onClick.AddListener(quit);

    }
    void play(){
        openingScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(true);
        mainCamera.GetComponent<cameraMovement>().begin = true;
        gameScreen.GetComponent<gameScreenManager>().begin = true;
        
    }
    void quit(){
        Application.Quit();
    }
}
