using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ObjectMovementScript objectMovementScript;
    public float moveDirection;

    private void Start()
    {
        // 터치 버튼에 이벤트 리스너 추가
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // 객체 이동 스크립트의 StartMoving 메서드 호출하여 이동 방향 전달
        objectMovementScript.StartMoving(moveDirection);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 버튼을 누르고 있는 동안 객체 이동 시작
        objectMovementScript.StartMoving(moveDirection);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 버튼에서 손을 뗄 때 객체 이동 중지
        objectMovementScript.StopMoving();
    }
}
