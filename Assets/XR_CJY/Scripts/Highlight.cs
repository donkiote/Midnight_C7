using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Transform highlight;  // 하이라이트 효과 오브젝트 지정
    public Transform paintUI;  // 그림의 UI 지정


    // 각 그림들의 버튼마다 고유한 오브젝트 및 UI를 지정한다.
    private void Start()
    {
        highlight = transform.GetChild(0);  // 해당 버튼의 첫번째 자식 오브젝트를 가져온다.
        paintUI = transform.GetChild(1);  // 해당 버튼의 두번째 자식 오브젝트를 가져온다.
    }
}
