using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Transform highlight;  // ���̶���Ʈ ȿ�� ������Ʈ ����
    public Transform paintUI;  // �׸��� UI ����


    // �� �׸����� ��ư���� ������ ������Ʈ �� UI�� �����Ѵ�.
    private void Start()
    {
        highlight = transform.GetChild(0);  // �ش� ��ư�� ù��° �ڽ� ������Ʈ�� �����´�.
        paintUI = transform.GetChild(1);  // �ش� ��ư�� �ι�° �ڽ� ������Ʈ�� �����´�.
    }
}
