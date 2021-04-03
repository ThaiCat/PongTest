using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnFuckUnity(InputValue inputValue)
    {
        //m_MovementDiff = inputValue.Get<Vector2>();
        Debug.Log("void OnFuckUnity() " /*+ m_MovementDiff*/);
    }

    void OnClick()
    {
        Debug.Log("void OnClick()");
    }

    void OnMove()
    {
        Debug.Log("void OnMove()");
    }

    void OnMousePress()
    {
        Debug.Log("void OnMousePress()");
        //m_MousePress = true;
    }
}
