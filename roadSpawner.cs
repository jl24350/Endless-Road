
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class roadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    public List<GameObject> countryRoads;
    public List<GameObject> surrealRoads;
    public List<GameObject> cars;
    public List<GameObject> obstaclesNature;
    public List<GameObject> surrealObstacles;
    public List<float> carsX;
    public List<float> carsY;
    public List<float> carsZ;
    public List<float> roadsX;
    public float offset = 190f;
    public float carOffset = 50f;
    public bool end = false;
    public bool switchRoads = false;
    public int switchRoadsCount = 0;

    void Start()
    {
        if(roads != null && roads.Count > 0){
            roads = roads.OrderBy(r => r.transform.position.x).ToList();
        }

        for(int i = 0; i < roads.Count; i++){
            roadsX[i] = roads[i].transform.position.x;
        }
        for(int i = 0; i < cars.Count; i++){
            carsX[i] = cars[i].transform.position.x;
            carsY[i] = cars[i].transform.position.y;
            carsZ[i] = cars[i].transform.position.z;
        }
    }
    void Update() {
        if(end == true){
            returnToPosition();
            end = false;
            switchRoadsCount = 0;
        }
    }
    public void MoveRoad(float playerPosition){
        GameObject moveRoad;
        GameObject moveObstacle;

        List<GameObject> previousGroup = roads;
        List<GameObject> nextGroup = countryRoads;
        List<GameObject> currentObstacles = cars;
        List<GameObject> nextObstacles = obstaclesNature;

        float posX;
        float obstacleX;
        float obstacleY;
        float obstacleZ;

        if(playerPosition > 5000f){
            if(switchRoadsCount == 0){
                switchRoads = true;
            }
            else{
                previousGroup = countryRoads;
                currentObstacles = obstaclesNature;
            }
        }
        if(playerPosition > 7000f){
            if(switchRoadsCount == 1){
                switchRoads = true;
                previousGroup = countryRoads;
                nextGroup = surrealRoads;
                currentObstacles = obstaclesNature;
                nextObstacles = surrealObstacles;
            }
            else{
                previousGroup = surrealRoads;
                currentObstacles = surrealObstacles;
            }
        }

        if(switchRoads == true){
                moveRoad = nextGroup[0];
                posX= previousGroup[previousGroup.Count - 1].transform.position.x + (offset + 3f) ;
                nextGroup.Remove(moveRoad);
                moveRoad.transform.position = new Vector3(posX,0,0);
                nextGroup.Add(moveRoad);

                moveObstacle = nextObstacles[0];
                obstacleX = currentObstacles[currentObstacles.Count -1].transform.position.x + carOffset;
                obstacleY = moveObstacle.transform.position.y;
                obstacleZ = currentObstacles[currentObstacles.Count -1].transform.position.z;
                nextObstacles.Remove(moveObstacle);
                moveObstacle.transform.position = new Vector3(obstacleX,obstacleY,obstacleZ);
                nextObstacles.Add(moveObstacle);


                switchRoads = false;
                switchRoadsCount++;
        }
        else{
            moveRoad = previousGroup[0];
            previousGroup.Remove(moveRoad);
            posX = previousGroup[previousGroup.Count - 1].transform.position.x + offset;
            moveRoad.transform.position = new Vector3(posX,0,0);
            previousGroup.Add(moveRoad);

            moveObstacle = currentObstacles[0];
            obstacleX = currentObstacles[currentObstacles.Count -1].transform.position.x + carOffset;
            obstacleY = moveObstacle.transform.position.y;
            obstacleZ = currentObstacles[currentObstacles.Count -1].transform.position.z;
            currentObstacles.Remove(moveObstacle);
            moveObstacle.transform.position = new Vector3(obstacleX,obstacleY,obstacleZ);
            currentObstacles.Add(moveObstacle);
            
        }
    }
    public void returnToPosition(){
        for(int i = 0; i< roads.Count; i++){
            roads[i].transform.position = new Vector3(roadsX[i],0,0);
        }
        for(int i =0; i < cars.Count; i++){
            cars[i].transform.position = new Vector3(carsX[i], carsY[i],carsZ[i]);
        }
    }

}
