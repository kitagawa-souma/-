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
        
        public GameObject sakana;

        // Start is called before the first frame update
        void Start()
        {

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
    }
}