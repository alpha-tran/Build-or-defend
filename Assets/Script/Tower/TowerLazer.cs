using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class TowerLaser : MonoBehaviour
{
    [Header("Quay súng")]
    [SerializeField] private Transform _gunPositionY;
    [SerializeField] private Transform _gunPositionX;

    [Header("Giá trị quay")]
    [SerializeField] private float _minRotationX = 30;
    [SerializeField] private float _maxRotationX = 60;

    [Header("Enemy Detection")]
    [SerializeField] private Transform _transformCheck;
    [SerializeField] private float _detectionRadius = 5f;
    [SerializeField] private LayerMask _enemyLayerMask;

    public CheckDamages _lazer;

    public LineRenderer LaserLine;

    private Transform m_targetEnemy;

    private Collider[] detectedEnemies;

    private void Update()
    {
        CheckForEnemy();
        if (m_targetEnemy != null)
        {
            AimAtEnemy();
            Lazer();
        }
       
    }

    private void CheckForEnemy()
    {
        detectedEnemies = Physics.OverlapSphere(_transformCheck.position, _detectionRadius, _enemyLayerMask, QueryTriggerInteraction.Collide);
        m_targetEnemy = detectedEnemies.Length > 0 ? detectedEnemies[0].transform : null;
    }

    private void Lazer()
    {
        if (LaserLine == null)
            return;

        if (m_targetEnemy == null)
        {
            LaserLine.positionCount = 0;
            LaserLine.enabled = false;
        }
        else
        {
            LaserLine.enabled = true;
            LaserLine.startWidth = 0.1f;
            LaserLine.endWidth = 0.1f;

            LaserLine.positionCount = 2;
            LaserLine.SetPosition(0, LaserLine.transform.position);
            LaserLine.SetPosition(1, m_targetEnemy.position);


            Vector3 direction = m_targetEnemy.position - LaserLine.transform.position;
            RaycastHit hit;

            Debug.DrawRay(LaserLine.transform.position, direction, Color.red, 1.0f); // Draw the ray for visualization

            if (Physics.Raycast(LaserLine.transform.position, direction, out hit, Mathf.Infinity, _enemyLayerMask,QueryTriggerInteraction.Collide))
            {
                _lazer.setPerant(hit.collider);
            }
            else
            {
                Debug.Log("không trúng.");
            }
        }

    }


    private void AimAtEnemy()
    {
        if (m_targetEnemy != null)
        {
            Vector3 directionY = GetDirectionForXAxis(m_targetEnemy.position - _gunPositionY.position);
            Vector3 directionX = GetDirectionForYAxis(m_targetEnemy.position - _gunPositionX.position);

            if (directionY != Vector3.zero)
            {
                Quaternion targetRotationY = Quaternion.LookRotation(directionY);
                _gunPositionY.rotation = Quaternion.Euler(0, targetRotationY.eulerAngles.y, 0);

                Quaternion targetRotationX = Quaternion.LookRotation(directionX);
                float clampedAngleX = Mathf.Clamp(targetRotationX.eulerAngles.x, _minRotationX, _maxRotationX);
                _gunPositionX.rotation = Quaternion.Euler(clampedAngleX, _gunPositionX.rotation.eulerAngles.y, _gunPositionX.rotation.eulerAngles.z);
            }
        }
    }

    private Vector3 GetDirectionForXAxis(Vector3 direction)
    {
        direction.y = 0;
        return direction.normalized;
    }

    private Vector3 GetDirectionForYAxis(Vector3 direction)
    {


        direction.x = 0; 
        return direction.normalized;
    }

    private void OnDrawGizmos()
    {
        if (_transformCheck != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_transformCheck.position, _detectionRadius);
        }
    }
}
