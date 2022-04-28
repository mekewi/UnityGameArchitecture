using System.Collections;
using System.Collections.Generic;
using EventsSystem.Scripts.Editor;
using ProjectArchitectureBase.BaseScriptsRuntime.Event;
using UnityEditor;
using UnityEngine;
namespace ProjectArchitectureBase.BaseScriptsRuntime.Editor
{
    [CustomEditor(typeof(IntEvent))]
    public class IntEventEditor : EventEditorBase<int,IntEvent>
    {
    }
}
