﻿using UnityEngine;

namespace BrickBreak.Singletons
{
    /// <summary>
    /// The purpose of this class is to act as a base class for all Singletons to make handling Singletons easier
    /// NOTE: Classes that inherit from Singleton will decide if they should implement "DontDestroyOnLoad" because some Singletons don't require this
    /// Code Reference: http://wiki.unity3d.com/index.php/Singleton
    /// </summary>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        _instance = new GameObject("Instance of " + typeof(T)).AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
        }

        public void OnApplicationQuit()
        {
            // Garbage Collection..
            _instance = null;
        }
    }
}