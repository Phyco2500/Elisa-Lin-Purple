using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{

    //if an object collides with a trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //add score
        Score.score++;
    }
}