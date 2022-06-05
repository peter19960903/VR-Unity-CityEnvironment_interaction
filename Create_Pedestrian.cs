using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Random = UnityEngine.Random;

namespace Valve.VR.InteractionSystem
{
    public class Create_Pedestrian : MonoBehaviour
    {
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
        // public GameObject m_bicycle;
        // public GameObject bicycle
        // {
        //     get { return m_bicycle; }
        //     set { m_bicycle = value; }
        // }
        private float speed = 0.1f;
        private Quaternion pedestrian_rotation;

        private float Occur_time = 5.0f;
        private float occur_rate;
        private bool seen = false;
        private List<int> ped_dis_list = new List<int> { 2, 0, -2 };
        public List<GameObject> ped_list;
        private int pedestrian_index = 0;
        private int ped_dis_index = 0;

        private int appear_index = 0;

        private Vector3 target_position = new Vector3(191.5f, 0.27f, 10f);
        void Start()
        {
            Player player = Player.instance;
            occur_rate = Time.time + Occur_time; //出現頻率加三秒      
        }

        void FixedUpdate()
        {
            Player player = Player.instance;
            Global_var.hmd_forward = player.hmdTransform.forward;
            Global_var.hmd_position = player.hmdTransform.position;
            if (player.transform.position.x > 175f && player.transform.position.x < 180f)
            {
                player.transform.position = target_position;
                player.transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            }
            // Debug.Log(player.hmdTransform.eulerAngles);
            if (player.transform.position.x < 175f && (0 <= player.transform.position.z && player.transform.position.z <= 12))
            {

                if (Global_var.pedestrian_Clone)
                {
                    Global_var.pedestrian_Clone.transform.position -= new Vector3(0.05f, 0, 0);
                    if (Global_var.pedestrian_Clone.transform.position.x < player.transform.position.x)
                    {
                        Destroy(Global_var.pedestrian_Clone);
                    }
                }
                else if (Global_var.bicycle_Clone)
                {
                    Global_var.bicycle_Clone.transform.position += new Vector3(0.12f, 0, 0);
                    if (Global_var.bicycle_Clone.transform.position.x > player.transform.position.x)
                    {
                        Destroy(Global_var.bicycle_Clone);
                    }
                }
                else if (Time.time > occur_rate)
                {
                    occur_rate = Time.time + Occur_time;
                    // if ((appear_index % 4) != 0) // 輪換腳踏車跟行人 
                    // {
                    create_pedestrian(); //假如不是4的倍數 就創造行人

                    // appear_index++; //判斷是否是行人或腳踏車的index +1 
                    // }
                    // else
                    // {
                    //     create_bicycle(); //假如是4的倍數 就創造腳踏車
                    //     TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                    //     tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + GameManager.Now_Time + "," + Global_var.bicycle_Clone.name + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "");
                    //     tw.Close();
                    //     appear_index++; //判斷是否是行人或腳踏車的index +1 
                    // }
                }

            }
            else
            {
                if (Global_var.pedestrian_Clone)
                {
                    Global_var.pedestrian_Clone.transform.position -= new Vector3(0.05f, 0, 0);
                    if (Global_var.pedestrian_Clone.transform.position.x < player.transform.position.x)
                    {
                        Destroy(Global_var.pedestrian_Clone);
                    }
                }
                else if (Global_var.bicycle_Clone)
                {
                    Global_var.bicycle_Clone.transform.position += new Vector3(0.12f, 0, 0);
                    if (Global_var.bicycle_Clone.transform.position.x > player.transform.position.x)
                    {
                        Destroy(Global_var.bicycle_Clone);
                    }
                }

            }



        }

        void create_pedestrian() //創造行人
        {
            Player player = Player.instance;
            if (ped_list[pedestrian_index].name == "bicycle")
            {
                Global_var.bicycle_Clone = Instantiate(ped_list[pedestrian_index], new Vector3(player.transform.position.x - 50.0f, ped_list[pedestrian_index].transform.position.y, player.transform.position.z), ped_list[pedestrian_index].transform.rotation);
                TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + GameManager.Now_Time + "," + Global_var.bicycle_Clone.name + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "");
                tw.Close();
            }
            else
            {
                if (player.transform.position.z > 9.0f)
                {
                    Global_var.pedestrian_Clone = Instantiate(ped_list[pedestrian_index], new Vector3(player.transform.position.x + 50.0f, ped_list[pedestrian_index].transform.position.y, player.transform.position.z - 2.0f + ped_dis_list[ped_dis_index]), ped_list[pedestrian_index].transform.rotation);
                }
                else if (player.transform.position.z < 3.0f)
                {
                    Global_var.pedestrian_Clone = Instantiate(ped_list[pedestrian_index], new Vector3(player.transform.position.x + 50.0f, ped_list[pedestrian_index].transform.position.y, player.transform.position.z + 2.0f + ped_dis_list[ped_dis_index]), ped_list[pedestrian_index].transform.rotation);
                }
                else
                {
                    Global_var.pedestrian_Clone = Instantiate(ped_list[pedestrian_index], new Vector3(player.transform.position.x + 50.0f, ped_list[pedestrian_index].transform.position.y, player.transform.position.z + ped_dis_list[ped_dis_index]), ped_list[pedestrian_index].transform.rotation);
                }
                TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + GameManager.Now_Time + "," + Global_var.pedestrian_Clone.name + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "");
                tw.Close();

            }

            if (pedestrian_index >= ped_list.Count - 1)  //假如 行人的index大於 他的數目 重新generate
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
        private List<GameObject> generate_gameobject(List<GameObject> temp_list)  //將gameobject list 隨機
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

        private List<int> generate(List<int> temp_list)    //將int list 隨機
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
    }
}


//分開建立腳踏車的方法
// void create_bicycle()
// {
//     Player player = Player.instance;
//     Global_var.bicycle_Clone = Instantiate(m_bicycle, new Vector3(player.transform.position.x - 35.0f, ped_list[pedestrian_index].transform.position.y, player.transform.position.z), m_bicycle.transform.rotation);
// }