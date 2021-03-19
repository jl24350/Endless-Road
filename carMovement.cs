using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed = 10f;
    public float forrwardSpeed = 0f;
    public spawnManager sp;
    public bool begin = false;
    public bool end = false;
    public Canvas gameScreen;

    void Update()
    {
        if(begin == true && end == false){
            if (forrwardSpeed < 40f){
                forrwardSpeed += 0.1f;
            }
            float hMovement = (Input.GetAxisRaw("Horizontal") * movementSpeed) * -1;
            float hRotation = (Input.GetAxisRaw("Horizontal") * -1) * 10;

            transform.Translate(new Vector3(forrwardSpeed, hMovement, 0) * Time.deltaTime);
            transform.rotation = Quaternion.Euler(90,0,hRotation);
        }
       
    }
    private void OnTriggerEnter(Collider other) {
        sp.SpawnTriggerEntered();
    }
     private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Respawn"){
            end = true;
            forrwardSpeed = 0f;
            gameScreen.GetComponent<gameScreenManager>().collisionHandler();  
        }
    }
    
}
