using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static Vector3 Gaze_position;
    public static int score;
    
    public static int brickCount;

    public static string Now_Time;

    
    public GameObject m_Brick;
    public GameObject Brick
    {
        get { return m_Brick; }
        set { m_Brick = value; }
    }

    // public GameObject m_Canvas;
    // public GameObject Canvas{
    //     get {return m_Canvas;}
    //     set{m_Canvas = value;}
    // }
    public static bool LevelClear
    {
        get
        {
            if (brickCount <= 0)
            {
                return true;
            }
            return false;
        }
    }
    private GameObject[] brickTag;
    
    public static float timer = 0;

    void Update()
    {
        Now_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
        brickTag = GameObject.FindGameObjectsWithTag("brick");
        brickCount = brickTag.Length;
        if (LevelClear)
        {
            score += 30;
            brickCount = m_Brick.transform.childCount;
            for (int j = 0; j < brickCount; j++)
            {
                m_Brick.transform.GetChild(j).gameObject.SetActive(true);

            }
        }
    }
}

