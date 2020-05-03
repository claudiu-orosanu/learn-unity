using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EnemyEscapedHandler(EnemyController enemy);

public class EnemyController : Shape, IKillable
{
    public event EnemyEscapedHandler EnemyEscaped;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Name = "Enemy";
        // Debug.Log("Enemy spawned!");
    }

    // Update is called once per frame
    void Update()
    {
        // MoveEnemy(gameSceneController.OutputText);
        MoveEnemy(InternalOutputText);
        // a delegate is usually used as as callback function, pass a method reference to a method and when that method finishes it will invoke the callback
    }

    private void MoveEnemy(TextOutputHandler outputHandler)
    {
        transform.Translate(Vector2.down * Time.deltaTime, Space.World);

        float bottom = transform.position.y - halfHeight;

        if (bottom <= -gameSceneController.screenBounds.y)
        {
            // outputHandler("Enemy at bottom");
            // gameSceneController.KillObject(this);
            if (EnemyEscaped != null)
            {
                // event has subscribers
                EnemyEscaped(this);
            }
        }
    }

    private void InternalOutputText(string text)
    {
        Debug.Log($"{text} output by EnemyController");
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public string GetName()
    {
        return Name;
    }
}
