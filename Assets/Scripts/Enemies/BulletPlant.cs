using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlant : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float lifeTime = 3;
    [SerializeField] bool left;

    private void Start()
    {

        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        if (left)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
