using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "UiViewsManagerData",fileName = "UiViewsManagerData")]
public class UIViewsManagerData_SO : ScriptableObject 
{
    public List<UIViewsManagerData> uIViewsManagerDatas;
    public UIViewDataBase GetViewData(ViewType viewType)
    {
        var viewDataManager = uIViewsManagerDatas.FirstOrDefault(x => x.viewType == viewType);
        if (viewDataManager == null) return null;
        return viewDataManager.uiViewDataBase;
    }
}
[Serializable]
public class UIViewsManagerData
{
    public ViewType viewType;
    public UIViewDataBase uiViewDataBase;
}