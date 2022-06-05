using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem{
    public class GreenLight : MonoBehaviour
    {
        public Light m_GreenLight;

        public Light greenLight{
            get{return m_GreenLight;}
            set{m_GreenLight = value;}
        }

        public GameObject m_TrafficLight;

        public GameObject TrafficLight{
            get{return m_TrafficLight;}
            set{m_TrafficLight = value;}
        }
        // Start is called before the first frame update
        void Start()
        {
            m_GreenLight.enabled = true;
        }

        // Update is called once per frame
        void Update()
        {
            Player player = Player.instance;
            if(player.transform.position.x > (m_TrafficLight.transform.position.x - 15))
            {
                m_GreenLight.enabled = false;
            }
        }
    }
}