using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveer : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float speed_textur;
    public Material mat;

    private void FixedUpdate()
    {
        mat.mainTextureOffset = new Vector2(Time.time * speed_textur * Time.deltaTime*speed, 0f);
        Vector3 pos = rb.position;
        rb.position += Vector3.left * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }
}
