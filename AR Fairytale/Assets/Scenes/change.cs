using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


public class change : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("start"));
    }
    public void LoadScene()
    {
        SceneManager.UnloadScene("start");
        //EditorSceneManager.CloseScene(SceneManager.GetSceneByName("start"), true);
    }
}