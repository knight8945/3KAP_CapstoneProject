using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    Transform playerTransform;
    Vector3 Offset; // ī�޶�� �÷��̾� ������ �Ÿ� ����

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position; //ī�޶� ��ġ - �÷��̾� ��ġ    
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset; //ī�޶� ��ġ = �÷��̾� ��ġ + �Ÿ�
    }
}