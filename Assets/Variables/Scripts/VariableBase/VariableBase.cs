using System;
using EventsSystem.Scripts.Observables;
using UnityEngine;

namespace Variables.Scripts.VariableBase
{
    public abstract class VariableBase<T,TE> : ScriptableObject where TE : Observable<T>
    {
        public T InitialValue { get => _initialValue; set => _initialValue = value; }
        [SerializeField]
        private T _initialValue = default(T);
        public T Value { get => _value; set => SetValue(value); }
        [SerializeField]
        protected T _value = default(T);
        public T OldValue { get => _oldValue; }
        [SerializeField,ReadOnly]
        private T _oldValue;
        public TE onValueChanged;
        
        
        protected virtual bool ValueEquals(T other)
        {
            return (_value == null && other == null) || (_value?.Equals(other) == true);
        }
        private void SetValue(T newValue)
        {
            bool isValueChanged = !ValueEquals(newValue);
            if (isValueChanged)
            {
                _oldValue = _value;
                _value = newValue;
                if (onValueChanged != null)
                {
                    onValueChanged.Raise(_value);
                }
            }
        }
        private void SetInitialValues()
        {
            _oldValue = InitialValue;
            _value = InitialValue;
        }

        private void OnEnable()
        {
            SetInitialValues();
        }
    }
}
