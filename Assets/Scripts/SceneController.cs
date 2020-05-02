using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public List<Shape> gameShapes;
    public Dictionary<string, Shape> shapesDict;
    public Queue<Shape> shapeQueue;

    // Start is called before the first frame update
    void Start()
    {
        shapeQueue = new Queue<Shape>();
        shapesDict = new Dictionary<string, Shape>();
        foreach (var shape in gameShapes)
        {
            shapesDict.Add(shape.Name, shape);
        }

        shapeQueue.Enqueue(shapesDict["Triangle"]);
        shapeQueue.Enqueue(shapesDict["Square"]);
        shapeQueue.Enqueue(shapesDict["Octagon"]);
        shapeQueue.Enqueue(shapesDict["Circle"]);
    }

    private void SetRedByName(string shapeName)
    {
        shapesDict[shapeName].SetColor(Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (shapeQueue.Count > 0)
            {
                Shape shape = shapeQueue.Dequeue();
                shape.SetColor(Color.blue);
            } else {
                Debug.Log("The shape queue is empty");
            }
        }
    }

    private void FindExample()
    {
        Shape octagon = gameShapes.Find(s => s.Name == "Octagon");
        octagon.SetColor(Color.red);
    }

    private void DictionaryExample()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetRedByName("Square");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SetRedByName("Circle");
        }
    }

}
