using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Shape
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector2.down * Time.deltaTime, Space.World);

        float bottom = transform.position.y - halfHeight;

        if (bottom <= -gameSceneController.screenBounds.y)
        {
            Destroy(gameObject);
        }
    }
}
