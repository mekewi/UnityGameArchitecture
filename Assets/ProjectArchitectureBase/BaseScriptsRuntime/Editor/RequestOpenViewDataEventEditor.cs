using EventsSystem.Scripts.Editor;
using ProjectArchitectureBase.Event;
using UnityEditor;
namespace ProjectArchitectureBase.Editor
{
    [CustomEditor(typeof(RequestOpenViewDataEvent))]
    public class RequestOpenViewDataEventEditor : EventEditorBase<RequestOpenViewData,RequestOpenViewDataEvent>
    {
    }
}
