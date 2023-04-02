using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Default Speed")]
    //speed for the movement
    public float speed;


    // Update is called once per frame
    void Update()
    {

        //transform the object to move to left
        //according to the axis asnd speed
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
