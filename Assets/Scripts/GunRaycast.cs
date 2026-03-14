using UnityEngine;

public class GunRaycast : MonoBehaviour
{
 
    public float rayDistance = 50f;

    public LayerMask layerMask;



    void Update()
    {
        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;      

        if (Physics.Raycast(origin, direction, out hit, rayDistance, layerMask))
        {
            Debug.Log("Hit: " + hit.collider.name);
            Debug.DrawRay(origin, direction * rayDistance, Color.red);

        }

    }
}
