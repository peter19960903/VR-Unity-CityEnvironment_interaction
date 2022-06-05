using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Valve.VR.InteractionSystem
{
    public class Menu_Controll : MonoBehaviour
    {
        public SteamVR_Action_Boolean GrabPinchAction = SteamVR_Input.GetBooleanAction("GrabPinch");
        public GameObject m_point;

        public GameObject point{
            get{return m_point;}
            set{m_point = value;}
        }

        // public Button m_Button;
        // public Button Button_Object{
        //     get{return m_Button;}
        //     set{m_Button = value;}
        // }

        // public Button m_Button1;
        // public Button Button_Object1{
        //     get{return m_Button1;}
        //     set{m_Button1 = value;}
        // }

        // public Toggle m_Toggle;
        // public Toggle Toggle{
        //     get{return m_Toggle;}
        //     set{m_Toggle = value;}
        // }

        // public GameObject m_Button_gameobject;
        // public GameObject Button_gameobject{
        //     get{return m_Button_gameobject;}
        //     set{m_Button_gameobject= value;}
        // }

        // public GameObject m_Button_gameobject1;
        // public GameObject Button_gameobject1{
        //     get{return m_Button_gameobject1;}
        //     set{m_Button_gameobject1= value;} 
        // }
        // public Text Toggle_text;
        public float Speed = 0.001f;
        public SteamVR_Action_Vector2 touchpadwalkingAction = SteamVR_Input.GetVector2Action("touchpadwalking");
        private Vector2 pointer; 
        public bool GrabPinchpress;
        
        public List<Toggle> toggleList;
        void FixedUpdate()
        {   
            pointer = touchpadwalkingAction.GetAxis(SteamVR_Input_Sources.RightHand);
            m_point.transform.Translate(new Vector3 (pointer.x, pointer.y, 0) * Time.deltaTime) ; 
        }
        void OnTriggerStay2D(Collider2D Col){
            
            if(Col.gameObject.tag == "Toggle0")
            {
                toggleList[0].Select();
                if (GrabPinchAction.GetStateDown(SteamVR_Input_Sources.RightHand)){   
                    if(toggleList[0].interactable == true){
                        toggleList[0].isOn = true;
                        toggleList[1].isOn = false;
                        toggleList[2].isOn = false;
                        toggleList[3].isOn = false;
                    }
                }
            }
            else if(Col.gameObject.tag == "Toggle1")
            {
                toggleList[1].Select();
                if (GrabPinchAction.GetStateDown(SteamVR_Input_Sources.RightHand)){   
                    if(toggleList[1].interactable == true){
                        toggleList[0].isOn = false;
                        toggleList[1].isOn = true;
                        toggleList[2].isOn = false;
                        toggleList[3].isOn = false;
                    }
                }
            }
            
            else if(Col.gameObject.tag == "Toggle2")
            {
                toggleList[2].Select();
                if (GrabPinchAction.GetStateDown(SteamVR_Input_Sources.RightHand)){   
                    if(toggleList[2].interactable == true){
                        toggleList[0].isOn = false;
                        toggleList[1].isOn = false;
                        toggleList[2].isOn = true;
                        toggleList[3].isOn = false;
                    }
                }
            }
            else if(Col.gameObject.tag == "Toggle3")
            {
                toggleList[3].Select();
                if (GrabPinchAction.GetStateDown(SteamVR_Input_Sources.RightHand)){   
                    if(toggleList[3].interactable == true){
                        toggleList[0].isOn = false;
                        toggleList[1].isOn = false;
                        toggleList[2].isOn = true;
                        toggleList[3].isOn = false;
                    }
                        
                }
            }
            EventSystem.current.SetSelectedGameObject(null); //讓select 的選項顏色復原

            // if(Col.gameObject.tag == "Button1")
            // {
            //     m_Button1.Select();
            //     if (GrabPinchpress){
            //         Debug.Log("撞爛了");    
            //         m_Button1.onClick.Invoke();
            //     }
            // }    
        }
        
        // public void Clickme(){
        //     m_Button_gameobject.SetActive(false);
        // }

        // public void Clickhim(){
        //     m_Button_gameobject.SetActive(true);
        // }
        
        
    }
}