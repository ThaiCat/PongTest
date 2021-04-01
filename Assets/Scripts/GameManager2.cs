using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public Text m_ScoreText;
    private int m_Score;
    public int Score
    {
        get
        {
            return m_Score;
        }

        set
        {
            m_Score = value;
            m_ScoreText.text = "Score: " + m_Score;
        }
    }

    private string m_HighScoreStr = "m_HighScoreStr";

    public Text m_HighScoreText;
    private int m_HighScore = -1;
    public int HighScore
    {
        get
        {
            if (m_HighScore == -1)
            {
                HighScore = PlayerPrefs.GetInt(m_HighScoreStr, 0);
            }
            return m_HighScore;
        }

        set
        {
            m_HighScore = value;
            m_HighScoreText.text = "HighScore: " + m_HighScore;
            PlayerPrefs.SetInt(m_HighScoreStr, m_HighScore);
        }
    }
        
    private static GameManager2 s_Singleton;
    public static GameManager2 Singleton
    {
        get
        {
            if (s_Singleton == null)
            {
                s_Singleton = FindObjectOfType<GameManager2>();
            }
            return s_Singleton;
        }
    }

    public GameObject m_CubeL;
    public GameObject m_CubeR;
    public GameObject m_CubeT;
    public GameObject m_CubeB;


    public GameObject m_PadTop;
    public GameObject m_PadBottom;

    public LayerMask m_LayerMask;

    public GameObject m_Ball;

    public float m_PadsPosLimitRight;
    public float m_PadsPosLimitLeft;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        var gg = HighScore;
        SetupZones();
        SetBallColor();
    }

    void SetupZones()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, 1f));
        m_CubeT.transform.position = new Vector3(0, m_CubeT.transform.localScale.y / 2 + ray.origin.y, 0);

        ray = Camera.main.ViewportPointToRay(new Vector3(.5f, 0));
        m_CubeB.transform.position = new Vector3(0, -m_CubeB.transform.localScale.y / 2 + ray.origin.y, 0);

        ray = Camera.main.ViewportPointToRay(new Vector3(0, .5f));
        m_CubeL.transform.position = new Vector3(-m_CubeL.transform.localScale.x / 2 + ray.origin.x, 0, 0);
        m_PadsPosLimitLeft = m_PadTop.transform.localScale.x / 2 + ray.origin.x;

        ray = Camera.main.ViewportPointToRay(new Vector3(1, .5f));
        m_CubeR.transform.position = new Vector3(m_CubeR.transform.localScale.x / 2 + ray.origin.x, 0, 0);
        m_PadsPosLimitRight = -m_PadTop.transform.localScale.x / 2 + ray.origin.x;

        ray = Camera.main.ViewportPointToRay(new Vector3(.5f, 1f));
        m_PadTop.transform.position = new Vector3(0, m_PadTop.transform.localScale.y / 2 + ray.origin.y - 1, 0);

        ray = Camera.main.ViewportPointToRay(new Vector3(.5f, 0));
        m_PadBottom.transform.position = new Vector3(0, -m_PadBottom.transform.localScale.y / 2 + ray.origin.y + 1, 0);
    }

    void SetBallColor()
    {
        m_Ball.GetComponent<MeshRenderer>().material.color = ColorPicker.s_Color;
    }

    public float m_MouseSpeed = 1f;
    private Vector3 m_MousePosDown;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_MousePosDown = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            var diff = Input.mousePosition - m_MousePosDown;
            diff = new Vector3(diff.x * m_MouseSpeed, 0, 0);
            m_MousePosDown = Input.mousePosition;

            m_PadTop.transform.position += diff;
            m_PadBottom.transform.position += diff;

            if (m_PadTop.transform.position.x < m_PadsPosLimitLeft)
            {
                m_PadTop.transform.position = new Vector3(m_PadsPosLimitLeft, m_PadTop.transform.position.y, m_PadTop.transform.position.z);
                m_PadBottom.transform.position = new Vector3(m_PadsPosLimitLeft, m_PadBottom.transform.position.y, m_PadBottom.transform.position.z);
            }
            else if (m_PadTop.transform.position.x > m_PadsPosLimitRight)
            {
                m_PadTop.transform.position = new Vector3(m_PadsPosLimitRight, m_PadTop.transform.position.y, m_PadTop.transform.position.z);
                m_PadBottom.transform.position = new Vector3(m_PadsPosLimitRight, m_PadBottom.transform.position.y, m_PadBottom.transform.position.z);
            }
        }
    }
}
