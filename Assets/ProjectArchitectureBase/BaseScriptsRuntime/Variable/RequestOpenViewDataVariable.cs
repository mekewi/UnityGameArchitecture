using UnityEngine;
using ProjectArchitectureBase.Event;
using ProjectArchitectureBase.VariableBase;
namespace ProjectArchitectureBase.Variables
{
    [CreateAssetMenu(menuName = "Variables/RequestOpenViewData", fileName = "RequestOpenViewDataVariable")]
    public class RequestOpenViewDataVariable : Variable<RequestOpenViewData,RequestOpenViewDataEvent>
    {  
    }
}
