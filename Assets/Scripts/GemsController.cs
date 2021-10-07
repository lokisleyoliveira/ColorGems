using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsController : MonoBehaviour
{
    public int id;
    public Vector2 spawn = new Vector2(0, 0);

    private void Start()
    {
        GameEvents.current.onGemDrop += onGemDropped;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameEvents.current.GemColisionEnter(id);
            Destroy(this.gameObject);
        }
    }

    private void onGemDropped(int id)
    {
        if (id == this.id)
        {
            // TODO :: respawn
        }
    }


}
