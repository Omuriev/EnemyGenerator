using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Mummy : MonoBehaviour 
{
    private Transform _target;
    private Mover _mover;

    private void Start()
    {
        _mover = GetComponent<Mover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Soldier soldier))
        {
            Destroy(soldier.gameObject);
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            _mover.SetTargetPosition(_target.position);
        }
        else
        {
            _mover.SetMovingStatus(false);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
