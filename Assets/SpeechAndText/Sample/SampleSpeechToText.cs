using UnityEngine;
using UnityEngine.UI;
using TextSpeech;

public class SampleSpeechToText : MonoBehaviour
{


    public Text txtLocale;
    public Text result;
   // public Text result;
    void Start()
    {
        Setting("pl-PL");
        SpeechToText.instance.onResultCallback = OnResultSpeech;

    }
    

    public void StartRecording()
    {
#if UNITY_EDITOR
#else
        SpeechToText.instance.StartRecording("Podaj literę lub wyraz:");

#endif
    }

    public void StopRecording()
    {
#if UNITY_EDITOR
        OnResultSpeech("");
#else

        SpeechToText.instance.StopRecording();
#endif
#if UNITY_IOS
        loading.SetActive(true);
#endif
    }
    void OnResultSpeech(string _data)
    {
       
        txtLocale.text = _data;
        result.text = _data.ToLower();
#if UNITY_IOS
        loading.SetActive(false);
#endif
    }
    
    public void Setting(string code)
    {
        SpeechToText.instance.Setting(code);
      
    }
   
}
