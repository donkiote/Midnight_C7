using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{



    void Start()
    {
        
    }

    void Update()
    {
        // 2. ����, ���� ����, üũ �Ÿ�
        // 2-1. ���̸� �����.
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // 2-2. ���̰� �浹�� ����� ������ ��� ���� ����ü�� �����Ѵ�.
        RaycastHit hitInfo;

        // 2-3. ������� ���̸� ������ ����� �Ÿ���ŭ �߻��Ѵ�.
        bool isHit = Physics.Raycast(ray, out hitInfo, 3, ~(1 << 7));
        print(hitInfo);
    }
}
