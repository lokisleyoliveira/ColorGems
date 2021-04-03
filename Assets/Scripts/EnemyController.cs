using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onGemColisionEnter += OnGemCollected;
        GameEvents.current.onGemDrop += onGemDropped;
    }

    private void OnGemCollected(int id)
    {
        if (id == this.id)
        {
            Destroy(this.gameObject);
        }
    }

    private void onGemDropped(int id)
    {
        if (id == this.id)
        {

        }
    }
}
