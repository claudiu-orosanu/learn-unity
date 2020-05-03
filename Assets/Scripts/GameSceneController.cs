using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TextOutputHandler(string text);

public class GameSceneController : MonoBehaviour
{
    public float playerSpeed;
    public Vector3 screenBounds;
    public EnemyController enemyPrefab;

    private int _totalScore;
    private HUDController _hudController;
    private PlayerController _player;

    // Start is called before the first frame update
    void Start()
    {
        _hudController = FindObjectOfType<HUDController>();
        _player = FindObjectOfType<PlayerController>();
        playerSpeed = 10;
        screenBounds = GetScreenBounds();
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.SetColor(Color.red);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _player.SetColor(Color.yellow);
        }
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(2);

        while (true)
        {
            float horizontalPosition = Random.Range(-screenBounds.x, screenBounds.x);
            Vector2 spawnPosition = new Vector2(horizontalPosition, screenBounds.y);

            EnemyController enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.EnemyEscaped += EnemyEscapedHandler;
            enemy.EnemyKilled += EnemyKilledHandler;

            yield return wait;
        }
    }

    private void EnemyKilledHandler(int pointValue)
    {
        _totalScore += pointValue;
        _hudController.scoreText.text = _totalScore.ToString();
    }

    private Vector3 GetScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);

        return mainCamera.ScreenToWorldPoint(screenVector); 
    }

    public void KillObject(IKillable killable)
    {
        // Debug.LogWarning($"{killable.GetName()} was killed by gameSceneController");
        killable.Kill();
    }

    private void EnemyEscapedHandler(EnemyController enemyController)
    {
        Destroy(enemyController.gameObject);
        Debug.Log("Enemy escaped!");
    }

    public void OutputText(string text)
    {
        Debug.Log($"{text} output by GameSceneController");
    }
}
