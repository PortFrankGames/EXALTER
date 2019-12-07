using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessionTarget : MonoBehaviour
{
    bool canBePossessed;
    GameObject previousShell;

    private void Start()
    {
        canBePossessed = false;
    }

    void Update()
    {
        if(Time.timeScale == 0)
        {
            canBePossessed = true;
        }
        else
        {
            canBePossessed = false;
        }
    }

    void OnMouseOver()
    {
        //highlight item
    }

    void OnMouseDown()
    {
        if(canBePossessed == true)
        {
            Debug.Log("clicking on target");
            previousShell = (GameObject.FindWithTag("Player"));
            Component[] components = previousShell.GetComponents(typeof(Component));

            for (int i = 0; i < components.Length; i++)
            {
                gameObject.AddComponent(components[i].GetType());
            }

            Destroy(previousShell);
            this.gameObject.tag = "Player";
            //playerController pCont = gameObject.AddComponent<playerController>() as playerController;
        }
    }
}
