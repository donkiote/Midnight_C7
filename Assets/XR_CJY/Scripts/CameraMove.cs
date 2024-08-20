using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject buttonObj;  // �ν��� ��ư ������Ʈ�� ����
    public GameObject paintUI;  // Ȱ��ȭ ��ų UI ����

    FirstPersonController fpc;  // �÷��̾� ��Ʈ�ѷ� ������Ʈ ����


    void Start()
    {
        fpc = GetComponent<FirstPersonController>();  // FirstPersonControlloer ������Ʈ�� �����´�.
    }

    void Update()
    {
        // ���� ����
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // ���̰� �浹�� ����� ������ ��� ���� ����ü�� ����
        RaycastHit hitInfo;

        // ������� ���̸� ������ ����� �Ÿ���ŭ �߻�
        bool isHit = Physics.Raycast(ray, out hitInfo, 10, ~(1 << 7));

        // ���̰� �ش� �׸��� ��ư�� ����������
        if (isHit == buttonObj)
        {
            // E ��ư�� ������
            if (Input.GetKeyDown(KeyCode.E))
            {
                // ���콺 Ŀ�� Ȱ��ȭ
                Cursor.lockState = CursorLockMode.None;

                // �׸��� UI�� ��µȴ�.
                if (paintUI != null)
                {
                    paintUI.SetActive(true);
                }

                // �÷��̾��� ������ ������Ʈ�� ��Ȱ��ȭ �Ѵ�.
                fpc.enabled = false;
            }
        }
    }
}
