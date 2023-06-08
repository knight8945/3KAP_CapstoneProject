using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfmove : MonoBehaviour
{
    public float moveSpeed = 5f; // 오브젝트의 이동 속도
    public float moveDistance = 1f; // 오브젝트가 이동할 거리

    private bool isMoving = false; // 오브젝트가 현재 이동 중인지 여부를 나타내는 플래그
    private Vector3 initialPosition; // 오브젝트의 초기 위치

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isMoving)
        {
            // 오브젝트를 Y축 방향으로 이동시킴
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // 이동 거리를 체크하여 원하는 거리만큼 이동했으면 이동을 멈춤
            if (Mathf.Abs(transform.position.y - initialPosition.y) >= moveDistance)
            {
                isMoving = false;
            }
        }
    }

    public void MoveObject()
    {
        // 버튼을 터치하여 이동을 시작함
        isMoving = true;
    }
}
