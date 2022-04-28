using UnityEngine;
using ProjectArchitectureBase.BaseScriptsRuntime.Event;

namespace Variables.Scripts.VariableBase.Variables
{
    [CreateAssetMenu(menuName = "Variables/int", fileName = "IntVariable")]
    public class IntVariable : Variable<int,IntEvent>
    {  
    }
}
