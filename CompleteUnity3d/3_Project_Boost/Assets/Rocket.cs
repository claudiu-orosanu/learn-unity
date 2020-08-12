using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float mainThrust = 1000f;
    [SerializeField] private float rcsThrust = 100f;

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
            _rigidbody.AddRelativeForce(Vector3.up * (Time.deltaTime * mainThrust));
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
        // take manual control of rotation
        _rigidbody.freezeRotation = true;

        // calculate rotation in this frame
        float rotationThisFrame = Time.deltaTime * rcsThrust;
        
        if (Input.GetKey(KeyCode.A))
        {
            // print("Rotating left");
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // print("Rotating right");
            transform.Rotate(Vector3.back * rotationThisFrame);
        }

        // resume physics control of rotation
        _rigidbody.freezeRotation = false;
    }
}