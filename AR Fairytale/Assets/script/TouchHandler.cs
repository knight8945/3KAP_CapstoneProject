using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TouchHandler : MonoBehaviour
{
    public void LoadScene()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            SceneManager.LoadScene(1);
        }
    }
}


//public class ButtonHandler : MonoBehaviour
//{
//    public void LoadScene(string sceneName)
//    {
//        SceneManager.LoadScene(sceneName);
//    }
//}