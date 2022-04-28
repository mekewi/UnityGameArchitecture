using System;
using System.Collections;
using System.Collections.Generic;
using ProjectArchitectureBase.BaseScriptsRuntime.Event;
using UnityEngine;
using Variables.Scripts.VariableBase.Variables;

public class GamePlay : MonoBehaviour
{
    public VoidEvent onLevelWin;
    public StringEvent Fire;
    public IntVariable health;
    private void Start()
    {
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onLevelWin.Raise();
            Fire.Raise("You Fail");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.Value = 4;
        }
    }

    public void OnLevelWin()
    {
        Debug.Log("LevelWin");
    }
}
