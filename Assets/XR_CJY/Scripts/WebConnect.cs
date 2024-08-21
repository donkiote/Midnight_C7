using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using Newtonsoft.Json;
using TMPro;


[System.Serializable]
public class WebConnect : MonoBehaviour
{
    public string url;
    public TextMeshProUGUI text_response;
    public Button btn_artist;
    public Button btn_title;
    public Button btn_enter;
    public TMP_InputField question;

    private string title = "빨강, 파랑, 노랑의 구성";
    private string author = "피트 몬드리안";

    private void Start()
    {
        // 버튼 클릭 이벤트와 메서드를 연결
        btn_enter.onClick.AddListener(PostJson);
        btn_artist.onClick.AddListener(ShowAuthor);
        btn_title.onClick.AddListener(ShowTitle);
    }

    public void PostJson()
    {
        StartCoroutine(PostJsonRequest(url));
    }

    IEnumerator PostJsonRequest(string url)
    {
        // JSON 형식의 데이터를 작성
        var jsonObject = new
        {
            title = title,
            author = author,
            chat = string.IsNullOrEmpty(question.text) ? null : question.text
        };

        string jsonData = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.SetRequestHeader("Content-Type", "application/json");

        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();  // 응답 데이터를 받기 위한 다운로드 핸들러 설정

        // 서버에 Post를 전송하고 응답이 올 때까지 기다린다.
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // 다운로드 핸들러에서 텍스트 값을 받아서 UI에 출력한다.
            string response = request.downloadHandler.text;
            text_response.text = response;
            Debug.LogWarning(response);
        }
        else
        {
            text_response.text = request.error;
            Debug.LogError(request.error);
        }
    }

    // btn_artist 버튼을 눌렀을 때 작가 이름을 출력하는 메서드
    private void ShowAuthor()
    {
        text_response.text = $"작가: {author}";
    }

    // btn_title 버튼을 눌렀을 때 작품 제목을 출력하는 메서드
    private void ShowTitle()
    {
        text_response.text = $"작품 제목: {title}";
    }
}
