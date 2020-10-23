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
        float Speed = 0.05f;
        float radius = 2.0f;
        Player player;
        float sakana_Posx;
        float sakana_Posy;
        private Vector3 defposition;

        public GameObject sakana;

        //private Vector2 initPosition;
        // Start is called before the first frame update
        void Start()
        {
            //player = FindObjectOfType<Player>();
        }

        // Update is called once per frame
        void Update()
        {
            //sakana_Posx = sakana.transform.position.x;
            //sakana_Posy = sakana.transform.position.y;
            //Vector2 initPosition_P = player.player_pos;
            //Vector2 P_pos = initPosition_P;

            float rad= Speed * Mathf.Rad2Deg * Time.time;
            sakana_Posx = Mathf.Cos(rad) * radius;
            sakana_Posy = Mathf.Sin(rad) * radius;
            //transform.position = P_pos + initPosition;
            transform.position = new Vector3(sakana_Posx + sakana.transform.position.x, sakana_Posy + sakana.transform.position.y,0.0f);
        }

        void FixedUpdate()
        {
            
        }
    }
}