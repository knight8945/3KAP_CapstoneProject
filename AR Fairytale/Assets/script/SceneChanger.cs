using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public GameObject Player;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerController>().indicater == 1)
        {
            SceneManager.LoadScene("start");
            StartCoroutine("FadeCoroutine", 2.0f);
        }
        if(Player.GetComponent<PlayerController>().indicater == 2)
        {
            SceneManager.LoadScene("ending");
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

