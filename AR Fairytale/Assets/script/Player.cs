using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 10.0f;     // �����̴� �ӵ�. public���� �����Ͽ� ����Ƽ ȭ�鿡�� ������ �� �ִ�.

    float h, v;                     // ������� �������� ���� ������ ���������� ����. FixedUpdate���� ���� �������� ���� ������
                                    // ���� �ٸ� �Լ������� ������ ���̱� ����.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // �̵� ���� �Լ��� © ���� Update���� FixedUpdate�� �� ȿ���� ���ٰ� �Ѵ�. �׷��� ����ߴ�.
    void FixedUpdate()
    {
        // Point 1.
        h = Input.GetAxis("Horizontal");        // ������
        v = Input.GetAxis("Vertical");          // ������

        // Point 2.
        transform.position += new Vector3(h,v, 0) * Speed * Time.deltaTime;
    }
}