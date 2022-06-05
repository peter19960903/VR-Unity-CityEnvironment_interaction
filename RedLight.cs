using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Valve.VR.InteractionSystem{
    public class RedLight : MonoBehaviour
    {
        public Light m_RedLight;
        public Light redLight{
            get{return m_RedLight;}
            set{m_RedLight = value;}
        }

        public Light m_yellowLight;

        public Light yellowLight{
            get{return m_yellowLight;}
            set{m_yellowLight = value;}
        }

        public Light m_greenLight;
        public Light greenLight{
            get{return m_greenLight;}
            set{m_greenLight = value;}
        }
        public GameObject m_TrafficLight;

        public GameObject TrafficLight{
            get{return m_TrafficLight;}
            set{m_TrafficLight = value;}
        }
        
        void Start()
        {
            if(Global_var.TrafficLight_status[0] == 1){
                m_greenLight.enabled = true;
                m_RedLight.enabled = true;
            }
            else{
                m_yellowLight.enabled = true;
                m_greenLight.enabled = false;
                m_RedLight.enabled = false;
            }
        }
        
        void Update()
        {
            Player player = Player.instance; //載入player
            if(player.transform.position.z > (m_TrafficLight.transform.position.z - 15))  //若player的位置離紅綠燈剩15，則紅燈會亮
            {
                if(Global_var.TrafficLight_status[0] == 0){
                    m_RedLight.enabled = true;
                }
                else{
                    m_yellowLight.enabled = true;
                }
            }
        }
    }
}