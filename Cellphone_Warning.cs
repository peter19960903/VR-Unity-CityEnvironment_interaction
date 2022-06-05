using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class Cellphone_Warning : MonoBehaviour
    {
        // public GameObject m_Back_bike;

        // public GameObject Back_bike
        // {
        //     get { return m_Back_bike; }
        //     set { m_Back_bike = value; }
        // }
        public GameObject m_Front_Car;

        public GameObject Front_Car
        {
            get { return m_Front_Car; }
            set { m_Front_Car = value; }
        }
        public GameObject m_Right_Car;
        public GameObject m_Left_Car;
        // public GameObject m_Front_pedestrian;
        // public GameObject m_Right_pedestrian;
        // public GameObject m_Left_pedestrian;
        public LayerMask current_Layer;
        private List<GameObject> Iconlist;
        void Start()
        {
            Iconlist = new List<GameObject> { m_Front_Car, m_Right_Car, m_Left_Car};
            for (int i = 0; i < Iconlist.Count; i++)
            {
                Iconlist[i].SetActive(false);
            }
        }

        void Update()
        {
            Player player = Player.instance;
            Collider[] cols = Physics.OverlapSphere(player.transform.position, 60, current_Layer);
            if (cols.Length > 0)
            {
                if (cols[0].transform.position.x < player.transform.position.x - 20)
                {
                    m_Right_Car.SetActive(true);
                    m_Front_Car.SetActive(false);
                }
                else if(cols[0].transform.position.x < player.transform.position.x )
                {
                    m_Front_Car.SetActive(true);
                    m_Right_Car.SetActive(false);
                }
                else{
                    m_Front_Car.SetActive(false);
                    m_Right_Car.SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < Iconlist.Count; i++)
                {
                    Iconlist[i].SetActive(false);
                }
            }
        }
    }
}
