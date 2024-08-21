using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEditor.PackageManager;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject pressE;  // "Press (E)" UI 지정

    FirstPersonController fpc;  // 플레이어 컨트롤러 컴포넌트 지정
    Highlight hl;  // 각 그림들의 고유한 UI를 저장한 컴포넌트 지정 
    

    void Start()
    {
        fpc = GetComponent<FirstPersonController>();  // FirstPersonControlloer 컴포넌트를 가져온다.
    }

    void Update()
    {
        // 레이 생성
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;  // 레이가 충돌한 대상을 지정

        // 만들어진 레이를 지정된 방향과 거리만큼 발사
        bool isHit = Physics.Raycast(ray, out hitInfo, 10, ~(1 << 7));

        // 레이가 해당 그림의 버튼과 층돌했을때
        if (isHit)
        {
            PaintUI(hitInfo);
        }
    }

    // 충돌한 버튼 마다 각자 고유한 UI가 출력되게 하는 함수
    public void PaintUI(RaycastHit hit)
    {
        // 충돌한 대상의 이름이 "Button"을 포함 하고있다면
        if (hit.transform.name.Contains("Button"))
        {
            hl = hit.transform.GetComponent<Highlight>();  // 충돌한 대상의 Highlight컴포넌트를 가져온다.
            hl.highlight.gameObject.SetActive(true);  // 하이라이트 효과 오브젝트를 활성화한다.
            pressE.SetActive(true);  // "Press (E)" UI를 활성화한다.

            // E 버튼을 누르면
            if (Input.GetKeyDown(KeyCode.E))
            {
                // 마우스 커서 활성화
                Cursor.lockState = CursorLockMode.None;

                // 해당 그림의 UI가 출력된다.
                if (hl.paintUI != null)
                {
                    hl.paintUI.gameObject.SetActive(true);
                }

                // 플레이어의 움직임 컴포넌트를 비활성화 한다.
                fpc.enabled = false;
            }
        }
        // 그렇지 않다면
        else if (hl != null)
        {
            hl.highlight.gameObject.SetActive(false);  // 하이라이트 효과 오브젝트를 비활성화한다.
            pressE.SetActive(false);  // "Press (E)" UI를 비활성화한다.
        }
    }

    // UI의 나가기 버튼
    public void ExitButton()
    {
        hl.paintUI.gameObject.SetActive(false);  // 해당 그림의 UI를 비활성화한다.
        Cursor.lockState = CursorLockMode.Locked;  // 마우스 커서를 다시 비활성화한다.
        fpc.enabled = true;  // 플레이어의 움직임 컴포넌트를 다시 활성화한다.
    }

}
