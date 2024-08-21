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
            // Esc Ű�� ���� �� ���� �޴� ȭ�� Ȱ��ȭ
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
        // 1. �������� ��� �÷��� ��� ����
        EditorApplication.ExitPlaymode();
#elif UNITY_STANDALONE
        // 2. ������ ���ø����̼��� ��� �� ����
        Application.Quit();
#endif
    }
}
