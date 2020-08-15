using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float mainThrust = 1000f;
    [SerializeField] private float rcsThrust = 100f;

    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    private enum GameState
    {
        Alive,
        Transcending,
        Dead
    };

    private GameState _gameState = GameState.Alive;

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
        if (_gameState == GameState.Alive)
        {
            ProcessThrustInput();
            ProcessRotateInput();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_gameState != GameState.Alive)
        {
            return;
        }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                // do nothing
                Debug.Log("Ok");
                break;
            case "Finish":
                Debug.Log("Won level!");
                _gameState = GameState.Transcending;
                Invoke("LoadNextLevel", 1f);
                break;
            default:
                Debug.Log("Dead");
                _gameState = GameState.Dead;
                Invoke("LoadFirstLevel", 2f);
                break;
        }
    }

    private void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("Won game!! Congratulations!");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
        _gameState = GameState.Alive;
    }

    private void ProcessThrustInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ApplyThrust();

            _audioSource.UnPause();
        }
        else
        {
            _audioSource.Pause();
        }
    }

    private void ApplyThrust()
    {
        _rigidbody.AddRelativeForce(Vector3.up * (Time.deltaTime * mainThrust));
        // _rigidbody.AddRelativeTorque(Vector3.up * (Time.deltaTime * acceleration));
    }

    private void ProcessRotateInput()
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