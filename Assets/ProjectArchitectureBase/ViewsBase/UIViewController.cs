using ProjectArchitectureBase.Event;
using UnityEngine;
[RequireComponent(typeof(UIViewBase))]
public class UIViewController : MonoBehaviour 
{
    public UIViewBase viewBase;
    public IViewData viewDataBase;
    public float delay;
    public bool PauseGame;
    public VoidEvent pasueGame;
    public VoidEvent continueGame;

    public virtual void SetData(IViewData _viewDataBase) 
    {
        viewDataBase = _viewDataBase; 
        AfterSetData();
    }
    public virtual void AfterSetData() 
    {
    }
    public virtual void OpenView() 
    {
        pasueGame.Raise();
        if (delay == 0)
        {
            OpenViewDelay();
        }
        else 
        {
            Invoke("OpenViewDelay", delay);
        }
    }

    public virtual void OpenViewDelay() 
    {
        viewBase.OpenView();
    }
    public virtual void CloseView() 
    {
        continueGame.Raise();
        viewBase.CloseView();
    }
    public ViewType GetViewType()
    {
        return viewBase.viewType;
    }
}