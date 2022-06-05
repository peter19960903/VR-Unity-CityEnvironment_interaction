using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


namespace Valve.VR.InteractionSystem
{
    public class Racket : MonoBehaviour
    {
        public SteamVR_Input_Sources Hand;
            public SteamVR_Action_Vector2 touchpadwalkingAction = SteamVR_Input.GetVector2Action("touchpadwalking");
            public Rigidbody2D m_Racket;
            public Rigidbody2D Racket_object {
                get { return m_Racket;  } 
                set { m_Racket = value; } 
            }
            // public SteamVR_Action_Boolean headAction = SteamVR_Input.GetBooleanAction("")
            private GameObject head;
            private float x;
            private float z;
            private Vector3 velocity;
            public float speed = 12f;
            void Start()
            {
                velocity = Vector3.zero;
            }

            void FixedUpdate()
            {
                Player player = Player.instance;
                float h = touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.RightHand).x;
                m_Racket.velocity = Vector2.right * h * speed;
            }
    }
            
}       
                

            





                //另一個不是跟著頭的移動方法
                // x = touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.LeftHand).x;
                // z = touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.LeftHand).y;
                // player.transform.Translate(x,0,z);
                



                //控制輸入的範例
                // bool state = SteamVR_Actions.default_touchpadwalking[SteamVR_Input_Sources.LeftHand].state;
                // Collider.height = head.transform.localPosition.y;
                // bool padtouched = touchpadwalkingAction.GetStateDown(SteamVR_Input_Sources.LeftHand);

