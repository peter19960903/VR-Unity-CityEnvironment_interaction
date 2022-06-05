using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


namespace Valve.VR.InteractionSystem
{
    public class touchpadmoving : MonoBehaviour
    {
        private float Speed = 0.02f;
        public SteamVR_Input_Sources Hand;
        public SteamVR_Action_Vector2 touchpadwalkingAction = SteamVR_Input.GetVector2Action("touchpadwalking");
        // public SteamVR_Action_Boolean headAction = SteamVR_Input.GetBooleanAction("")
        public GameObject head;
        private Vector3 player_rotation;
        private Vector3 forward;
        
        void Start()
        {
            Player player = Player.instance;
        
            head = GameObject.Find("VRCamera");
            
            if(head != null )
            {
                Debug.Log("找到頭");
                Debug.Log(head.transform.localPosition.y);
                // Debug.Log(VRCamera.transform.localPosition.y);
            }
        }
        void FixedUpdate()
        {
            Player player = Player.instance;
            forward = player.hmdTransform.forward;
            forward.y = 0f;
            // Debug.Log("頭的角度:"+ player.hmdTransform.eulerAngles);
            
            // player.hmdTransform.eulerAngles = new Vector3(0, player.hmdTransform.eulerAngles.y,0);
            if (player.transform.position.x < 180.0f)
            {
                if (touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.LeftHand).y > 0.0)
                {
                // Debug.Log("手在上半部");
                player.transform.position += forward*Speed;   
                }
                else if (touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.LeftHand).y < 0.0)
                { 
                    // Debug.Log("手在下半部");
                    player.transform.position -= forward*Speed;
                    // 輸出左手的座標
                    // Debug.Log(touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.LeftHand));
                }    
            }
            else{
                if (touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.LeftHand).y > 0.0)
                {
                // Debug.Log("手在上半部");
                    player.transform.position -= new Vector3(0f, 0, 0.02f);
                }
                else if (touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.LeftHand).y < 0.0)
                { 
                    // Debug.Log("手在下半部");
                    player.transform.position += new Vector3(0f, 0, 0.02f);
                    // 輸出左手的座標
                    // Debug.Log(touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.LeftHand));
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

