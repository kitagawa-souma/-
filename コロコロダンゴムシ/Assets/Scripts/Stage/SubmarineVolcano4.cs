using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SubmarineVolcano4 : MonoBehaviour
{
    GameObject submarinVolcano4;
    //SubmarineVolcano4 script;

    private float timer = 0.4f;
    public GameObject VolcanoPrefab = null;

    void Start()
    {
        //submarinVolcano4 = GameObject.Find("火山_4");

        //script = submarinVolcano4.GetComponent<SubmarineVolcano4>();

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
