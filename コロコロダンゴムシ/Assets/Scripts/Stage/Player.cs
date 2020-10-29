using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using RunGame.Stage;
using System;

namespace RunGame.Stage
{
    /// <summary>
    /// 『ダンゴムシ』を表します。
    /// </summary>
    public class Player : MonoBehaviour
    {
        // 通常の移動速度を指定します。
        private float player_up = 0.0f;
        private float player_down = 0.0f;
        private float player_right = 0.0f;
        private float player_left = 0.0f;
        public Vector2 player_pos;
        private float timer = 0.0f;
        private float effecttimer = 0.0f;
        private float slow_speed = 0.01f;
        private float speed_lim = 0.2f;
        private float accelerate = 0.005f;
        GameObject scenecontroller;
        SceneController script;
        private bool timer_on = false;
        private bool buf = false;

        public Vector2 Player_pos
        {
            get { return player_pos; }
            set { player_pos = value; }
        }

        /// <summary>
        /// プレイ中の場合はtrue、ステージ開始前またはゲームオーバー時にはfalse
        /// </summary>
        public bool IsActive {
            get { return isActive; }
            set { isActive = value; }
        }
        bool isActive = false;

        // コンポーネントを事前に参照しておく変数
        Animator animator;
        new Rigidbody2D rigidbody;
        // サウンドエフェクト再生用のAudioSource
        AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            // 事前にコンポーネントを参照
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();

            scenecontroller = GameObject.Find("scenecontroller");
            script = scenecontroller.GetComponent<SceneController>();

            // Box Collider 2Dの判定エリアを取得
            var collider = GetComponent<BoxCollider2D>();
            // 範囲を決定
            Vector2 size = collider.size;
            size.x *= 0.75f;    // 横幅
            size.y *= 0.25f;    // 高さは4分の1
        }

        // Update is called once per frame
        void Update()
        {
             Vector2 player_pos = transform.position;
            Player_pos = player_pos;
        }

    private void FixedUpdate()
        {
            bool is_pushed_Up_arrow = Input.GetKey(KeyCode.W);
            bool is_pushed_Down_arrow = Input.GetKey(KeyCode.S);
            bool is_pushed_Right_arrow = Input.GetKey(KeyCode.D);
            bool is_pushed_Left_arrow = Input.GetKey(KeyCode.A);

            bool is_pushedup_up_arrow = Input.GetKeyUp(KeyCode.W);
            bool is_pushedup_down_arrow = Input.GetKeyUp(KeyCode.S);
            bool is_pushedup_right_arrow = Input.GetKeyUp(KeyCode.D);
            bool is_pushedup_left_arrow = Input.GetKeyUp(KeyCode.A);

            bool InertiaFlag_up = false;
            bool InertiaFlag_down = false;
            bool InertiaFlag_right = false;
            bool InertiaFlag_left = false;

            if (is_pushed_Up_arrow == true)
            {
                InertiaFlag_up = false;
                if (player_up < speed_lim && InertiaFlag_up == false)
                {
                    player_up += accelerate;
                }
                transform.Translate(0.0f, player_up, 0.0f);   
            }
            else if (is_pushed_Up_arrow == false)
            {
                InertiaFlag_up = true;
            }
            if (InertiaFlag_up == true)
            {
                if (player_up > 0.0f)
                {
                    player_up -= slow_speed;
                    transform.Translate(0.0f, player_up, 0.0f);
                }
            }

            if (is_pushed_Down_arrow == true)
            {
                InertiaFlag_down = false;
                if (player_down < speed_lim && InertiaFlag_down == false)
                {
                    player_down += accelerate;
                }
                transform.Translate(0.0f, -player_down, 0.0f);
            }
            else if (is_pushed_Down_arrow == false)
            {
                InertiaFlag_down = true;
            }
            if (InertiaFlag_down == true)
            {
                if (player_down > 0.0f)
                {
                    player_down -= slow_speed;
                    transform.Translate(0.0f, -player_down, 0.0f);
                }
            }

            if (is_pushed_Right_arrow == true)
            {
                InertiaFlag_right = false;
                if (player_right < speed_lim && InertiaFlag_right == false)
                {
                    player_right += accelerate;
                }
                transform.Translate(player_right, 0.0f, 0.0f);
            }
            else if (is_pushed_Right_arrow == false)
            {
                InertiaFlag_right = true;
            }
            if (InertiaFlag_right == true)
            {
                if (player_right > 0.0f)
                {
                    player_right -= slow_speed;
                    transform.Translate(player_right, 0.0f, 0.0f);
                }
            }
            if (is_pushed_Left_arrow == true)
            {
                InertiaFlag_left = false;
                if (player_left < speed_lim && InertiaFlag_left == false)
                {
                    player_left += accelerate;
                }
                transform.Translate(-player_left, 0.0f, 0.0f);
            }
            else if (is_pushed_Left_arrow == false)
            {
                InertiaFlag_left = true;
            }
            if (InertiaFlag_left == true)
            {
                if (player_left > 0.0f)
                {
                    player_left -= slow_speed;
                    transform.Translate(-player_left, 0.0f, 0.0f);
                }
            }
            if(timer_on == true)
            {
                timer += Time.deltaTime;
                effecttimer += Time.deltaTime;

                if (timer >= 1.0f)
                {
                    //スコア毎秒60上昇
                    script.score += 60;
                    timer = 0.0f;
                }

                if (effecttimer < 6.0f && buf == true)
                {
                    player_up *= 4.0f;
                    player_down *= 4.0f;
                    player_right *= 4.0f;
                    player_left *= 4.0f;
                    slow_speed *= 4.0f;
                    speed_lim *= 4.0f;
                    accelerate *= 4.0f;
                    buf = false;
                }
                if (effecttimer >= 6.0f)
                {
                    slow_speed = 0.01f;
                    speed_lim = 0.2f;
                    accelerate = 0.005f;
                    timer_on = false;
                }
            }
        }

        /// <summary>
        /// このプレイヤーが他のオブジェクトのトリガー内に侵入した際に
        /// 呼び出されます。
        /// </summary>
        /// <param name="collider">侵入したトリガー</param>
        private void OnTriggerEnter2D(Collider2D collider)
        {
            // ゴール判定
            if (collider.tag == "Finish")
            {
                SceneController.Instance.StageClear();
            }
            //// ゲームオーバー判定
            //else if (collider.tag == "GameOver")
            //{
            //    SceneController.Instance.GameOver();
            //}
            // アイテムを取得
            else if (collider.tag == "Item")
            {
                timer_on = true;
                buf = true;
            }
        }
    }
}