using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageZoomOut : MonoBehaviour, IScrollHandler
{
    public Image image;
    public float maxScale = 2f;
    public float minScale = 0.5f;
    public float scaleStep = 0.1f;

    private float currentScale = 1f;

    private void Awake()
    {
        // 이미지 컴포넌트 가져오기
        image = GetComponent<Image>();
    }

    public void OnScroll(PointerEventData eventData)
    {
        // 마우스 휠 스크롤 방향에 따라 크기 조절
        if (image != null)
        {
            if (eventData.scrollDelta.y > 0)
            {
                ZoomIn();
            }
            else if (eventData.scrollDelta.y < 0)
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        // 현재 크기를 증가시키기
        currentScale += scaleStep;

        // 최대 크기보다 크지 않도록 제한
        currentScale = Mathf.Min(maxScale, currentScale);

        // 이미지 크기 적용
        image.rectTransform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }

    private void ZoomOut()
    {
        // 현재 크기를 감소시키기
        currentScale -= scaleStep;

        // 최소 크기보다 작아지지 않도록 제한
        currentScale = Mathf.Max(minScale, currentScale);

        // 이미지 크기 적용
        image.rectTransform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }

    public void Reset()
    {
        // 이미지 컴포넌트가 존재하는 경우에만 실행
        if (image != null)
        {
            // 이미지 크기를 초기 크기로 설정
            currentScale = 1f;
            image.rectTransform.localScale = new Vector3(currentScale, currentScale, currentScale);
        }
    }
}