using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;
    [SerializeField] float WaitedTimeAttack = 3f;
    [SerializeField] Animator animator;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform launchSpawnPoint;

    private void Start()
    {
        waitedTime = WaitedTimeAttack;
    }

    private void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = WaitedTimeAttack;
            animator.Play("Attack");
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;

        newBullet = Instantiate(bulletPrefab, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
