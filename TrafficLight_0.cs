using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem{
    public class TrafficLight_0 : MonoBehaviour
    {
        public GameObject m_TrafficLight0;
        public GameObject TrafficLight0{
            get{return m_TrafficLight0;}
            set{m_TrafficLight0 = value;}
        }
        public Light m_RedLight;
        public Light redLight{
            get{return m_RedLight;}
            set{m_RedLight = value;}
        }

        public Light m_GreenLight;

        public Light greenLight{
            get{return m_GreenLight;}
            set{m_GreenLight = value;}
        }
       
        private float Timer = 10.0f;
        void Start()
        {
            m_GreenLight.enabled = true;
            m_RedLight.enabled = false;
        }
        
        private float user_timer = 15.0f;
        void Update()
        {
            Player player = Player.instance; //載入player      if(player.transform.position.x > (m_TrafficLight.transform.position.x - 30))
            if(detect()==true){
                //假如附近有偵測到使用者 馬上變紅燈 
                red_light();
                user_timer -= Time.deltaTime;
                if(user_timer<=0){
                    green_light();
                }
            } 
            else{
                Timer-= Time.deltaTime;            //如果沒偵測到使用者就是10秒轉換一次
                if(Timer <= 0){
                    changeLight();
                    // Destroy(m_TrafficLight, 10);
                    Timer += 10.0f;
                }
            }
        }
        public bool detect(){
            Collider[] cols = Physics.OverlapSphere( m_TrafficLight0.transform.position, 30);
            if (cols.Length > 0){
                for(int i = 0; i<cols.Length; i++){
                    if(cols[i].tag.Equals("Player")){
                        return true;
                    }
                }
            }
            return false;
        }
        void green_light(){
            m_GreenLight.enabled = true;
            m_RedLight.enabled = false;
        }

        void red_light(){
            m_GreenLight.enabled = false;
            m_RedLight.enabled = true;
        }        
        void changeLight(){
            if(m_RedLight.enabled == true){
                m_GreenLight.enabled = true;
                m_RedLight.enabled = false;
            }
            else if(m_GreenLight.enabled == true){
                m_GreenLight.enabled = false;
                m_RedLight.enabled = true;
            }
        }
    }
}