using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;  // Halusin enemmän kuin yhdenlaista estettä. Joten gdin arrayn johon saadaan useampia Prefabseja.
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // lisäsin peliin esteiden satunnaisuutta. esteitä on useampia ja niitä tulee sattumanvaraisesti. 

    void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            
            int ObstacleIndex = Random.Range(0, obstaclePrefabs.Length);

            /* Kivi esteen kohdalla kivi oli osittain maan sisällä. Joten laitoin rivin joka siirtää estettä hieman ylöspäin jos se on kivi.    */
            GameObject selectedObstacle = obstaclePrefabs[ObstacleIndex];
            if (selectedObstacle.name == "Boulder")
            {
                spawnPos.y = 1.35f; 
            }
            else
            {
                spawnPos.y = 0;
            }


           
            Instantiate(obstaclePrefabs[ObstacleIndex], spawnPos, obstaclePrefabs[ObstacleIndex].transform.rotation);
        }
    }
}
