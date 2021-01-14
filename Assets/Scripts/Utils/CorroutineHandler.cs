using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHandler : MonoBehaviour
{
    private static CoroutineHandler instance = null;
    public static CoroutineHandler Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject go = new GameObject("CoroutineHandler");
                DontDestroyOnLoad(go);
                instance = go.AddComponent<CoroutineHandler>();
            }
            return instance;
        }
    }
}