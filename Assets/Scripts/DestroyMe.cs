using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour
{

    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
