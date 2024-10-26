using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
    // Skripti esineiden ja tausta liikuttamiseen vasemmalle.
{
    private float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
        // PlayerControllerissa on ehto Game Over tilalle. Joten liikutetaan asioita vasemmalle vain jos ei ole Game Over. 
    {
        if (playerControllerScript.gameOver == false)
        { 
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        // Komento esineiden tuhoamiselle kun ne menee ruudun ohi. Tagilla "Obstacle" pidetään huoli että tausta ei myös tuhoudu. 
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
