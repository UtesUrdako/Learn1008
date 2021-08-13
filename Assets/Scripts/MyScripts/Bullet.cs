using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Init(float lifeTime = 0f, string tag = "")
    {
        Destroy(gameObject, lifeTime);
    }
}
