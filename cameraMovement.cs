using System.Collections;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    
    public Transform player;
    public Transform sky;
    private float skyOffsetX = 66.7f;
    private float skyOffsetY = -57.6f;
    private float skyOfffsetZ = 2;
    private float yOffset = 3f;

    public bool begin = false;
    public bool gameplay;
    private float xOffset = -7f;
    void LateUpdate()
    {
        if(begin == true){
            transform.position  = Vector3.Lerp(transform.position, new Vector3(player.position.x + xOffset, player.position.y + yOffset, player.position.z),3.5f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,90,0),0.01f);
            player.GetComponent<CarMovement>().begin = true;
            gameplay = true;
        }
        if(gameplay == true){
            StartCoroutine(gamePlayCam());
        }
        sky.transform.position = new Vector3(player.position.x + skyOffsetX,player.position.y + skyOffsetY, player.position.z + skyOfffsetZ );
        
    }

    IEnumerator gamePlayCam(){
        yield return new WaitForSeconds(4f);
       transform.position  = Vector3.Lerp(transform.position, new Vector3(player.position.x + xOffset, player.position.y + yOffset, player.position.z),6f * Time.deltaTime);
    }
}
