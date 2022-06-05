using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    public void TranGame(){
        SceneManager.LoadScene(1);
    }

    public void TranRead(){
        SceneManager.LoadScene(2);
    }
    public void ARGame(){
        SceneManager.LoadScene(3);
    }
}
