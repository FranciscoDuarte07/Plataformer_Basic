using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float distanceRaycast = 0.5f;
    private float cooldownAttack = 1.5f;
    private float actualCoolDownAttack;
    [SerializeField] GameObject beeBullet;

    // Start is called before the first frame update
    void Start()
    {
        actualCoolDownAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        actualCoolDownAttack -= Time.deltaTime;

        Debug.DrawRay(transform.position, Vector2.down, Color.red, distanceRaycast);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, distanceRaycast);
        if (hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Player"))
            {
                if (actualCoolDownAttack < 0)
                {
                    Invoke("LounchBullet", 0.5f);
                    animator.Play("Attack");
                    actualCoolDownAttack = cooldownAttack;
                }
            }
        }
    }

    void LounchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(beeBullet, transform.position, transform.rotation);
    }
}
