using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wolfbutton : MonoBehaviour
{
    public void LoadScene()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            SceneManager.LoadScene("6_Ending");
        }
    }
}
