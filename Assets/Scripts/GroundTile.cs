using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GroundTile : MonoBehaviour
{   
    GroundSpawner groundSpawner;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        /*count++;

        if (count == 5) { 
            SpawnPhantom(); 
            count = 0; 
        }*/
    }

    private void OnTriggerExit(Collider other) //assumes only one object is moving
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);    
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;
    public GameObject obstaclePrefab2;
    //public GameObject obstaclePrefab3;

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2,5);
        int obstacleSpawnIndex2 = Random.Range(5, 8);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex);
        Transform spawnPoint2 = transform.GetChild(obstacleSpawnIndex2);
        //Transform spawnPoint3 = transform.GetChild(obstacleSpawnIndex);

        int obsType = Random.Range(0,2);

        if (obsType == 0)
        {
            Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
        }
        else if (obsType == 1)
        {
            Instantiate(obstaclePrefab2, spawnPoint2.position, Quaternion.identity, transform);
        }
      /*  else if (obsType == 2)
        {
            Instantiate(obstaclePrefab3, spawnPoint3.position, Quaternion.identity, transform);
        }*/
    }
    /*
    void SpawnPhantom() 
    { 
        // if phantom is on the same z as player and 
    }
    
    void SpawnRager()
    {
        if there is nothing in front of the player for 4 spaces spawn a rager
    }
     */
}
