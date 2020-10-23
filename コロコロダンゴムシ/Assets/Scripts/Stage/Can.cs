using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    GameObject cangenerator;

    Enemy script;

    public GameObject FoodPrefab = null;
    private int Food;
    private int Prob = 1;

    // Start is called before the first frame update
    void Start()
    {
        cangenerator = GameObject.Find("ゴミ袋");

        script = cangenerator.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        float timer = script.timer;
        if (collision.tag == "Bullet")
        {
            Food = Random.Range(1, 15);
            if (Food == Prob)
            {
                Invoke("DelayMethod", timer);
            }
        }
    }
    void DelayMethod()
    {
        Vector2 can_pos = transform.position;
        Instantiate(FoodPrefab,
                    can_pos,
                    Quaternion.identity);
    }
}
