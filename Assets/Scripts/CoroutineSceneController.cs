using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSceneController : MonoBehaviour
{
    public List<Shape> gameShapes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // SetShapesRed();
            StartCoroutine(SetShapesBlue());
            Time.timeScale = 0; // pauses the game
        }
    }

    private IEnumerator SetShapesBlue()
    {
        foreach (var shape in gameShapes)
        {
            shape.SetColor(Color.blue);
            yield return new WaitForSecondsRealtime(2);
            shape.SetColor(Color.white);
        }

        yield return new WaitForSecondsRealtime(1);
        Debug.Log("I just wasted a realtime second");
    }

    private void SetShapesRed()
    {
        foreach (var shape in gameShapes)
        {
            shape.SetColor(Color.red);
        }
    }
}
