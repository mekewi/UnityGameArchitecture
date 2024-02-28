using EventsSystem.Scripts.Editor;
using ProjectArchitectureBase.Event;
using UnityEditor;
namespace ProjectArchitectureBase.Editor
{
    [CustomEditor(typeof(BoolEvent))]
    public class BoolEventEditor : EventEditorBase<bool,BoolEvent>
    {
    }
}
