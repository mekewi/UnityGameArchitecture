
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

namespace ServiceLocatorPattern
{
    public enum ServiceScopeType
    {
        GameObject,
        Scene,
        Global,
    }
    public class ServiceLocatorScopeBase
    {
        public virtual bool TryGetServiceLocator(MonoBehaviour context, out ServiceLocator serviceLocatorFounded)
        {
            throw new NotImplementedException();
        }
    }
    public class ServiceLocatorGlobalScope : ServiceLocatorScopeBase
    {
        public ServiceLocator serviceLocator;
        const string k_globalServiceLocatorName = "ServiceLocator [Global]";
        public override bool TryGetServiceLocator(MonoBehaviour context, out ServiceLocator serviceLocatorFounded)
        {
            if (serviceLocator != null)
            {
                serviceLocatorFounded = serviceLocator;
                return true;
            }
            var container = new GameObject(k_globalServiceLocatorName, typeof(ServiceLocator));
            serviceLocator = container.GetComponent<ServiceLocator>();
            serviceLocator.DontDestory();
            serviceLocator.serviceScope = ServiceScopeType.Global;
            serviceLocator.addServiceAsChild = true;
            serviceLocatorFounded = serviceLocator;
            return true;
        }
    }
    public class ServiceLocatorSceneScope : ServiceLocatorScopeBase
    {
        private Dictionary<Scene, ServiceLocator> sceneContainers = new Dictionary<Scene, ServiceLocator>();
        const string k_sceneServiceLocatorName = "ServiceLocator [Scene]";
        public override bool TryGetServiceLocator(MonoBehaviour context, out ServiceLocator serviceLocatorFounded)
        {
            Scene scene = context.gameObject.scene;
            if (GetLocatorFromDic(scene, out ServiceLocator serviceLocatorFoundedInDic))
            {
                serviceLocatorFounded = serviceLocatorFoundedInDic;
                return true;
            }
            if (FindServiceLocatorFromTheScene(scene, out ServiceLocator serviceLocatorFoundedInScene))
            {
                sceneContainers.Add(scene, serviceLocatorFoundedInScene);
                serviceLocatorFounded = serviceLocatorFoundedInScene;
                return true;
            }
            var newLocator = CreateNewServiceLocator(scene);
            sceneContainers.Add(scene, newLocator);
            serviceLocatorFounded = newLocator;
            return true;
        }
        private bool GetLocatorFromDic(Scene scene, out ServiceLocator serviceLocator)
        {
            if (sceneContainers.TryGetValue(scene, out serviceLocator))
            {
                return true;
            }
            return false;
        }
        private bool FindServiceLocatorFromTheScene(Scene scene, out ServiceLocator serviceLocator)
                {
            var tmpSceneGameObjects = new List<GameObject>();
            scene.GetRootGameObjects(tmpSceneGameObjects);
            foreach (GameObject go in tmpSceneGameObjects.Where(go => go.GetComponent<ServiceLocator>() != null))
            {
                if (go.TryGetComponent(out ServiceLocator serviceLocatorComponent))
                {
                    if (serviceLocatorComponent.serviceScope == ServiceScopeType.Scene)
                    {
                        serviceLocator = serviceLocatorComponent;
                        return true;
                    }
                }
            }
            serviceLocator = null;
            return false;
        }
        private ServiceLocator CreateNewServiceLocator(Scene scene)
        {
            var newServiceLocatorGameobject = new GameObject(k_sceneServiceLocatorName);
            var newServiceLocator = newServiceLocatorGameobject.AddComponent<ServiceLocator>();
            newServiceLocator.serviceScope = ServiceScopeType.Scene;
            newServiceLocator.addServiceAsChild = true;
            SceneManager.MoveGameObjectToScene(newServiceLocatorGameobject, scene);
            return newServiceLocator;
        }
    }
    public class ServiceLocatorGameObjectScope : ServiceLocatorScopeBase
    {
        public override bool TryGetServiceLocator(MonoBehaviour context, out ServiceLocator serviceLocatorFounded)
        {
            var serviceLocator = context.GetComponentInParent<ServiceLocator>();
            if (serviceLocator != null)
            {
                serviceLocatorFounded = serviceLocator;
                return true;
            }
            serviceLocatorFounded = null;
            return false;
        }
    }
}
