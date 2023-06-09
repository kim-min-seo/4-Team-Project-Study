using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관련 라이브러리

public class NewBehaviourScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("SampleScene"); // SampleScene 씬으로 이동
        }
        
    }
}
