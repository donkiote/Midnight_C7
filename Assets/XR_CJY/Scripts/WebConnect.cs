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

    private string title = "����, �Ķ�, ����� ����";
    private string author = "��Ʈ ��帮��";

    private void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ�� �޼��带 ����
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
        // JSON ������ �����͸� �ۼ�
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
        request.downloadHandler = new DownloadHandlerBuffer();  // ���� �����͸� �ޱ� ���� �ٿ�ε� �ڵ鷯 ����

        // ������ Post�� �����ϰ� ������ �� ������ ��ٸ���.
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // �ٿ�ε� �ڵ鷯���� �ؽ�Ʈ ���� �޾Ƽ� UI�� ����Ѵ�.
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

    // btn_artist ��ư�� ������ �� �۰� �̸��� ����ϴ� �޼���
    private void ShowAuthor()
    {
        text_response.text = $"�۰�: {author}";
    }

    // btn_title ��ư�� ������ �� ��ǰ ������ ����ϴ� �޼���
    private void ShowTitle()
    {
        text_response.text = $"��ǰ ����: {title}";
    }
}
