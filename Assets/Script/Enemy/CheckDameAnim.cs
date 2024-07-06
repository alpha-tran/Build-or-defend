using UnityEngine;

public class CheckDameAnim : MonoBehaviour
{
    private bool _check;
    internal bool Check => _check;

    public LayerMask overlapLayerMask; // LayerMask để chỉ định các layer muốn kiểm tra va chạm
    public float checkRadius = 1.0f;    // Bán kính của OverlapSphere

    void Start()
    {
        _check = false;
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, overlapLayerMask,QueryTriggerInteraction.Collide);

        _check = false;
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Dame"))
            {
                print("alo");
                _check = true;
                break;
            }
        }
    }

    public void ResetHit()
    {
        _check = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
