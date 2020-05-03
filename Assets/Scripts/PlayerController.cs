using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Shape
{
    // Start is called before the first frame update
    void Start()
    {
        SetColor(Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // GetAxis is mapped to the arrow keys, Horizontal means left and right arrow keys (left will have negative value, right positive)
        float horizontalMovement = Input.GetAxis("Horizontal");
        // Debug.Log($"horizontalMovement = {horizontalMovement}");

        if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon) // comparing to Epsilon to account for floating point precision errors
        {
            // Debug.Log($"deltaTime = {Time.deltaTime}. transformPositionX = {transform.position.x}");
            horizontalMovement = horizontalMovement * Time.deltaTime;
            horizontalMovement += transform.position.x;

            Debug.Log($"transform.position = {transform.position}");
            transform.position = new Vector2(horizontalMovement, transform.position.y);
            // Debug.Log($"horizontalMovement = {horizontalMovement}. transform.position = {transform.position}");

        }
    }
}
