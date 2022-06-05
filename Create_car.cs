using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.IO;

namespace Valve.VR.InteractionSystem
{
    public class Create_car : MonoBehaviour
    {
        private float[] car_position;
        public List<GameObject> Car_list;
        private List<GameObject> Clone_Car;
        private float[] road_intersection;

        private float car_fix_position_x_0 = 140.0f;

        private float timer = 0f;
        private int i_th_car =0 ;
        GameObject Car1, Car2, Car3, Car4, Car5, Car6, Car7, Car8, Car9, Car10;
        void Start()
        {
            car_position = new float[] { -10f, -50f, -90f, -130f, -170.0f, -210.0f, -250.0f, -290.0f, -330.0f, -370.0f };
            Clone_Car = new List<GameObject>() { Car1, Car2, Car3, Car4, Car5, Car6, Car7, Car8, Car9, Car10 };
            road_intersection = new float[] { -40.0f, -80.0f, -160.0f, -200.0f, -240.0f, -280.0f, -320.0f, -360.0f, -400.0f, -440.0f };
        }
        void FixedUpdate()
        {
            Player player = Player.instance;
            timer += Time.deltaTime;
            if ((player.transform.position.x > 188) && (player.transform.position.z < 5 && player.transform.position.z > -20))
            {
                if (Clone_Car[0] && Clone_Car[1])
                {
                    Clone_Car[0].transform.position += new Vector3(0.15f, 0, 0);
                    Clone_Car[1].transform.position += new Vector3(0.15f, 0, 0);
                }
                else
                {
                    create_car(0, 0, car_fix_position_x_0);
                    car_fix_position_x_0 -= 60.0f;
                    create_car(0, 1, car_fix_position_x_0);
                }
                for (int i = 2; i <= 5; i++)
                {
                    if (Clone_Car[i])
                    {
                        Clone_Car[i].transform.position += new Vector3(0.15f, 0, 0);
                    }
                    else if (i == 2 && Clone_Car[5])
                    {
                        car_fix_position_x_0 = Clone_Car[5].transform.position.x - 80.0f;
                        create_car(0, i, car_fix_position_x_0);
                    }
                    else if (i >= 2 && i <= 5)
                    {
                        car_fix_position_x_0 = Clone_Car[i - 1].transform.position.x - 80.0f;
                        create_car(0, i, car_fix_position_x_0);
                    }
                
                    if (Clone_Car[i].transform.position.x > 220.0f)
                    {
                        Destroy(Clone_Car[i]);
                    }

                }
                if (Clone_Car[0] && Clone_Car[0].transform.position.x < 187.0f)
                {
                    TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                    tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + Clone_Car[0].gameObject.name + "," + Clone_Car[0].transform.position.x + "," + Clone_Car[0].transform.position.y + "," + Clone_Car[0].transform.position.z + "," + Vector3.Distance(player.transform.position, Clone_Car[0].transform.position) + "," +timer + "," + "1");
                    tw.Close();
                }
                else if (Clone_Car[1] && Clone_Car[1].transform.position.x < 187.0f)
                {
                    TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                    tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + Clone_Car[1].gameObject.name + "," + Clone_Car[1].transform.position.x + "," + Clone_Car[1].transform.position.y + "," + Clone_Car[1].transform.position.z + "," + Vector3.Distance(player.transform.position, Clone_Car[1].transform.position)+ "," +timer + "," + "1");
                    tw.Close();
                }
                else if (Clone_Car[2] && Clone_Car[2].transform.position.x < 187.0f)
                {
                    TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                    tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + Clone_Car[2].gameObject.name + "," + Clone_Car[2].transform.position.x + "," + Clone_Car[2].transform.position.y + "," + Clone_Car[2].transform.position.z + "," + Vector3.Distance(player.transform.position, Clone_Car[2].transform.position)+ "," +timer + "," + "1");
                    tw.Close();
                }
                else if (Clone_Car[3] && Clone_Car[3].transform.position.x < 187.0f)
                {
                    TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                    tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + Clone_Car[3].gameObject.name + "," + Clone_Car[3].transform.position.x + "," + Clone_Car[3].transform.position.y + "," + Clone_Car[3].transform.position.z + "," + Vector3.Distance(player.transform.position, Clone_Car[3].transform.position)+ "," +timer + "," + "1");
                    tw.Close();
                }
                else if (Clone_Car[4] && Clone_Car[4].transform.position.x < 187.0f)
                {
                    TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                    tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + Clone_Car[4].gameObject.name + "," + Clone_Car[4].transform.position.x + "," + Clone_Car[4].transform.position.y + "," + Clone_Car[4].transform.position.z + "," + Vector3.Distance(player.transform.position, Clone_Car[4].transform.position)+ "," +timer + "," + "1");
                    tw.Close();
                }
                else if (Clone_Car[5] && Clone_Car[5].transform.position.x < 187.0f)
                {
                    TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                    tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + Clone_Car[5].gameObject.name + "," + Clone_Car[5].transform.position.x + "," + Clone_Car[5].transform.position.y + "," + Clone_Car[5].transform.position.z + "," + Vector3.Distance(player.transform.position, Clone_Car[5].transform.position)+ "," +timer + "," + "1");
                    tw.Close();
                }
                
            }
            else
            {
                for (int i = 0; i <= 5; i++)
                {
                    Destroy(Clone_Car[i]);
                }
                TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + timer + "," + "not on road");
                tw.Close();

            }
        }

        //     if ((player.transform.position.x > 188) && (player.transform.position.z < road_intersection[0] + Global_var.road_intersection_bias[0] && player.transform.position.z > road_intersection[0] - 20))
        //     {
        //         if (Clone_Car[1])
        //         {
        //             if (Clone_Car[1].name == "car_Right(Clone)")
        //             {
        //                 Clone_Car[1].transform.position += new Vector3(0.1f, 0, 0);
        //                 if (Clone_Car[1].transform.position.x > 210)
        //                 {
        //                     Destroy(Clone_Car[1]);
        //                 }
        //             }
        //         }
        //         else
        //         {
        //             create_car(1, 1, 160);
        //         }
        //     }

        //     if ((player.transform.position.x > 188) && (player.transform.position.z < road_intersection[1] + Global_var.road_intersection_bias[1] && player.transform.position.z > road_intersection[1] - 20))
        //     {
        //         if (Clone_Car[2])
        //         {
        //             if (Clone_Car[2].name == "car_Right(Clone)")
        //             {
        //                 Clone_Car[2].transform.position += new Vector3(0.1f, 0, 0);
        //                 if (Clone_Car[2].transform.position.x > 210)
        //                 {
        //                     Destroy(Clone_Car[2]);
        //                 }
        //             }
        //         }
        //         else
        //         {
        //             create_car(2, 2, 160);
        //         }
        //     }
        //     if ((player.transform.position.x > 188) && (player.transform.position.z < road_intersection[2] + Global_var.road_intersection_bias[2] && player.transform.position.z > road_intersection[2] - 20))
        //     { //中間那條路的車
        //         if (Clone_Car[3])
        //         {
        //             if (Clone_Car[3].name == "car_Right(Clone)")
        //             {
        //                 Clone_Car[3].transform.position += new Vector3(0.1f, 0, 0);
        //                 if (Clone_Car[3].transform.position.x > 210)
        //                 {
        //                     Destroy(Clone_Car[3]);
        //                 }
        //             }
        //         }
        //         else
        //         {
        //             create_car(3, 3, 160);
        //         }
        //     }
        // }
        void create_car(int i, int idx, float x_position)
        {
            if (i == 0)
            {
                Clone_Car[idx] = Instantiate(Car_list[idx], new Vector3(x_position, Car_list[i].transform.position.y, car_position[i]), Car_list[i].transform.rotation);
            }
            TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
            tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + GameManager.Now_Time + "," + Clone_Car[idx].name + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "");
            tw.Close();
        }
    }
}
