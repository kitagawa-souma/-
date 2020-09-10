using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunGame.Stage
{
    /// <summary>
    /// 『ダンゴムシ』を表します。
    /// </summary>
    public class Player : MonoBehaviour
    {
        // 通常の移動速度を指定します。
        private float speed = 0.2f;

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

        }
        private void FixedUpdate()
        {
            bool is_pushed_up_arrow = Input.GetKey(KeyCode.UpArrow);
            bool is_pushed_Down_arrow = Input.GetKey(KeyCode.DownArrow);
            bool is_pushed_Right_arrow = Input.GetKey(KeyCode.RightArrow);
            bool is_pushed_Left_arrow = Input.GetKey(KeyCode.LeftArrow);

            if (is_pushed_up_arrow == true)
            {
                transform.Translate(0.0f, speed, 0.0f);
            }
            if (is_pushed_Down_arrow == true)
            {
                transform.Translate(0.0f, -speed, 0.0f);
            }
            if (is_pushed_Right_arrow == true)
            {
                transform.Translate(speed, 0.0f, 0.0f);
            }
            if (is_pushed_Left_arrow == true)
            {
                transform.Translate(-speed, 0.0f, 0.0f);
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