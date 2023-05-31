using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class change : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("start"));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("ending"));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("tree"));
    }
    public void LoadScene()
    {
        //SceneManager.UnloadScene("start");
        //EditorSceneManager.CloseScene(SceneManager.GetSceneByName("start"), true);
    }
}