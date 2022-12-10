using UnityEngine;
using System.Collections;

public class ItemHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
		Debug.Log(collision.gameObject.name);
		Destroy(gameObject);
    }
}

