using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffects : MonoBehaviour
{

    public Rigidbody rb; // Tham chiếu tới Rigidbody của vật thể
    public float gravityMultiplier = 2.0f; // Hệ số nhân trọng lực bổ sung

    private void Start()
    {
            Destroy(gameObject,2f);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Hủy toàn bộ GameObject bao gồm collider
        }   
    }

    void FixedUpdate()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        Vector3 additionalGravity = Physics.gravity * (gravityMultiplier - 1);
        rb.AddForce(additionalGravity, ForceMode.Acceleration);
    }
}
