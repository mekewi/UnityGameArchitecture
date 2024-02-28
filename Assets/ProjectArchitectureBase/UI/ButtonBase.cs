using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour
{
    public Button button;
    public bool isAvailable;
    public UnityEvent onPress;
    public UnityEvent<bool> OnAvaiablitlyChanged;
    public void OnClick() 
    {
        if (!isAvailable)
        {
            return;
        }
        onPress.Invoke();
    }
    public void ChangeAvailability(bool _isAvailable) 
    {
        if (isAvailable != _isAvailable)
        {
            OnAvaiablitlyChanged.Invoke(_isAvailable);
        }
        isAvailable = _isAvailable;
        button.interactable = _isAvailable;
    }
}
