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
        // 2. 방향, 레이 생성, 체크 거리
        // 2-1. 레이를 만든다.
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // 2-2. 레이가 충돌한 대상의 정보를 담기 위한 구조체를 생성한다.
        RaycastHit hitInfo;

        // 2-3. 만들어진 레이를 지정된 방향과 거리만큼 발사한다.
        bool isHit = Physics.Raycast(ray, out hitInfo, 3, ~(1 << 7));
        print(hitInfo);
    }
}
