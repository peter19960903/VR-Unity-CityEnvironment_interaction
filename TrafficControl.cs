using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficControl : MonoBehaviour
{
    private GameObject m_Trafficlight1;
    public GameObject TrafficLighht1{
        get{return m_Trafficlight1;}
        set{value = m_Trafficlight1;}
    }

    private GameObject m_Trafficlight2;
    public GameObject TrafficLighht2{
        get{return m_Trafficlight2;}
        set{value = m_Trafficlight2;}
    }
    private GameObject m_Trafficlight3;
    public GameObject TrafficLighht3{
        get{return m_Trafficlight3;}
        set{value = m_Trafficlight3;}
    }

    private GameObject m_Trafficlight4;
    public GameObject TrafficLighht4{
        get{return m_Trafficlight4;}
        set{value = m_Trafficlight4;}
    }

    private List<bool> TrafficLightsystem;    
    void Start()
    {
        TrafficLightsystem = new List<bool>{true, true, false, false};
    }
    void Update()
    {
        
    }
}
