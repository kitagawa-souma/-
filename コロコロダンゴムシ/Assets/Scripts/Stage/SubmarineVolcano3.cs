using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SubmarineVolcano3 : MonoBehaviour
{
    GameObject submarinVolcano3;
    //SubmarineVolcano3 script;

    private float timer = 0.4f;
    public GameObject VolcanoPrefab = null;

    void Start()
    {
        //submarinVolcano3 = GameObject.Find("火山_3");

        //script = submarinVolcano3.GetComponent<SubmarineVolcano3>();

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
