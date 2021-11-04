using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool isHittingBootom;
    [SerializeField] private bool isHittingForward;
    [SerializeField] private float rayForwardDistance = 1f;
    [SerializeField] private float rayDownDistance = 0.2f;

    public bool IsHittingBootom { get => isHittingBootom; set => isHittingBootom = value; }
    public bool IsHittingForward { get => isHittingForward; set => isHittingForward = value; }

    // Se actualiza cada x tiempo, se usa para cálculos de físicas
    private void FixedUpdate()
    {        
        if (Physics.Raycast(transform.position, transform.right, out hit, rayForwardDistance, layerMask))
        {
            Debug.DrawRay(transform.position, transform.right * hit.distance, Color.white);
            Debug.Log(hit.collider.gameObject);
            IsHittingForward = true;
        }
        else
        {
            IsHittingForward = false;
        }
        if (Physics.Raycast(transform.position, -transform.up, out hit, rayDownDistance, layerMask))
        {
            Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.yellow);
            Debug.Log(hit.collider.gameObject);
            IsHittingBootom = true;
        }
        else
        {
            IsHittingBootom = false;
        }
    }
}
