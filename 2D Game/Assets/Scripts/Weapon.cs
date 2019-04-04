using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private SoundManager sm;
    private Animator anim;

    void Start()
    {
        sm = SoundManager.Instance;
        anim = GetComponent<Animator>();

    }
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShootUp();
        }

    }

    void Shoot()
    {
        anim.SetTrigger("Shot");
        sm.PlaySoundEffect("RocketStart");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    public void ShootUp()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(new Vector3(0, 0, 90f));
    }
}
