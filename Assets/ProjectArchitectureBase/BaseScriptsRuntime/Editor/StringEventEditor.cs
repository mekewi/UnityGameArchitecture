using System.Collections;
using System.Collections.Generic;
using EventsSystem.Scripts.Editor;
using ProjectArchitectureBase.Event;
using UnityEditor;
using UnityEngine;
namespace ProjectArchitectureBase.Editor
{
    [CustomEditor(typeof(StringEvent))]
    public class StringEventEditor : EventEditorBase<string,StringEvent>
    {
    }
}
