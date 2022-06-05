using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System.IO;
using System;
using Random = UnityEngine.Random;

//多功能大雜燴紀錄 已分解成不同小script

namespace Valve.VR.InteractionSystem
{
    public class Pedestrian : MonoBehaviour
    {
        private Vector3 pedestrian_position;
        public GameObject m_boy;
        public GameObject boy
        {
            get { return m_boy; }
            set { m_boy = value; }
        }
        public GameObject m_prettygirl;
        public GameObject prettygirl
        {
            get { return m_prettygirl; }
            set { m_prettygirl = value; }
        }


        public GameObject m_girl;
        public GameObject girl
        {
            get { return m_girl; }
            set { m_girl = value; }
        }
        public GameObject m_bicycle;
        public GameObject bicycle
        {
            get { return m_bicycle; }
            set { m_bicycle = value; }
        }
        public float speed = 0.1f;

        public float player_position_record;

        public float player_position;
        public Quaternion pedestrian_rotation;

        private float Occur_time = 3;
        private float occur_rate;

        private bool seen = false;

        // public float front;

        public bool sign;
        public List<int> ped_dis_list = new List<int> { 2, 0, -2 };

        public List<GameObject> ped_list;
        private int pedestrian_index = 0;
        private int ped_dis_index = 0;

        private int appear_index = 0;


        void Start()
        {
            Player player = Player.instance;
            occur_rate = Time.time + Occur_time; //出現頻率加三秒
            player_position = player.hmdTransform.position.x;
        }

        void Update()
        {
            Player player = Player.instance;
            player_position = player.hmdTransform.position.x;
            pedestrian_position = new Vector3(player.transform.position.x, -0.121f, player.transform.position.z + 10.0f);
            if (Global_var.pedestrian_Clone)
            {
                Global_var.pedestrian_Clone.transform.position -= new Vector3(0.02f, 0, 0);
                if (Global_var.pedestrian_Clone.transform.position.x < player.transform.position.x+1.0f)
                {
                    Destroy(Global_var.pedestrian_Clone);
                }
            }
            else if (Global_var.bicycle_Clone)
            {
                Global_var.bicycle_Clone.transform.position += new Vector3(0.04f, 0, 0);
                if (Global_var.bicycle_Clone.transform.position.x > player.transform.position.x+1.0f)
                {
                    Destroy(Global_var.bicycle_Clone);
                }
            }
            else if (Time.time > occur_rate)
            {
                occur_rate = Time.time + Occur_time;
                // if ((appear_index % 4) != 0)
                // {
                create_pedestrian();
                TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + GameManager.Now_Time + "," + Global_var.pedestrian_Clone.name + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "");
                tw.Close();
                // appear_index++;
                // }
                // else
                // {
                //     create_bicycle();
                //     TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                //     tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + GameManager.Now_Time + "," + Global_var.bicycle_Clone.name + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "");
                //     tw.Close();
                //     appear_index++;
                // }

            }
            if (Global_var.Gaze_Objectname == Global_var.pedestrian_Clone.name)
            {
                if (seen != true)
                {
                    player_position_record = player.hmdTransform.position.x;
                }
                seen = true;
                // GameManager.timer = 2;
            }
            // if(GameManager.timer > 0){
            //     GameManager.timer -= Time.deltaTime;
            // }
            if ((seen == true))
            {
                if (((player_position_record - 0.6f) > player_position) || ((player_position_record + 0.6f) < player_position))
                {
                    TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                    tw.WriteLine(GameManager.Now_Time + "," + "" + "," + GameManager.Now_Time + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "");
                    tw.Close();
                    player_position_record = player.hmdTransform.position.x;
                    seen = false;
                }
                // player.hmdTransform.eulerAngles
            }
            Vector3 hmdposition = new Vector3(player.hmdTransform.position.x, player.hmdTransform.position.y, player.hmdTransform.position.z);
            // Debug.Log("頭記錄位置:"+ player_position_record + "____" +"頭即時位置"+ player_position);
            // Debug.Log("頭轉向位置:"+ player.hmdTransform.eulerAngles);
            findangle();
            // Debug.Log("前後"+ sign) ;
        }
        // void create_bicycle()
        // {
        //     Player player = Player.instance;
        //     if(player.transform.position.z >8){
                
