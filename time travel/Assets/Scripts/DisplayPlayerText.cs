using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TextSpeech;

public class DisplayPlayerText : MonoBehaviour
{
    public Button yourButton; 
    public TextMeshProUGUI UIElement;
    private TextToSpeech textToSpeech;
    private void Awake()
    {
        textToSpeech = TextSpeech.TextToSpeech.Instance;

        // �������Ժ�������������Ǽ�����ʹ�õ���Ӣ��
        textToSpeech.Setting("en-US", 1f, 1f);
    }

    private void Start()
    {
        UIElement.gameObject.SetActive(false);

    
        yourButton.onClick.AddListener(HandleButtonClick);


        SpeechToText.Instance.onResultCallback += HandleSpeechResult;
    }

    private void HandleButtonClick()
    {

        textToSpeech.StopSpeak();
        SpeechToText.Instance.StartRecording();
        UIElement.gameObject.SetActive(true);
        
    }

    private void HandleSpeechResult(string result)
    {

        UIElement.text = "Hello, " + result + ", welcome to the new world";

        textToSpeech.StopSpeak();
        textToSpeech.StartSpeak(UIElement.text);
        UIElement.gameObject.SetActive(true);
    }
}
