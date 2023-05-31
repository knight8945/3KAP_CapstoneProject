using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public GameObject Player;
    public GameObject MainCamera;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene(int indicater)
    {
        if (indicater == 1)
        {
            PlayerPrefs.SetInt("Data", 1080);
            SceneManager.LoadSceneAsync("start", LoadSceneMode.Additive);
        }

        if (indicater == 2)
        {
            SceneManager.LoadSceneAsync("ending");
        }
    }
  
    IEnumerator FadeCoroutine()
    {
        float fadecount = 0;

        while (fadecount < 1.0f)
        {
            fadecount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadecount);
        }
    }
}

