using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float acceleration = 1000f;

    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    //     void Awake () {
//        // set frame rate to check Time.deltaTime works
// #if UNITY_EDITOR
//         QualitySettings.vSyncCount = 0;  // VSync must be disabled
//         Application.targetFrameRate = 60;
// #endif
//     }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        Thrust();
        Rotate();
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // print("Thrusting!");
            _rigidbody.AddRelativeForce(Vector3.up * (Time.deltaTime * acceleration));
            // _rigidbody.AddRelativeTorque(Vector3.up * (Time.deltaTime * acceleration));

            _audioSource.UnPause();
        }
        else
        {
            _audioSource.Pause();
        }
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // print("Rotating left");
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("Rotating right");
            transform.Rotate(Vector3.back);
        }
    }
}