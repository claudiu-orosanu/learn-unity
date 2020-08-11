using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float acceleration = 1000f;

    private Rigidbody _rigidbody;

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
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            // print("Thrusting!");
            _rigidbody.AddRelativeForce(Vector3.up * (Time.deltaTime * acceleration));
            // _rigidbody.AddRelativeTorque(Vector3.up * (Time.deltaTime * acceleration));

        }

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