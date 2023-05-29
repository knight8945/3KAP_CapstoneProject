using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class woodenLog_touch : MonoBehaviour
{
    public GameObject wood;
    public GameObject check;
    private int touchCount = 0;
    public Button touchButton;

    void Start()
    {
        touchButton.onClick.AddListener(ButtonTouch);
        check.SetActive(false);
    }
    public void ButtonTouch()
    {
        touchCount++;

        // 10번의 버튼 터치 이후 오브젝트를 비활성화합니다.
        if (touchCount >= 10 && wood != null)
        {
            wood.SetActive(false);
            check.SetActive(true);
        }
    }
}
