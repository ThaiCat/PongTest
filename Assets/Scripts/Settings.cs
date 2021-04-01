using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private static Settings s_Settings;
    public static Settings Singleton
    {
        get
        {
            if (s_Settings == null)
            {
                s_Settings = FindObjectOfType<Settings>();
            }
            return s_Settings;
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    private void Awake()
    {
        if (s_Settings == null)
        {
            s_Settings = this;
        }
        else if (s_Settings != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Close();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
