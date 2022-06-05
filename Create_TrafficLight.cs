using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_TrafficLight : MonoBehaviour
{
    private float[,] TrafficLightPosition;
    private float[,] TrafficLightRotation;
    public GameObject m_TrafficLight;
    public GameObject TrafficLight{
        get{return m_TrafficLight;}
        set{m_TrafficLight = value;}
    }
    void Start()
    {  
        TrafficLightPosition = new float [4,3]{{186f, 0f, -26f},{186f ,0,-145.7f},{62, 0, -147},{-40, 0 ,-124}};
        TrafficLightRotation = new float [4,3]{{0,180,0},{0,180,0},{0,270,0},{0,0,0}};
        CreateTrafficLightposition();
        
    }


    void CreateTrafficLightposition(){
        for(int i = 0; i< Global_var.TrafficLight_status.Count; i++){
            if(Global_var.TrafficLight_status[i] == 0){
                Instantiate(m_TrafficLight, new Vector3(TrafficLightPosition[i,0],TrafficLightPosition[i,1],TrafficLightPosition[i,2]),  Quaternion.Euler(TrafficLightRotation[i,0],TrafficLightRotation[i,1],TrafficLightRotation[i,2]) );
            }
        }
    }
    
}
