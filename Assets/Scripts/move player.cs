using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplayer : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 startPoint;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        rb.MovePosition(rb.position + dir * speed * Time.deltaTime);
    }

    public void TeleportToStart()
    {
        rb.position = startPoint;
    }
}
