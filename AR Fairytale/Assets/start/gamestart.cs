using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamestart : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("1_IntroScene");
    }
}
