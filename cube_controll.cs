using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


namespace Valve.VR.InteractionSystem
{
    public class cube_controll : MonoBehaviour
    {
        public SteamVR_Input_Sources Hand;
        public SteamVR_Action_Vector2 touchpadwalkingAction = SteamVR_Input.GetVector2Action("touchpadwalking"); 
        public Transform m_Cube;
        public Transform Cube{
            get { return m_Cube;  } 
            set { m_Cube = value; } 
        }
        
        // public SteamVR_Action_Boolean headAction = SteamVR_Input.GetBooleanAction("")
        private GameObject head;
        private float x;
        private float z;
        private Vector3 velocity;
        private float speed = 0.01f;
        void Start()
        {
            Player player = Player.instance;
            // if (Hand != null)
            // {
            //     Debug.Log("找到手手");
            // }
            head = GameObject.Find("VRCamera");
            if(head != null )
            {
                Debug.Log("找到頭");
                Debug.Log(head.transform.localPosition.y);
                // Debug.Log(VRCamera.transform.localPosition.y);
            }
            velocity = Vector3.zero;
        }
        
        void FixedUpdate()
        {
            Player player = Player.instance;
            // Debug.Log("頭的角度:"+ player.hmdTransform.eulerAngles);
            player.hmdTransform.eulerAngles = new Vector3(0, player.hmdTransform.eulerAngles.y,0);
            Debug.Log(m_Cube.position.x);
            if (touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.RightHand).x > 0.0)
            {
                if(m_Cube.position.x <= 233.6){
                    m_Cube.transform.position += m_Cube.transform.right*speed;
                }
            }
            else if (touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.RightHand).x < 0.0)
            { 
                if(m_Cube.transform.position.x >= -15.7){
                    m_Cube.transform.position -= m_Cube.transform.right*speed;
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
     }
}

