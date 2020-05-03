using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSceneController : MonoBehaviour
{
    public List<Shape> gameShapes;

    private Coroutine countToNumberCoroutine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            countToNumberCoroutine = StartCoroutine(CountToNumber(25000));
            StartCoroutine(SetShapesBlue());
            // Time.timeScale = 0; // pauses the game
            Debug.Log("Keypress complete.");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // StopAllCoroutines();
            StopCoroutine(countToNumberCoroutine);
        }
    }

    private IEnumerator CountToNumber(int numberToCountTo)
    {
        // running this as a normal method will hang the program when pressing Space
        // running as a coroutine will run it in parallel with the rest of the game
        for (int i = 0; i < numberToCountTo; i++)
        {
            Debug.Log(i);
            yield return null;
        }
    }

    private IEnumerator SetShapesBlue()
    {
        Debug.Log("Start changing colors");

        foreach (var shape in gameShapes)
        {
            shape.SetColor(Color.blue);
            yield return new WaitForSecondsRealtime(2);
            shape.SetColor(Color.white);
        }

        yield return new WaitForSecondsRealtime(1);
        Debug.Log("I just wasted a realtime second");

        yield return SetShapesBlue();
    }

    private void SetShapesRed()
    {
        foreach (var shape in gameShapes)
        {
            shape.SetColor(Color.red);
        }
    }
}
