using System.ComponentModel.Design;
using UnityEngine;
namespace ServiceLocatorPattern
{
    public class ServiceLocatorRegister : MonoBehaviour
    {
        public ServiceScopeType serviceScopeType;
        [SerializeReference]
        public IService service;
        private void Awake()
        {

        }
    }
    public interface IService { }
}