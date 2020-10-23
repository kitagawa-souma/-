using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
