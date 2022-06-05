using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Random = UnityEngine.Random;
using System.Linq;

public class Global_var : MonoBehaviour
{
    public static GameObject pedestrian_Clone;

    public static GameObject Car_Clone;
    public static GameObject bicycle_Clone;
    public static string Gaze_Objectname;

    public static string direction;
    public static float angle;

    public static bool seen;
    public static List<int> TrafficLight_status = new List<int> { 0, 1, 0, 1 };
    public static string filePath = "";
    private int excel_index = 0;  // 輸出excel資料的第幾個

    public static int RandomTraffic_index;

    public static bool Traffic_Start;
    public static Vector3 hmd_forward;

    public static Vector3 hmd_position;

    public static Vector3 Targetdir;

    public static float[] road_intersection_bias = new float[] { 5, 5, 5, 7, 7, 7, 10, 10, 10 };

    void Awake()
    {
        TrafficLight_status = generate_new_Trafficlight_order(TrafficLight_status);
        road_intersection_bias = generateRandomarray(road_intersection_bias);
    }
    void Start()
    {
        Global_var.filePath = Application.dataPath + $"/test{excel_index}.csv";
        while (File.Exists(Global_var.filePath))
        {
            excel_index++;
            Global_var.filePath = Application.dataPath + $"/test{excel_index}.csv";

        }
        TextWriter tw = new StreamWriter(Global_var.filePath, false);
        tw.WriteLine("Time, fixation time , Dodge_time, Occur_time, Object, x_position, y_position, z_position, game_score, Vision_area, hmdTransform.forward.x,hmdTransform.forward.y,hmdTransform.forward.z ,hmdTransform.position.x,hmdTransform.position.y,hmdTransform.position.z ,Targetdir.x, Targetdir.y, Targetdir.z ,fixation_angle, IsHit, Hit_time, Hit_Object, Closest car name, Closest car.x, Closest car.y, Closest car.z, Distance");
        tw.Close();

    }

    public List<int> generate_new_Trafficlight_order(List<int> temp_list)
    {
        List<int> random_list = new List<int>();
        int r;
        while (temp_list.Count > 0)
        {
            r = Random.Range(0, temp_list.Count);
            random_list.Add(temp_list[r]);
            temp_list.Remove(temp_list[r]);
        }
        return random_list;
    }

    public float[] generateRandomarray(float[] arr)
    {
        float[] ran = new float[9];
        for (int i = 0; i < arr.Length; i++)
        {
            float tmp = arr[i];
            int r = Random.Range(0, arr.Length);
            arr[i] = arr[r];
            arr[r] = tmp;
        }
        return arr;
    }
}
