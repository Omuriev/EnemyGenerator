using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Soldier : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;

    private Mover _mover;

    private void Start()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        _mover.SetTargetPosition(_targetPoint.position);
    }
}
