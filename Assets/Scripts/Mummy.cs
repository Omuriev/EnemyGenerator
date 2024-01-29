using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Mummy : MonoBehaviour 
{
    private Transform _target;
    private Movement _movement;

    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (_target != null)
        {
            SetDirection();
        }
        else
        {
            _movement.SetMovingStatus(false);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void SetDirection()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        transform.forward = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Soldier soldier))
        {
            Destroy(soldier.gameObject);
        }
    }
}
