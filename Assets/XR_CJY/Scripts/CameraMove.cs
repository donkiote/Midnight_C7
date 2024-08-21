using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEditor.PackageManager;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject pressE;  // "Press (E)" UI ����

    FirstPersonController fpc;  // �÷��̾� ��Ʈ�ѷ� ������Ʈ ����
    Highlight hl;  // �� �׸����� ������ UI�� ������ ������Ʈ ���� 
    

    void Start()
    {
        fpc = GetComponent<FirstPersonController>();  // FirstPersonControlloer ������Ʈ�� �����´�.
    }

    void Update()
    {
        // ���� ����
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;  // ���̰� �浹�� ����� ����

        // ������� ���̸� ������ ����� �Ÿ���ŭ �߻�
        bool isHit = Physics.Raycast(ray, out hitInfo, 10, ~(1 << 7));

        // ���̰� �ش� �׸��� ��ư�� ����������
        if (isHit)
        {
            PaintUI(hitInfo);
        }
    }

    // �浹�� ��ư ���� ���� ������ UI�� ��µǰ� �ϴ� �Լ�
    public void PaintUI(RaycastHit hit)
    {
        // �浹�� ����� �̸��� "Button"�� ���� �ϰ��ִٸ�
        if (hit.transform.name.Contains("Button"))
        {
            hl = hit.transform.GetComponent<Highlight>();  // �浹�� ����� Highlight������Ʈ�� �����´�.
            hl.highlight.gameObject.SetActive(true);  // ���̶���Ʈ ȿ�� ������Ʈ�� Ȱ��ȭ�Ѵ�.
            pressE.SetActive(true);  // "Press (E)" UI�� Ȱ��ȭ�Ѵ�.

            // E ��ư�� ������
            if (Input.GetKeyDown(KeyCode.E))
            {
                // ���콺 Ŀ�� Ȱ��ȭ
                Cursor.lockState = CursorLockMode.None;

                // �ش� �׸��� UI�� ��µȴ�.
                if (hl.paintUI != null)
                {
                    hl.paintUI.gameObject.SetActive(true);
                }

                // �÷��̾��� ������ ������Ʈ�� ��Ȱ��ȭ �Ѵ�.
                fpc.enabled = false;
            }
        }
        // �׷��� �ʴٸ�
        else if (hl != null)
        {
            hl.highlight.gameObject.SetActive(false);  // ���̶���Ʈ ȿ�� ������Ʈ�� ��Ȱ��ȭ�Ѵ�.
            pressE.SetActive(false);  // "Press (E)" UI�� ��Ȱ��ȭ�Ѵ�.
        }
    }

    // UI�� ������ ��ư
    public void ExitButton()
    {
        hl.paintUI.gameObject.SetActive(false);  // �ش� �׸��� UI�� ��Ȱ��ȭ�Ѵ�.
        Cursor.lockState = CursorLockMode.Locked;  // ���콺 Ŀ���� �ٽ� ��Ȱ��ȭ�Ѵ�.
        fpc.enabled = true;  // �÷��̾��� ������ ������Ʈ�� �ٽ� Ȱ��ȭ�Ѵ�.
    }

}
