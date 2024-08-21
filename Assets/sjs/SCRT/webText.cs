using System.Buffers.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ArtworkInfoDisplay : MonoBehaviour
{
    public Text artworkDescriptionText;
    public Button artworkInfoButton;

    public PaintArtManager paintArt;
    private void Start()
    {
        // 작품 정보 버튼 클릭 이벤트 리스너 추가
        artworkInfoButton.onClick.AddListener(FetchArtworkInfo);
    }

    private void FetchArtworkInfo()
    {
        audioSource.Stop();

        // 작품 ID (예: 1)
        int artworkId = 1;

        // API 엔드포인트 URL
        string url = $"http://192.168.1.50:7777/chatbot";

        ArtworkData data = new ArtworkData();

        if (paintArt.currIdx == 0)
        {
            data.title = "빨강 파랑 노랑의 구성";
            data.author = "피트 몬드리안";
        }
        else if (paintArt.currIdx == 1)
        {
            data.title = "모나리자";
            data.author = "레오나르도 다빈차";
        }
        else if (paintArt.currIdx == 2)
        {
            data.title = "진주 귀걸이를 한 소녀";
            data.author = "요하네스 베르메르";
        }
        else if (paintArt.currIdx == 3)
        {
            data.title = "파라솔을 든 여인";
            data.author = "모네";
        }
        
        print("통신 시작");
        StartCoroutine(GetArtworkDescription(url, data));
    }

    

    IEnumerator GetArtworkDescription(string url, ArtworkData data)
    {
        string jsonData = JsonUtility.ToJson(data);
        
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, jsonData, "application/json"))
        {
            // 웹 요청 보내기
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                // 응답 데이터 가져오기
                string responseData = webRequest.downloadHandler.text;
                print(responseData);
                ExplainAudio explainAudio = JsonUtility.FromJson<ExplainAudio>(responseData);
                
                byte[] bytes = System.Convert.FromBase64String(explainAudio.explain_audio);
                File.WriteAllBytes(Application.dataPath + "/explain.mp3", bytes);
            }
            else
            {
                // 에러 처리
                Debug.LogError("Failed to fetch artwork description: " + webRequest.error);
            }
        }
    }

    public AudioSource audioSource;
    public void OnClickVoice()
    {
        StartCoroutine(PlayVoice());
    }

    IEnumerator PlayVoice()
    {
        string uri = "file:///" + Application.dataPath + "/explain.mp3";
        using (UnityWebRequest webRequest = UnityWebRequestMultimedia.GetAudioClip(uri, AudioType.MPEG))
        {
            // 웹 요청 보내기
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                DownloadHandlerAudioClip result = webRequest.downloadHandler as DownloadHandlerAudioClip;
                audioSource.clip = result.audioClip;
                audioSource.Play();
            }
            else
            {
                // 에러 처리
                Debug.LogError("Failed to fetch artwork description: " + webRequest.error);
            }
        }
    }

    // API 데이터 모델 클래스
    [System.Serializable]
    public class ArtworkData
    {
        public string title;
        public string author;

        //public string description;
        // 기타 작품 정보 속성
    }

    [System.Serializable]
    public class ExplainAudio
    {
        public string explain;
        public string explain_audio;
    }
}