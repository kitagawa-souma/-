using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    private bool Trigger = false;
    private int rotate;
    public float timer = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        rotate = Random.Range(1, 3);
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (rotate == 1)
        {
            transform.Rotate(0.0f, 0.0f, 0.5f);
        }
        else if (rotate == 2)
        {
            transform.Rotate(0.0f, 0.0f, -0.5f);
        }
        transform.Translate(0.0f, -0.01f, 0.0f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bullet")
        {
            anim.SetTrigger("Hit");
            Trigger = true;
            Invoke("DelayMethod", timer);
        }
    }
    void DelayMethod()
    {
        Destroy(gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}