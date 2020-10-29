using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SubmarineVolcano2 : MonoBehaviour
{
    GameObject submarinVolcano2;
    //SubmarineVolcano2 script;

    private float timer = 0.4f;
    public GameObject VolcanoPrefab = null;
    //private float time = 0.0f;

    void Start()
    {
        //submarinVolcano2 = GameObject.Find("火山_2(Clone)");

        //script = submarinVolcano2.GetComponent<SubmarineVolcano2>();

        Invoke("DelayMethod", timer);
    }

    void Update()
    {
        transform.Translate(-0.01f, 0, 0);
    }

    void DelayMethod()
    {

        Debug.Log("Volcano2.DelayMethod");
        Vector2 volcano_pos = transform.position;
        Instantiate(VolcanoPrefab,
                    volcano_pos,
                    Quaternion.identity);
        Destroy(gameObject);
    }
}
