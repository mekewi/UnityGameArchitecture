using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UIViewsManager : Singleton<UIViewsManager>
{
    public UIViewsManagerData_SO uiViewsManagerData;
    public List<UIViewController> uIViewControllers;
    public UIViewController currentOpenedView;
    public List<UIViewController> allOpenedViews;
    private void Start()
    {
        allOpenedViews = new List<UIViewController>();
        uIViewControllers = new List<UIViewController>();
        uIViewControllers.AddRange(transform.GetComponentsInChildren<UIViewController>());
    }
    public void RequestOpenView(RequestOpenViewData requestOpenViewData) 
    {
        OpenViewProcess(requestOpenViewData.viewType, requestOpenViewData.viewData);
    }
    private void OpenViewProcess(ViewType viewType,IViewData viewData)
    {
        var viewController = GetViewControllerByType(viewType);
        if (viewData != null)
        {
            viewController.SetData(viewData);
        }
        else
        {
            viewController.AfterSetData();
        }
        viewController.OpenView();
        allOpenedViews.Add(viewController);
        currentOpenedView = viewController;

    }
    public UIViewController GetViewControllerByType(ViewType viewType)
    {
        return uIViewControllers.FirstOrDefault(x => x.GetViewType() == viewType);
    }
    public void RequestCloseAllViews()
    {
        allOpenedViews.ForEach(x => x.CloseView());
        allOpenedViews.Clear();
        currentOpenedView = null;
    }
    public void RequestCloseView(ViewType viewType)
    {
        var viewController = allOpenedViews.FirstOrDefault(x => x.viewBase.viewType == viewType);
        if (viewController == null)
        {
            return;
        }
        viewController.CloseView();
        allOpenedViews.Remove(viewController);
    }
    public void RequestCloseCurrent()
    {
        if (currentOpenedView == null)
        {
            return;
        }
        currentOpenedView.CloseView();
        allOpenedViews.Remove(currentOpenedView);
        currentOpenedView = null;
    }
}
