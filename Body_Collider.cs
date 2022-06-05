using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Body_Collider : MonoBehaviour
{

    public CapsuleCollider m_body;
    public CapsuleCollider body
    {
        get { return m_body; }
        set { m_body = value; }
    }
    public Rigidbody m_Rbody;

    public Rigidbody r_body
    {
        get { return m_Rbody; }
        set { m_Rbody = value; }
    }
    void OnTriggerEnter(Collider Col)
    {
        TextWriter tw = new StreamWriter(Global_var.filePath, true, System.Text.Encoding.UTF8);
        tw.WriteLine(GameManager.Now_Time + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + GameManager.score + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "" + "," + "yes" + "," + GameManager.Now_Time + "," + Col.gameObject.name + "," + "" + "," + "" + "," + "");
        tw.Close();
    }
}
