using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour, IInteractable
{

    public bool Interact()
    {
        print("interacted with computer");
        return true;
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
