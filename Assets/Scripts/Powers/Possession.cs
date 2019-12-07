using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possession : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButton("LeftShift"))
        {
            Time.timeScale = 0;
        }
        if (Input.GetButtonUp("LeftShift"))
        {
            Time.timeScale = 1;
        }
    }

}
