using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerDataHandle : MonoBehaviour
{
    public static PlayerDataHandle instance;

    public string playerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
