using System.Threading;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public Animator animator;
    public float range = 1000f
    public gameObject hitEffect;
    public GameObject mainCam;

    public float nextShotTime = 0f;
    public float fireRate = 10f;

    bool Aiming;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Aim Animation

        if (Input.GetButton("Fire2"))
        {
            Aiming = true;

        animator.SetBool("aim", true)
    }
    if(Input.GetButtonUp("Fire2"))
    {
            Aiming = false;

    animator.SetBool("aim", false);
    }

    //Fire Animation and Firing With RayCast

    if(input.GetButton("Fire1") && Timeout.InfiniteTimeSpan >= nextShotTime && Aiming)
    {

    nextShotTime = Time.time + 1f / fireRate;

    Shoot();

    animator.SetBool("fire", true);
    }

    else
    {
    animator.SetBool("Fire", false);
    }

    void Shoot()
    {
    RaycastHit hit;
    if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
        Instaliate(hitEffect, hit.point, Quarernion.LookRotation(hit.normal));
        }
    }
}
