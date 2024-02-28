using EventsSystem.Scripts.Editor;
using ProjectArchitectureBase.Event;
using UnityEditor;
namespace ProjectArchitectureBase.Editor
{
    [CustomEditor(typeof(FloatEvent))]
    public class FloatEventEditor : EventEditorBase<float,FloatEvent>
    {
    }
}
