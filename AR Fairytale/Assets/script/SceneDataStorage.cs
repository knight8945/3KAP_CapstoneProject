using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneDataStorage : MonoBehaviour
{
    public int data;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}