using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem
{
    public class Ball_move : MonoBehaviour
    {
        [Header("水平速度(需設置至少1.001)")]
        public float speedX;
        [Header("垂直速度(需設置至少1.001)")]
        public float speedY;

        // [Header("實際水平速度")]
        // public float velocityX;
        // [Header("實際垂直速度")]
        // public float velocityY;
        public SteamVR_Input_Sources Hand;
        public SteamVR_Action_Boolean GrabPinchAction = SteamVR_Input.GetBooleanAction("GrabPinch");
        public Rigidbody2D m_Ball;
        public Rigidbody2D Ball {
                    get { return m_Ball;  } 
                    set { m_Ball = value; }
                }

        public CircleCollider2D m_colliderball;
        public CircleCollider2D colliderball{
            get{ return m_colliderball; }
            set{ m_colliderball = value; }
        }
        public Text ScoreText;

        private float slow_jump = 0.5f;

        void Start(){
            ScoreText.text = "目前分數:";
            m_colliderball.enabled = false;
        }

        void FixedUpdate()
        {
            bool GrabPinchpress = GrabPinchAction.GetStateDown(SteamVR_Input_Sources.RightHand);
            if (GrabPinchpress){
                ballstart();
               
            }
            ScoreText.text = "目前分數：" + GameManager.score;
        }

        void ballstart(){
            if (isStop()){
                m_colliderball.enabled = true;
                // transform.SetParent(null);
                m_Ball.velocity = new Vector2(speedX, speedY);  //velocity 速度
                
            }
        }

        bool isStop(){
            return m_Ball.velocity == Vector2.zero;

        }

        void OnCollisionEnter2D(Collision2D col) {
            lockSpeed();
            // 判斷是否有打到板子?
            // if (col.gameObject.name == "Racket") {
            //     // Calculate hit Factor
            //     float x=hitFactor(transform.position,
            //                     col.transform.position,
            //                     col.collider.bounds.size.x);

            //     // Calculate direction, set length to 1
            //     Vector2 dir = new Vector2(x, 1).normalized;

            //     // Set Velocity with dir * speed
            //     m_Ball.velocity = dir * 3;
            // }

            if(col.gameObject.tag == "brick"){
                // GameManager.brickCount--;
                m_Ball.gravityScale = 0;
                col.gameObject.SetActive(false);
                GameManager.score += 10;
                // GameManager.checkLevelClearOrNot();                   
            }
            else if(col.gameObject.tag == "BorderBottom"){
               m_Ball.gravityScale = 1;   
            }
            else if(col.gameObject.tag == "racket"){
                m_Ball.gravityScale = 0;
            }
        }

        void lockSpeed() 
        {
            Vector2 lockSpeed = new Vector2(resetSpeedX( ), resetSpeedY());
            m_Ball.velocity = lockSpeed;
        }

        float resetSpeedX () //鎖定速度
        {
            float currentSpeedX = m_Ball.velocity.x;
            if ( currentSpeedX < 0 )
            {
                return -speedX; // speedX是自己設定的
            }
            else
            {
                return speedX;
            }
        }
        float resetSpeedY()
        {
            float currentSpeedY = m_Ball.velocity.y;
            if (currentSpeedY < 0)
            {
                return -speedY; 
            }
            else
            {
                return speedY;
            }
        }
            // // Update is called once per frame
    }
}    
