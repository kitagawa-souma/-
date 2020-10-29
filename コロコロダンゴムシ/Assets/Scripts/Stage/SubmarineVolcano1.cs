using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SubmarineVolcano1 : MonoBehaviour
{
    GameObject submarinVolcano1;
    //SubmarineVolcano1 script;

    private float timer = 0.4f;
    public GameObject VolcanoPrefab = null;

    void Start()
    {
        //submarinVolcano1 = GameObject.Find("火山_1");

        //script = submarinVolcano1.GetComponent<SubmarineVolcano1>();

        Invoke("DelayMethod", timer);
    }

    void Update()
    {
        transform.Translate(-0.01f, 0, 0);
    }

    void DelayMethod()
    {
        Debug.Log("Volcano1.DelayMethod");
        Vector2 volcano_pos = transform.position;
        Instantiate(VolcanoPrefab,
                    volcano_pos,
                    Quaternion.identity);
        Destroy(gameObject);
    }
}
