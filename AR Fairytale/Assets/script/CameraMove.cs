using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    Vector3 cameraPosition;

    [SerializeField]
    Vector2 center;
    [SerializeField]
    Vector2 mapSize;

    [SerializeField]
    float cameraMoveSpeed;
    float height;
    float width;

    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        //플레이어 main
        if (playerTransform.position.x > -13 && playerTransform.position.x < 23 && playerTransform.position.y < 9 && playerTransform.position.y > -9)
        {
            transform.position = Vector3.Lerp(transform.position,
                                          playerTransform.position + cameraPosition,
                                          Time.deltaTime * cameraMoveSpeed);
            float lx = mapSize.x - width;
            float clampX = Mathf.Clamp(transform.position.x, -lx + 5f, lx + 5f);

            float ly = mapSize.y - height;
            float clampY = Mathf.Clamp(transform.position.y, -ly + 0f, ly + 0f);

            transform.position = new Vector3(clampX, clampY, -10f);
        }
        //플레이어 빨간모자집
        else if (playerTransform.position.x > -9 && playerTransform.position.x < 9 && playerTransform.position.y < 26 && playerTransform.position.y > 14)
        {
            transform.position = Vector3.Lerp(transform.position,
                                           playerTransform.position + cameraPosition,
                                           Time.deltaTime * cameraMoveSpeed);

            float clampX = Mathf.Clamp(transform.position.x, -0.7f, 0.7f);
            float clampY = Mathf.Clamp(transform.position.y, 19.5f, 20.5f);

            transform.position = new Vector3(clampX, clampY, -10f);
        }
        //플레이어 forest
        else if (playerTransform.position.x > -6 && playerTransform.position.x < 11.5 && playerTransform.position.y < -16 && playerTransform.position.y > -25)
        {
            transform.position = Vector3.Lerp(transform.position,
                                           playerTransform.position + cameraPosition,
                                           Time.deltaTime * cameraMoveSpeed);
     
            float clampX = Mathf.Clamp(transform.position.x, 2.5f, 3.5f);
            float clampY = Mathf.Clamp(transform.position.y, -21f, -20f);

            transform.position = new Vector3(clampX, clampY, -10f);
        }
        //플레이어 flower
        else if (playerTransform.position.x > 21 && playerTransform.position.x < 39 && playerTransform.position.y < -14 && playerTransform.position.y > -26)
        {
            transform.position = Vector3.Lerp(transform.position,
                                           playerTransform.position + cameraPosition,
                                           Time.deltaTime * cameraMoveSpeed);
            float clampX = Mathf.Clamp(transform.position.x, 29.5f, 30.5f);
            float clampY = Mathf.Clamp(transform.position.y, -20.5f, -20f);

            transform.position = new Vector3(clampX, clampY, -10f);
        }
        //플레이어 shack
        else if (playerTransform.position.x > 51 && playerTransform.position.x < 69 && playerTransform.position.y < -14 && playerTransform.position.y > -26)
        {
            transform.position = Vector3.Lerp(transform.position,
                                           playerTransform.position + cameraPosition,
                                           Time.deltaTime * cameraMoveSpeed);
            float clampX = Mathf.Clamp(transform.position.x, 59.5f, 60.5f);
            float clampY = Mathf.Clamp(transform.position.y, -20.5f, -20f);

            transform.position = new Vector3(clampX, clampY, -10f);
        }
        //플레이어 할머니집
        else if (playerTransform.position.x > 62 && playerTransform.position.x < 82 && playerTransform.position.y < 6 && playerTransform.position.y > -6)
        {
            transform.position = Vector3.Lerp(transform.position,
                                           playerTransform.position + cameraPosition,
                                           Time.deltaTime * cameraMoveSpeed);
            float clampX = Mathf.Clamp(transform.position.x, 72.3f, 73.3f);
            float clampY = Mathf.Clamp(transform.position.y, 0f, 0.5f);

            transform.position = new Vector3(clampX, clampY, -10f);
        }
    }

    /*
    void LimitCameraArea()
    {
        transform.position = Vector3.Lerp(transform.position,
                                          playerTransform.position + cameraPosition,
                                          Time.deltaTime * cameraMoveSpeed);
        float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + 5f, lx + 5f);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + 0f, ly + 0f);

        transform.position = new Vector3(clampX, clampY, -10f);
    }
    */
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
}