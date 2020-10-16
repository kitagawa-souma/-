using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

namespace RunGame.Stage
{
    /// <summary>
    /// 『ダンゴムシ』を表します。
    /// </summary>
    public class Player : MonoBehaviour
    {
        // 通常の移動速度を指定します。
        private float P_posY = 0.0f;
        private float player_down = 0.0f;
        private float player_right = 0.0f;
        private float player_left = 0.0f;
        public Vector2 player_pos;

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
            bool is_pushed_Up_arrow = Input.GetKey(KeyCode.UpArrow);
            bool is_pushed_Down_arrow = Input.GetKey(KeyCode.DownArrow);
            bool is_pushed_Right_arrow = Input.GetKey(KeyCode.RightArrow);
            bool is_pushed_Left_arrow = Input.GetKey(KeyCode.LeftArrow);

            bool is_pushedup_up_arrow = Input.GetKeyUp(KeyCode.UpArrow);
            bool is_pushedup_down_arrow = Input.GetKeyUp(KeyCode.DownArrow);
            bool is_pushedup_right_arrow = Input.GetKeyUp(KeyCode.RightArrow);
            bool is_pushedup_left_arrow = Input.GetKeyUp(KeyCode.LeftArrow);

            bool InertiaFlag_up = false;
            bool InertiaFlag_down = false;
            bool InertiaFlag_right = false;
            bool InertiaFlag_left = false;

            if (is_pushed_Up_arrow == true)
            {
                InertiaFlag_up = false;
                if (P_posY < 0.2f && InertiaFlag_up == false)
                {
                    P_posY += 0.005f;
                }
                transform.Translate(0.0f, P_posY, 0.0f);   
            }
            else if (is_pushed_Up_arrow == false)
            {
                InertiaFlag_up = true;
            }
            if (InertiaFlag_up == true)
            {
                if (P_posY > 0.0f)
                {
                    P_posY -= 0.01f;
                    transform.Translate(0.0f, P_posY, 0.0f);
                }
            }

            if (is_pushed_Down_arrow == true)
            {
                InertiaFlag_down = false;
                if (player_down < 0.2f && InertiaFlag_down == false)
                {
                    player_down += 0.005f;
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
                    player_down -= 0.01f;
                    transform.Translate(0.0f, -player_down, 0.0f);
                }
            }

            if (is_pushed_Right_arrow == true)
            {
                InertiaFlag_right = false;
                if (player_right < 0.2f && InertiaFlag_right == false)
                {
                    player_right += 0.005f;
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
                    player_right -= 0.01f;
                    transform.Translate(player_right, 0.0f, 0.0f);
                }
            }
            if (is_pushed_Left_arrow == true)
            {
                InertiaFlag_left = false;
                if (player_left < 0.2f && InertiaFlag_left == false)
                {
                    player_left += 0.005f;
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
                    player_left -= 0.01f;
                    transform.Translate(-player_left, 0.0f, 0.0f);
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
            // ゲームオーバー判定
            else if (collider.tag == "GameOver")
            {
                SceneController.Instance.GameOver();
            }
            // アイテムを取得
            else if (collider.tag == "Item")
            {
                // 取得したアイテムを削除
                Destroy(collider.gameObject);
            }
        }
    }
}