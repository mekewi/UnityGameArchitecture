using System;
using UnityEngine;
public interface IViewData 
{

}
[CreateAssetMenu(menuName = "UIViewSettings/ViewData",fileName ="ViewData")]
public class UIViewDataBase : ScriptableObject, IViewData
{
}
