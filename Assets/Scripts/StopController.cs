using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when adding this component to a scene object, the spriteRenderer component will be also added
// and it cannot be removed because the StopController depends on it
[RequireComponent(typeof(SpriteRenderer))]
public class StopController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
