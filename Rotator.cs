using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;
    private float timer = 5f; // 5초 후 회전
    private bool rotationStarted = false;

    void Updat()
    {
        transform.Rotate(0f, rotationSpeed* Time.deltaTime, 0f);
    }
}
