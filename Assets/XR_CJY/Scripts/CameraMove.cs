using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    FirstPersonController fpc;  // �÷��̾� ��Ʈ�ѷ� ������Ʈ ����
    Highlight hl;


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
        if (isHit)
        {
            // �浹�� ����� �̸��� " " �̶��
            if (hitInfo.transform.name == "Button")
            {
                hl = hitInfo.transform.GetComponent<Highlight>();
                hl.highlight.SetActive(true);
                hl.pressE.SetActive(true);

                // E ��ư�� ������
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // ���콺 Ŀ�� Ȱ��ȭ
                    Cursor.lockState = CursorLockMode.None;

                    // �ش� �׸��� UI�� ��µȴ�.
                    if (hl.paintUI != null)
                    {
                        hl.paintUI.SetActive(true);
                    }

                    // �÷��̾��� ������ ������Ʈ�� ��Ȱ��ȭ �Ѵ�.
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
