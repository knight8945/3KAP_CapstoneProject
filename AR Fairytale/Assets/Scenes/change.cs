using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;


public class change : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("start"));
    }
    public void LoadScene()
    {
        //SceneManager.UnloadSceneAsync("start");
        EditorSceneManager.CloseScene(SceneManager.GetSceneByName("start"), true);
    }
}