using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickNewGame()
    {
        Debug.Log("�� ���� �۵�");
        SceneManager.LoadScene("2.Select");
    }

    public void OnClickLoad()
    {
        Debug.Log("�ҷ����� �۵�");
    }

    public void OnClickOption()
    {
        Debug.Log("�ɼ� �۵�");
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
