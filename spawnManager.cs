using UnityEngine;

public class spawnManager : MonoBehaviour
{
    roadSpawner rs;
    public Transform player;
    void Start()
    {
        rs = GetComponent<roadSpawner>();
    }
    public void SpawnTriggerEntered(){
        rs.MoveRoad(player.transform.position.x);
    }
}
