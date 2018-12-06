using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : BirdMove
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseDown()
    {
        DrawLineAndBirdOnTheFoxer();
    }
    private void OnMouseUp()
    {
        Shot();
    }
    // Update is called once per frame
    void Update()
    {
        EveryFrame();
    }
}
