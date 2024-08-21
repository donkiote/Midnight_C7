using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEditor;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public GameObject img_Menu;
    bool isOn = false;

    void Update()
    {
        if (!isOn)
        {
            // Esc 키를 누를 시 게임 메뉴 화면 활성화
            if (Input.GetButtonDown("Cancel"))
            {
                isOn = true;
                Cursor.lockState = CursorLockMode.None;
                img_Menu.SetActive(true);
            }
        }
        else
        {
            if (Input.GetButtonDown("Cancel"))
            {
                isOn = false;
                Cursor.lockState = CursorLockMode.Locked;
                img_Menu.SetActive(false);
            }
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        // 1. 에디터일 경우 플레이 모드 끄기
        EditorApplication.ExitPlaymode();
#elif UNITY_STANDALONE
        // 2. 빌드한 어플리케이션일 경우 앱 종료
        Application.Quit();
#endif
    }
}
