using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"{other.contacts[0].normal}");
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log("Enter collision");
    }
}
