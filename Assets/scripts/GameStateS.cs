using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateS : MonoBehaviour
{
    public bool GameIsStart = false;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameIsStart = true;
        }
    }
}
