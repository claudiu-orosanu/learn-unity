using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    private Vector3 _startingPosition;

    [SerializeField]
    private Vector3 movementVector;

    [SerializeField] [Range(0,1)]
    private float movementFactor = 0;

    private bool _isMovingForward = true;

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = movementVector * movementFactor;
        transform.position = _startingPosition + offset;

        if (movementFactor >= 1)
        {
            _isMovingForward = false;
        } else if (movementFactor <= 0)
        {
            _isMovingForward = true;
        }

        float addition = 0.5f * Time.deltaTime;
        movementFactor += _isMovingForward ? addition : -addition;
    }
}
