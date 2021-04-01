using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 m_Velocity;

    // Start is called before the first frame update
    void Start()
    {
        ResetVelocity();
    }

    void ResetVelocity()
    {
        m_Velocity = Random.onUnitSphere * Random.Range(1, 5);
        m_Velocity = new Vector3(m_Velocity.x, m_Velocity.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += m_Velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("  " + other.name);
        if (other.tag == "Respawn")
        {
            transform.position = Vector3.zero;
            ResetVelocity();

            if (GameManager2.Singleton.Score > GameManager2.Singleton.HighScore)
            {
                GameManager2.Singleton.HighScore = GameManager2.Singleton.Score;
            }
            GameManager2.Singleton.Score = 0;
        }
        else if (other.tag == "Border")
        {
            m_Velocity = new Vector3(-m_Velocity.x, m_Velocity.y, 0);
        }
        else
        {
            m_Velocity = new Vector3(m_Velocity.x, -m_Velocity.y, 0);
            GameManager2.Singleton.Score += 1;
        }
    }


}
