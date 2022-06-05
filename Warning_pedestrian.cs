using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class Warning_pedestrian : MonoBehaviour
    {
        public GameObject m_Back_bike;

        public GameObject Back_bike
        {
            get { return m_Back_bike; }
            set { m_Back_bike = value; }
        }
        public GameObject m_Front_pedestrian;
        public GameObject m_Right_pedestrian;
        public GameObject m_Left_pedestrian;
        public LayerMask current_Layer;
        private List<GameObject> Iconlist;
        void Start()
        {
            Iconlist = new List<GameObject> { m_Back_bike, m_Front_pedestrian, m_Right_pedestrian, m_Left_pedestrian };
            for (int i = 0; i < Iconlist.Count; i++)
            {
                Iconlist[i].SetActive(false);
            }
        }

        void FixedUpdate()
        {
            Player player = Player.instance;
            Collider[] cols = Physics.OverlapSphere(player.transform.position, 60, current_Layer);
            if (cols.Length > 0)
            {
                if (cols[0].tag.Equals("pedestrian"))
                {
                    if (cols[0].transform.position.z < player.transform.position.z - 1)
                    {
                        m_Right_pedestrian.SetActive(true);
                        m_Left_pedestrian.SetActive(false);
                        m_Front_pedestrian.SetActive(false);
                        m_Back_bike.SetActive(false);
                    }
                    else if (cols[0].transform.position.z > player.transform.position.z + 1)
                    {
                        m_Right_pedestrian.SetActive(false);
                        m_Left_pedestrian.SetActive(true);
                        m_Front_pedestrian.SetActive(false);
                        m_Back_bike.SetActive(false);
                    }
                    else
                    {
                        m_Right_pedestrian.SetActive(false);
                        m_Left_pedestrian.SetActive(false);
                        m_Front_pedestrian.SetActive(true);
                        m_Back_bike.SetActive(false);
                    }

                }
                else if(cols[0].tag.Equals("bike")){
                    m_Back_bike.SetActive(true);
                    m_Right_pedestrian.SetActive(false);
                    m_Left_pedestrian.SetActive(false);
                    m_Front_pedestrian.SetActive(false);
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