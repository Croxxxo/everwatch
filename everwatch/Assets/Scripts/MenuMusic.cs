using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static MenuMusic instantce = null;
    public static MenuMusic Instance
    {
        get { return instantce; }
    }

    void Awake()
    {
        if (instantce != null && instantce != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instantce = this; 
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        
    }
}
