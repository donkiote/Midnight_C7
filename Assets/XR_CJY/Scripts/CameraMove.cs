using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    FirstPersonController fpc;  // 플레이어 컨트롤러 컴포넌트 지정
    Highlight hl;


    void Start()
    {
        fpc = GetComponent<FirstPersonController>();  // FirstPersonControlloer 컴포넌트를 가져온다.
    }

    void Update()
    {
        // 레이 생성
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // 레이가 충돌한 대상의 정보를 담기 위한 구조체를 생성
        RaycastHit hitInfo;

        // 만들어진 레이를 지정된 방향과 거리만큼 발사
        bool isHit = Physics.Raycast(ray, out hitInfo, 10, ~(1 << 7));

        // 레이가 해당 그림의 버튼과 층돌했을때
        if (isHit)
        {
            // 충돌한 대상의 이름이 " " 이라면
            if (hitInfo.transform.name == "Button")
            {
                hl = hitInfo.transform.GetComponent<Highlight>();
                hl.highlight.SetActive(true);
                hl.pressE.SetActive(true);

                // E 버튼을 누르면
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // 마우스 커서 활성화
                    Cursor.lockState = CursorLockMode.None;

                    // 해당 그림의 UI가 출력된다.
                    if (hl.paintUI != null)
                    {
                        hl.paintUI.SetActive(true);
                    }

                    // 플레이어의 움직임 컴포넌트를 비활성화 한다.
                    fpc.enabled = false;
                }
            }
            else if (hl != null)
            {
                hl.highlight.SetActive(false);
                hl.pressE.SetActive(false);
            }
        }
    }
}
