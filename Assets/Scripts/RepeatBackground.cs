using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taustakuvan liikuttamiseen

public class RepeatBackground : MonoBehaviour
{
    private float repeatWidth;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
        // Koska taustakuvassa on kaksi samaa kuvaa vierekk‰in. Voidaan laittaa se toistamaan itse‰‰n sen puoliv‰liss‰ eli / 2.
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
        // Taustakuva liikkuu MoveLeft skriptin tapaan. Mutta palaa alkupaikkaan kun sen sijainti on puolet itsest‰‰n. 
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
