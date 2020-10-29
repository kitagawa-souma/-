using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace RunGame.Stage
{
    public class BulletFish : MonoBehaviour
    {
        public float Speed = 1.0f;
        public float radius = 0.5f;
        int BulletF_MAX = 5;
        float sakana_Posx;
        float sakana_Posy;
        float move_X;
        float move_Y;
        float angle;
        public int ID;
        public int counter;
        public GameObject BFF;

        public GameObject sakana;

        // Start is called before the first frame update
        void Start()
        {
            BFF script = BFF.GetComponent<BFF>();
            counter = script.BulletCount;
        }

        // Update is called once per frame
        void Update()
        {

            
        }

        void FixedUpdate()
        {
            //回転
            sakana_Posx = sakana.transform.position.x;
            sakana_Posy = sakana.transform.position.y;

            angle = ID * (360 / BulletF_MAX);                       //角度
            float rad = (angle + (Time.time * 100)) * Mathf.Deg2Rad;  //ラジアン
            sakana_Posx = Mathf.Cos(rad) * radius;
            sakana_Posy = Mathf.Sin(rad) * radius;

            transform.localPosition = new Vector3(sakana_Posx, sakana_Posy, 0.0f);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.tag == "Submarine volcano")
            {
                switch(counter)
                {
                    case 1:
                        counter = 0;
                        break;
                    case 2:
                        counter = 1;
                        break;
                    case 3:
                        counter = 2;
                        break;
                    case 4:
                        counter = 3;
                        break;
                    case 5:
                        counter = 4;
                        break;
                    default:
                        break;
                }
                Destroy(gameObject);
            }
        }
    }
}