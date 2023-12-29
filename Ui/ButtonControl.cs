using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject uicontrol;
    public GameObject canvasObject;
    public Slider volumeSlider;
    public AudioSource AudioSource;
    public Button ExitBtn;
    public Button ResumeBtn;
    public Button SaveBtn;
    public Button StartBtn;

    void Start()
    {
        //오브젝트 찾기
        uicontrol = GameObject.Find("UiControl");
        canvasObject = GameObject.Find("UI");
        
        //오브젝트 트랜스폼
        Transform canvasTransform = canvasObject.transform;
        Transform MenuSetTransform = canvasTransform.Find("MenuSet");

        //버튼트랜스폼
        Transform ExitBtnTransform = MenuSetTransform.Find("ExitBtn");
        Transform ResumeBtnTransform = MenuSetTransform.Find("ResumeBtn");
        Transform volumeSliderTransform = MenuSetTransform.Find("SoundSlider");

        //버튼
        ExitBtn = ExitBtnTransform.GetComponent<Button>();
        ResumeBtn = ResumeBtnTransform.GetComponent<Button>();
        volumeSlider = volumeSliderTransform.GetComponent<Slider>();

        //볼륨 컨트롤
        // volumeSlider.value = AudioSource.volume;
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        //버튼 역할
        ResumeBtn.onClick.AddListener(Resume);
        ExitBtn.onClick.AddListener(GameExit);
        //SaveBtn.onClick.AddListener(GameSave);

    }

    void Update()
    {
    
    }
    
    //게임 종료
    public void GameExit()
    {
        print("exit");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    public void GameSave()
    {
        //게임 저장 함수 내용
    }

    public void Resume()
    {   
        uicontrol.GetComponent<UiControl>().SubMenuControl();
    }

    public void OnVolumeChanged(float volumeValue)
    {
        // 슬라이더의 값을 오디오 소스의 볼륨 값으로 설정
        // audioSource.volume = volumeSlider.value;
    }
}
