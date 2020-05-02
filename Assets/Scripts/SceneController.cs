using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public List<Shape> gameShapes;
    public Dictionary<string, Shape> shapesDict;

    // Start is called before the first frame update
    void Start()
    {
        shapesDict = new Dictionary<string, Shape>();
        foreach (var shape in gameShapes)
        {
            shapesDict.Add(shape.Name, shape);
        }
    }

    private void SetRedByName(string shapeName)
    {
        shapesDict[shapeName].SetColor(Color.red);
    }

    private void FindExample()
    {
        Shape octagon = gameShapes.Find(s => s.Name == "Octagon");
        octagon.SetColor(Color.red);
    }

    // Update is called once per frame
    void Update()
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
