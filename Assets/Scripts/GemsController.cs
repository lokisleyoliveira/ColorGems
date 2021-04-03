using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsController : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameEvents.current.GemColisionEnter(id);
            Destroy(this.gameObject);
        }
    }
}
