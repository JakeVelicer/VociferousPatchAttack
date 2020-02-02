using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MicInput : MonoBehaviour
{


    [Range(0.0f, 1.0f)]
    public float soundThreshold;

    public float testSound;
    public static float MicLoudness;
    private string _device;
    private AudioClip _clipRecord = null;
    private int _sampleWindow = 128;
    private bool _isInitialized;

    //public TextMeshProUGUI displayText;

    public Image bar;

    
    void Start()
    {
        StartCoroutine(UpdateAudioBar());
    }
    

    void InitMic()
    {
        if (_device == null) {
            _device = Microphone.devices [0];
            _clipRecord = Microphone.Start (_device, true, 999, 44100);
            Debug.Log (_clipRecord);
        }
    }

    void StopMicrophone()
    {
        Microphone.End (_device);
    }

    float LevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition (null) - (_sampleWindow + 1);
        if (micPosition < 0) {
            return 0;
        }
        _clipRecord.GetData (waveData, micPosition);
        for (int i = 0; i < _sampleWindow; ++i) {
        
             
            float wavePeak = waveData [i] * waveData [i];
           
            
            if (levelMax < wavePeak) {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }

    private float previousLevel = 0f;
    
    IEnumerator UpdateAudioBar()
    {
         while(true)
         {
             yield return new WaitForSeconds(0.02f);
             //bar.fillAmount = Mathf.Lerp(bar.fillAmount, (MicLoudness / 1f), 1);
             //UIManager.instance.UpdateSoundBar(Mathf.Lerp(bar.fillAmount))
         }
    }

    void Update()
    {
        MicLoudness = LevelMax ();
        testSound = MicLoudness;
        


        float db = 20f * Mathf.Log10(Mathf.Abs(MicInput.MicLoudness));


        //displayText.text = db.ToString();
        


        if (Mathf.Clamp((MicLoudness / 1f), 0f, 1f) > bar.fillAmount)
        {
            
        }
        else
        {
            //bar.fillAmount = Mathf.Lerp(bar.fillAmount, (MicLoudness / 1f), 0.125f* Time.deltaTime);
            bar.fillAmount = Mathf.Sqrt(MicLoudness) * 5f;

            Debug.Log(Mathf.Sqrt(MicLoudness) * 100f);
        }

        if (bar.fillAmount >= soundThreshold)
        {
            UIManager.instance.ActivateRepairMode();
        }
        else
        {
            UIManager.instance.DeactivateRepairMode();
        }

        //bar.fillAmount = Mathf.Lerp(0f, 1f, MicLoudness / 1);


        previousLevel = MicLoudness;
    }

    void OnEnable()
    {
        InitMic ();
        _isInitialized = true;
    }

    void OnDisable()
    {
        StopMicrophone ();
    }

    void OnDestory()
    {
        StopMicrophone ();
    }

    void OnApplicationFocus(bool focus)
    {
        if (focus) {
            if (!_isInitialized) {
                InitMic ();
                _isInitialized = true;
            }
        }

        if (!focus) {
            StopMicrophone ();
            _isInitialized = false;
        }
    }

}