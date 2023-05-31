using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class woodenLog_touch : MonoBehaviour
{
    public void LoadScene()
    {
        if (Input.touchCount > 10)
        {
            Touch touch = Input.GetTouch(0);
            SceneManager.LoadScene(1);
        }
    }
}
