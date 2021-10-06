using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeparation : MonoBehaviour
{
    GameObject[] enemies;
    public float spaceBetween = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (GameObject go in enemies)
        {
            if (go != gameObject)
            {
                float distance = Vector2.Distance(go.transform.position, this.transform.position);
                if (distance <= spaceBetween)
                {
                    Vector2 direction = transform.position - go.transform.position;
                    transform.Translate(direction * Time.fixedDeltaTime);
                }
            }
        }
    }
}
