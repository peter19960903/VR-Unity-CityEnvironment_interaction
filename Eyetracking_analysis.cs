using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Eyetracking_analysis : MonoBehaviour
{
     public GameObject m_ball;
        public GameObject ball{
            get{return m_ball;}
            set{m_ball = value;}
        }

    List <string> x = new List<string>();

    List<string> y = new List<string>();
    List<string> z = new List<string>();
    string filePath;
    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.dataPath + "/Resources/test0.csv";
        ReadCSV();
    }

    // Update is called once per frame
    void ReadCSV(){
        
        StreamReader strReader = new StreamReader(filePath);
        bool endfile = false;
        
        
        while(!endfile)
        {
            string data_String = strReader.ReadLine();
            if (data_String == null)
            {
                endfile = true;
                break;
            }
            var data_values = data_String.Split(',');

            x.Add(data_values[2]);
            y.Add(data_values[3]);
            z.Add(data_values[4]);
        }

        
        Create_ball(x, y , z);
       
    }

    void Create_ball(List<string>x, List<string>y ,List<string>z )
    {
        Debug.Log("x的數量:"+ x.Count);
        Debug.Log("y的數量:"+ y.Count);
        Debug.Log("z的數量:"+ z.Count);
        for(int i = 1; i< x.Count ; i ++)
        {
            Instantiate(m_ball ,new Vector3(float.Parse(x[i]),float.Parse(y[i]),float.Parse(z[i]) ) , Quaternion.identity);
            
        }
    }
}
