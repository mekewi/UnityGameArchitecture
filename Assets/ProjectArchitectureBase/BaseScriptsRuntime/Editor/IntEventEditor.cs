using System.Collections;
using System.Collections.Generic;
using EventsSystem.Scripts.Editor;
using ProjectArchitectureBase.Event;
using UnityEditor;
using UnityEngine;
namespace ProjectArchitectureBase.Editor
{
    [CustomEditor(typeof(IntEvent))]
    public class IntEventEditor : EventEditorBase<int,IntEvent>
    {
    }
}
