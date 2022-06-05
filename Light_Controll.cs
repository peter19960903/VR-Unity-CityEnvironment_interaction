using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Controll : MonoBehaviour
{
    // public Light m_light;

    // public Light light_controll{
    //     get{return m_light;}
    //     set{m_light = value;}
    // }

    public GameObject m_warn_ground;

    public GameObject warn_ground
    {
        get { return m_warn_ground; }
        set { m_warn_ground = value; }
    }

    public GameObject m_warn_sky;

    public GameObject warn_sky
    {
        get { return m_warn_sky; }
        set { m_warn_sky = value; }
    }
    public Transform m_player;
    public Transform player
    {
        get { return m_player; }
        set { m_player = value; }
    }
    void Start()
    {
        m_warn_ground.SetActive(false);
        m_warn_sky.SetActive(false);
    }
    void FixedUpdate()
    {
        if (detect() == true)
        {
            m_warn_ground.SetActive(true);
            m_warn_sky.SetActive(true);
        }
        else
        {
            m_warn_ground.SetActive(false);
            m_warn_sky.SetActive(false);
        }
    }

    private bool detect()
    {
        Collider[] cols = Physics.OverlapSphere(m_player.position, 30);
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].tag.Equals("pedestrian") | cols[i].tag.Equals("bicycle") | cols[i].tag.Equals("Car"))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
