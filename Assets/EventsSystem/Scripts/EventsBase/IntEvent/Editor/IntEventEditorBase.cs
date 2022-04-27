using System.Collections;
using System.Collections.Generic;
using EventsSystem.Scripts.Editor;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(IntEvent))]

public class IntEventEditorBase : EventEditorBase<int,IntEvent>
{
}
