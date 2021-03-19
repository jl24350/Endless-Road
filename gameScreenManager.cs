using UnityEngine;
using UnityEngine.UI;

public class gameScreenManager: MonoBehaviour
{

    public Transform player;
    public GameObject spawnManager;
    public Text scoreText;
    public Text scoreTitleText;

    public Text highScore;
    public Button startButton;
    public Button quitButton;
    public bool begin = false;

    void Start() {
        startButton.gameObject.SetActive(false);
        startButton.onClick.AddListener(load);
        quitButton.gameObject.SetActive(false);
        quitButton.onClick.AddListener(quit);
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("0");

    }
    void Update()
    {

        if(player.position.x < -175f){
            scoreText.text = "Ready?";
            scoreTitleText.text = " ";  
        }

        else if(player.position.x < -50f && player.position.x > -175f){
            scoreText.text = "Set...";
            scoreTitleText.text = " ";
        }
        else if(player.position.x > -50f && player.position.x < 0f){
            scoreText.text = "Go!";
            scoreTitleText.text = " ";
        }
        else{
            if(begin == true){
                scoreText.text = player.position.x.ToString("0");
                scoreTitleText.text = "Score";
            }
        }
        
    }
    void load(){
        player.transform.position = new Vector3(-230.22f,0f,0f);
        startButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        player.GetComponent<CarMovement>().end = false;
        spawnManager.GetComponent<roadSpawner>().end = true;
    }
    void quit(){
        Application.Quit();
    }

    public void collisionHandler(){
        startButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        scoreTitleText.text = " ";

        float num = player.transform.position.x;

        if(num > PlayerPrefs.GetFloat("HighScore", 0)){
             PlayerPrefs.SetFloat("HighScore", num);
             highScore.text = num.ToString("0");
             scoreText.text = "New High Score!";
        }
        else{
            scoreText.text = "Game Over";
        }
        begin = true;
    }

}
