using System.Collections;
using System.Collections.Generic;
using EventsSystem.Scripts.Editor;
using ProjectArchitectureBase.Event;
using UnityEditor;
using UnityEngine;
namespace ProjectArchitectureBase.Editor
{
    [CustomEditor(typeof(Vector2Event))]
    public class Vector2EventEditor : EventEditorBase<Vector2,Vector2Event>
    {
    }
}
