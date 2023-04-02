using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [Header("RB object")]
    public Rigidbody2D rb;
    [Header("default shrinking speed")]
    public float shrinkSpeed = 3f;
    public float finalShrinkSize = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        if (transform.localScale.x <= finalShrinkSize)
        {
            Destroy(gameObject);
            Score.score++;
        }
    }
}
