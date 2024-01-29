using UnityEngine;

public class Soldier : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;

    private void Update()
    {
        var direction = (_targetPoint.position - transform.position).normalized;
        transform.forward = direction;
    }
}
