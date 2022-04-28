using System;
using UnityEngine;

namespace Variables.Scripts.VariableBase
{
    public abstract class VariableBase<T> :ScriptableObject
    {
        public virtual T Value
        {
            get => _value;
            set => throw new NotImplementedException();
        }
        [SerializeField] protected T _value = default(T);

    }
}