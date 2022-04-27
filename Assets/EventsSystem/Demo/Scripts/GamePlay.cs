using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public VoidEvent onLevelWin;
    public StringEvent Fire;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onLevelWin.Raise();
            Fire.Raise("You Fail");
        }
    }
}
