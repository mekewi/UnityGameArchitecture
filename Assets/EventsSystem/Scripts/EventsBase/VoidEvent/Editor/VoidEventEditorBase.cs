using System.Collections;
using System.Collections.Generic;
using EventsSystem.Scripts.Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(VoidEvent))]
public class VoidEventEditorBase : EventEditorBase<Void,VoidEvent>
{
}
