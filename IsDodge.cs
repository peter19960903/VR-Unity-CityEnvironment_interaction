using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Valve.VR.InteractionSystem
{
    public class IsDodge : MonoBehaviour
    {
        private bool seen;
        private float player_position;
        private float player_position_record;

        void Start()
        {
            seen = false;
        }
        void FixedUpdate()
        {
            Player player = Player.instance;
            player_position = player.hmdTransform.position.x;
            if (Global_var.pedestrian_Clone)  //要判斷是否存在 遇到一個坑 少了這段 整個遊戲不能執行
            {
                if (Global_var.Gaze_Objectname == Global_var.pedestrian_Clone.name) //假如eyetracking 看到的行人物件和目前創造的物件一樣
                {
                    if (seen == false) //檢查 是不是看過了 也就是 seen 是不是等於true 如果不是將記錄記下來
                    {
                        player_position_record = player_position;
                    }
                    seen = true; //然後讓seen 變成true 表示看過了 上面記錄就不會在改變
                }
                if (seen == true) //當seen看過了之後 去判斷什麼時候 player的x座標 也就是左右橫移的變量超過0.6 
                {
                    if (((player_position_record - 1f) > player_position) || ((player_position_record + 1f) < player_position)) //如果超過0.6就判定他是有看到目標才進行閃躲
                    {
                        TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                        tw.WriteLine(GameManager.Now_Time + "," + "" + "," + GameManager.Now_Time + "," + "" + "," + Global_var.pedestrian_Clone.name + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + ""+ "," + ""+ "," + ""+ ","+ ""+ ","+ ""+ ","+ ""+ ","+ ""+ ","+ ""+ ","+ ""+ ","+ "");
                        tw.Close();
                        player_position_record = player.hmdTransform.position.x; // 一旦判斷 就讓 紀錄的record 更新成現在的位置
                        seen = false; //seen也變成false 等待下次判斷循環
                    }
                }
            }
            
            if (Global_var.bicycle_Clone)  //要判斷是否存在 遇到一個坑 少了這段 整個遊戲不能執行
            {
                if (Global_var.Gaze_Objectname == Global_var.bicycle_Clone.name) //假如eyetracking 看到的物件和目前創造的腳踏車物件一樣
                {
                    if (seen == false) //檢查 是不是看過了 也就是 seen 是不是等於true 如果不是將記錄記下來
                    {
                        player_position_record = player_position;
                    }
                    seen = true; //然後讓seen 變成true 表示看過了 上面記錄就不會在改變
                }
                if (seen == true) //當seen看過了之後 去判斷什麼時候 player的x座標 也就是左右橫移的變量超過0.6 
                {
                    if (((player_position_record - 1f) > player_position) || ((player_position_record + 1f) < player_position)) //如果超過0.6就判定他是有看到目標才進行閃躲
                    {
                        TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
                        tw.WriteLine(GameManager.Now_Time + "," + "" + "," + GameManager.Now_Time + "," + "" + "," + Global_var.bicycle_Clone.name + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "" + "," + ""+ "," + ""+ ","+ ""+ ","+ ""+ ","+ ""+ ","+ ""+ ","+ ""+ ","+ ""+ ","+ "");
                        tw.Close();
                        player_position_record = player.hmdTransform.position.x; // 一旦判斷 就讓 紀錄的record 更新成現在的位置
                        seen = false;//seen也變成false 等待下次判斷循環
                    }
                }
                
            
            }

        }
    }
}