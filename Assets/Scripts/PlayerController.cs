using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Shape
{
    private ProjectileController projectilePrefab;
    private GameSceneController gameSceneController;

    // Start is called before the first frame update
    void Start()
    {
        gameSceneController = FindObjectOfType<GameSceneController>();
        SetColor(Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    private void MovePlayer()
    {
        // GetAxis is mapped to the arrow keys, Horizontal means left and right arrow keys (left will have negative value, right positive)
        float horizontalMovement = Input.GetAxis("Horizontal");
        // Debug.Log($"horizontalMovement = {horizontalMovement}");

        if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon) // comparing to Epsilon to account for floating point precision errors
        {
            // Debug.Log($"deltaTime = {Time.deltaTime}. transformPositionX = {transform.position.x}");
            horizontalMovement = horizontalMovement * Time.deltaTime * gameSceneController.playerSpeed;
            // obs: player speed can be change while playing from Unity inspector because it's public on GameSceneController

            horizontalMovement += transform.position.x;

            Debug.Log($"transform.position = {transform.position}");
            transform.position = new Vector2(horizontalMovement, transform.position.y);
            // Debug.Log($"horizontalMovement = {horizontalMovement}. transform.position = {transform.position}");

        }
    }

    private void FireProjectile()
    {
        Vector2 spawnPosition = transform.position;

        // creates an instance of the object based on a prefab
        ProjectileController projectileController =
            Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        projectileController.projectileSpeed = 2;
        projectileController.projectileDirection = Vector2.up;
    }
}
