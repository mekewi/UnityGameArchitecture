﻿using System;
using System.Collections.Generic;
using System.Linq;
using EventsSystem.Scripts.Observables;
using UnityEngine;

public class GameEventsHub : Singleton<GameEventsHub>
{
    [SerializeField]
    public List<ScriptableObject> allEvents = new List<ScriptableObject>();

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public T GetEvent<T>() where T : ScriptableObject
    {
        T t = allEvents.FirstOrDefault(x => x.GetType() == typeof(T)) as T;
        if (t == null)
        {
            var newEvent = ScriptableObject.CreateInstance(typeof(T));
            allEvents.Add(newEvent);
            return (T)newEvent;
        }
        return t;
    }
    public void Register<T>(Action<T> action) where T : Observable<T>
    {
        GetEvent<T>().Register(action);
    }
    public void Notify<T>(params object[] paramet) where T : Observable<T>
    {
        var eventTONotify = GetEvent<T>();
        eventTONotify.SetData(paramet);
        eventTONotify.Raise(eventTONotify);
    }
    public void UnRegister<T>(Action<T> action) where T : Observable<T>
    {
        GetEvent<T>().Unregister(action);
    }
}