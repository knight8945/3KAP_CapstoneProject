using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// 객체 이동 스크립트 (ObjectMovementScript.cs)
public class ObjectMovementScript : MonoBehaviour
{
    private bool isMoving = false;
    private float moveSpeed = 5f;
    private float targetY;

    private void Update()
    {
        if (isMoving)
        {
            // 객체를 목표 y 위치로 이동시킴
            Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void StartMoving(float direction)
    {
        // 이동할 y 방향 설정
        targetY = transform.position.y + direction;
        // 이동 플래그 설정
        isMoving = true;
    }

    public void StopMoving()
    {
        // 이동 플래그 해제
        isMoving = false;
    }
}
