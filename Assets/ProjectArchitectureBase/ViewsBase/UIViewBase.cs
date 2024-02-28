using ProjectArchitectureBase.Event;
using UnityEngine;
using UnityEngine.UI;

public enum ViewType 
{
    None,
    UpgradeView,
}
public class UIViewBase : MonoBehaviour 
{
    public ViewType viewType;
    public GameObject parent;
    public GameObject view;
    public Image bg;
    public bool isViewIsOpened;
    public float closeAnimationDuration;
    private void Start()
    {
    }
    public virtual void OpenView() 
    {
        if (isViewIsOpened)
        {
            return;
        }
        parent.SetActive(true);
        DoOpenAnimation();
        isViewIsOpened = true;
    }
    public void DoOpenAnimation() 
    {
    }
    public virtual void CloseView() 
    {
        if (!isViewIsOpened)
        {
            return;
        }
        DoClose();
    }
    public void DoClose() 
    {
        if (view == null)
        {
            OnCloseAnimation();
            return;
        }
        CloseAnimation();
        isViewIsOpened = false;
    }
    public void CloseAnimation()
    {
        Invoke("OnCloseAnimation", closeAnimationDuration);
    }

    private void OnCloseAnimation() 
    {
        parent.SetActive(false);
    }
    private void OnDestroy()
    {
    }
}
