using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeAspect : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    // Es llamado cuando se carga el script
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColorChange"))
            meshRenderer.material = other.GetComponent<MeshRenderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ColorChange"))
        meshRenderer.material = collision.gameObject.GetComponent<MeshRenderer>().material;
    }
}
