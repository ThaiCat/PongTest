using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public Slider m_SliderRed;
    public Slider m_SliderGreen;
    public Slider m_SliderBlue;

    public Image m_Image;

    private string m_ColorStrR = "MainColorR";
    private string m_ColorStrG = "MainColorG";
    private string m_ColorStrB = "MainColorB";


    private bool m_Init;
    
    public static Color s_Color;
    [SerializeField] private Color m_Color;
    public Color Color
    {
        get
        {
            if (!m_Init)
            {
                m_Init = true;
                m_Color = new Color(
                    PlayerPrefs.GetFloat(m_ColorStrR, m_Color.r),
                    PlayerPrefs.GetFloat(m_ColorStrG, m_Color.g),
                    PlayerPrefs.GetFloat(m_ColorStrB, m_Color.b)
                    );
                s_Color = m_Color;
            }

            return m_Color;
        }

        set
        {
            if (m_Color == value)
                return;

            m_Color = value;
            s_Color = value;
            PlayerPrefs.SetFloat(m_ColorStrR, m_Color.r);
            PlayerPrefs.SetFloat(m_ColorStrG, m_Color.g);
            PlayerPrefs.SetFloat(m_ColorStrB, m_Color.b);
        }
    }


    // Start is called before the first frame update
    void Start()
    {        
        m_Image.color = Color;

        m_SliderRed.value = Color.r;
        m_SliderGreen.value = Color.g;
        m_SliderBlue.value = Color.b;
    }

    // Update is called once per frame
    void Update()
    {
        Color = new Color(m_SliderRed.value, m_SliderGreen.value, m_SliderBlue.value);
        m_Image.color = Color;
    }
}
