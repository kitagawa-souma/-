using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using RunGame.Stage;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    private bool Trigger = false;
    private int rotate;
    public float timer = 0.7f;
    private float pos_x;
    private float pos_y;
    private float ene_speed = 0.01f;
    GameObject scenecontroller;
    SceneController script;
    #region インスタンスへのstaticなアクセスポイント
    /// <summary>
    /// このクラスのインスタンスを取得します。
    /// </summary>
    public static Enemy Instance
    {
        get { return instance; }
    }
    static Enemy instance = null;

    /// <summary>
    /// Start()より先に実行されます。
    /// </summary>
    private void Awake()
    {
        instance = this;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        scenecontroller = GameObject.Find("scenecontroller");
        script = scenecontroller.GetComponent<SceneController>();
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
        pos_x = transform.position.x;
        pos_y = transform.position.y;
        pos_x -= ene_speed;
        transform.position = new Vector3(pos_x, pos_y, 0.0f);
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bullet")
        {
            anim.SetTrigger("Hit");
            script.score += 20;
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