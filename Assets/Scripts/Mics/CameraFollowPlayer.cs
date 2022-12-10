using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z) + offset;
    }
}

