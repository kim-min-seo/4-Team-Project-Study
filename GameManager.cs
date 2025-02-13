using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI 관련 라이브러리
using UnityEngine.SceneManagement;//씬 관리 관련 라이브러리
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;//게임오버 시 활성화할 텍스트 게임 오브젝트
    public TMP_Text timeText;//생존 시간을 표시할 텍스트 컴포넌트
    public TMP_Text recordText; //최고 기록을 표시할 텍스트 컴포넌트
    public TMP_Text recordedText; //최고 기록을 표시할 텍스트 컴포넌트
    public GameObject gameoveredText;
    public TMP_Text BestTime1;
    public TMP_Text BestTime2;
    public TMP_Text BestTime3;

    private float surviveTime;//생존 시간
    private bool isGameover;//게임오버 상태
    // Start is called before the first frame update
    void Start()
    {//생존 시간과 게임오버 상태 초기화
        surviveTime = 0;
        isGameover = false;
        
    }

    // Update is called once per frame
    void Update()
    {//게임오버가 아닌 동안
        
        if (!isGameover)
        {//생존 시간 갱신
            surviveTime += Time.deltaTime;
            //갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = "Time: " + (int)surviveTime;

        }
        else
        {
            //게임오버 상태에서 R키를 누른 경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene 씬을 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
        
    }
    //현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {//현재 상태를 게임오버 상태로 전환
        isGameover = true;
        //게임오버 텍스트 게임 오브젝트를 활성화
        if (surviveTime > 15)
        {
            gameoveredText.SetActive(true);
            
        }
        else { gameoverText.SetActive(true);
           
        }
        //BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // BestTime 키로 저장된 이전까지의 1,2,3등 기록 가져오기
        float bestTime1 = PlayerPrefs.GetFloat("BestTime1"); // 1등
        float bestTime2 = PlayerPrefs.GetFloat("BestTime2");
        float bestTime3 = PlayerPrefs.GetFloat("BestTime3");

        //이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime)
        {
            //최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            //변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // 이전까지의 1등 기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime1)
        {
            bestTime3 = bestTime2;
            bestTime2 = bestTime1;
            bestTime1 = surviveTime;

            PlayerPrefs.SetFloat("BestTime3", bestTime3);
            PlayerPrefs.SetFloat("BestTime2", bestTime2);
            PlayerPrefs.SetFloat("BestTime1", bestTime1);
        }
        // 이전까지의 2등 기록보다 현재 생존 시간이 더 크다면
        else if (surviveTime > bestTime2)
        {
            bestTime3 = bestTime2;
            bestTime2 = surviveTime;

            PlayerPrefs.SetFloat("BestTime3", bestTime3);
            PlayerPrefs.SetFloat("BestTime2", bestTime2);
        }
        // 이전까지의 3등 기록보다 현재 생존 시간이 더 크다면
        else if (surviveTime > bestTime3)
        {
            bestTime3 = surviveTime;

            PlayerPrefs.SetFloat("BestTime3", bestTime3);
        }

        // 1,2,3등 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        BestTime1.text = "Best Time1: " + (int)bestTime1;
        BestTime2.text = "Best Time2: " + (int)bestTime2;
        BestTime3.text = "Best Time3: " + (int)bestTime3;

        //최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        if (surviveTime > 15) { recordedText.text = "Best Time: " + (int)bestTime; }
        else { recordText.text = "Best Time: " + (int)bestTime; }
    }
}
