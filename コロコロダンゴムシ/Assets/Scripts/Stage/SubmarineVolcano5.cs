using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SubmarineVolcano5 : MonoBehaviour
{
    GameObject submarinVolcano5;
    //SubmarineVolcano5 script;

    private float timer = 0.4f;
    public GameObject VolcanoPrefab = null;

    void Start()
    {
        //submarinVolcano5 = GameObject.Find("火山_5");

        //script = submarinVolcano5.GetComponent<SubmarineVolcano5>();

        Invoke("DelayMethod", timer);
    }

    void Update()
    {
        transform.Translate(-0.01f, 0, 0);
    }

    void DelayMethod()
    {
        Vector2 volcano_pos = transform.position;
        Instantiate(VolcanoPrefab,
                    volcano_pos,
                    Quaternion.identity);
        Destroy(gameObject);
    }
}
