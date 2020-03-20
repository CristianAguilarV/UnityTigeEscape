using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    // Destroy this world instance after a certain time
    public int lifetime = 100;
    void Start()
    {
        Invoke("DestroyWorld", lifetime);
    }

   private void DestroyWorld()
    {
        Destroy(gameObject);
    }
}
