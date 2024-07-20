using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float timeToLife;

    private void Start()
    {
        rb.velocity = transform.right * speed;
        Invoke("OnDestroy", timeToLife);
    }
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
