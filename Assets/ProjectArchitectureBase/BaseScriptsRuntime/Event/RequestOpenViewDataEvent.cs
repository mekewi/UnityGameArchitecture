using EventsSystem.Scripts.Observables;
using UnityEngine;
namespace ProjectArchitectureBase.Event
{
    [CreateAssetMenu(fileName = "RequestOpenViewDataEvent", menuName = "Events/RequestOpenViewDataEvent")]
    public class RequestOpenViewDataEvent : Observable<RequestOpenViewData>
    {
        public override void SetData(params object[] data)
        {
        }
    }
}
