using UnityEngine;
using ProjectArchitectureBase.BaseScriptsRuntime.Event;

namespace Variables.Scripts.VariableBase.Variables
{
    [CreateAssetMenu(menuName = "Variables/string", fileName = "StringVariable")]
    public class StringVariable : Variable<string,StringEvent>
    {  
    }
}
