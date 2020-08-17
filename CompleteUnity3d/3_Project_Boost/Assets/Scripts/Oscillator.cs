using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    private Vector3 _startingPosition;

    [SerializeField]
    private Vector3 movementVector;

    [SerializeField]
    private float period = 2f;

    private float _movementFactor;

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        const float tau = 2f * Mathf.PI;

        float cycles = Time.time / period;
        // if period is 1 then after 1 second, cycles = 1
        // and Sin(6.28) = 0 (object reaches starting point again)
        float rawSinWave = Mathf.Sin(cycles * tau);

        _movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementVector * _movementFactor;
        transform.position = _startingPosition + offset;
    }
}