        //     }
        //     else if(player.transform.position.z<4){

        //     }
        //     else{
        //         Global_var.bicycle_Clone = Instantiate(m_bicycle, new Vector3(player.transform.position.x - 20.0f, ped_list[pedestrian_index].transform.position.y, player.transform.position.z), m_bicycle.transform.rotation);
        //     }        
        // }
        void create_pedestrian() //創造行人
        {
            Player player = Player.instance;
            if(ped_list[pedestrian_index].tag == "bicycle"){
                    Global_var.bicycle_Clone = Instantiate(ped_list[pedestrian_index], new Vector3(player.transform.position.x - 20.0f, ped_list[pedestrian_index].transform.position.y, player.transform.position.z), m_bicycle.transform.rotation);
                }        
            else{
                if(player.transform.position.z >8){
                    Global_var.pedestrian_Clone = Instantiate(ped_list[pedestrian_index], new Vector3(player.transform.position.x + 20.0f, ped_list[pedestrian_index].transform.position.y, player.transform.position.z - 2.0f + ped_dis_list[ped_dis_index] ), ped_list[pedestrian_index].transform.rotation);
                }
                else if(player.transform.position.z<4){
                    Global_var.pedestrian_Clone = Instantiate(ped_list[pedestrian_index], new Vector3(player.transform.position.x + 20.0f, ped_list[pedestrian_index].transform.position.y, player.transform.position.z + 2.0f + ped_dis_list[ped_dis_index] ), ped_list[pedestrian_index].transform.rotation);
                }
                else{
                    Global_var.pedestrian_Clone = Instantiate(ped_list[pedestrian_index], new Vector3(player.transform.position.x + 20.0f, ped_list[pedestrian_index].transform.position.y, player.transform.position.z + ped_dis_list[ped_dis_index] ), ped_list[pedestrian_index].transform.rotation);
                }

            }
            
            if (pedestrian_index > ped_list.Count-1 )  //假如 行人的index大於 他的數目 重新generate
            {
                ped_list = generate_gameobject(ped_list);
                pedestrian_index = 0;
            }
            else
            {
                pedestrian_index++;
            }
            if (ped_dis_index >= ped_dis_list.Count - 1)
            {
                ped_dis_list = generate(ped_dis_list);
                ped_dis_index = 0;
            }
            else
            {
                ped_dis_index++;
            }
        }
        public List<GameObject> generate_gameobject(List<GameObject> temp_list)
        {
            List<GameObject> random_list = new List<GameObject>();
            int r;
            while (temp_list.Count > 0)
            {
                r = Random.Range(0, temp_list.Count);
                random_list.Add(temp_list[r]);
                temp_list.Remove(temp_list[r]);
            }
            return random_list;
        }

        public List<int> generate(List<int> temp_list)
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


        public void findangle()
        {
            Player player = Player.instance; // 導入player 讓player可以使用
            Vector3 targetdir = GameManager.Gaze_position - player.hmdTransform.position; //利用全域變數 gaze 的座標 減掉player headset的座標算出向量
            Global_var.angle = Vector3.Angle(player.hmdTransform.forward, targetdir); //和頭目前方向的向量計算夾角
            Debug.Log("EyeTracking角度" + Global_var.angle);
            // front = Vector3.Dot(transform.forward, targetdir); 判斷前後
            // if (front > 0){
            //     sign = true;
            // }
            // else{
            //     sign = false;
            // }
            Vector3 frontCross = Vector3.Cross(player.hmdTransform.forward, targetdir.normalized);
            if (frontCross.y > 0)
            {
                if (Global_var.angle < 15)
                {
                    Global_var.direction = "Central Vision";
                }
                else
                {
                    Global_var.direction = "Right-near-peripheral";
                }
            }
            else
            {
                if (Global_var.angle < 15)
                {
                    Global_var.direction = "Central Vision";
                }
                else
                {
                    Global_var.direction = "Left-near-peripheral";
                }
            }
        }
    }


}