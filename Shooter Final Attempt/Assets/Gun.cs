
using UnityEngine;
using System.Collections;
public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public bool gunon = true;
    public ParticleSystem MuzzleFlash;


    public Camera fpsCam;


    // Update is called once per frame
    void Update()
    {
        // Checks if mb1 is clicked and if the 'gunon' bool is true. It then starts the shoot function if it is.
        if (Input.GetButtonDown("Fire1") && gunon == true)
        {
          
          
            {
                Shoot();
                MuzzleFlash.Play();
             StartCoroutine(waiter());
            }

        }
    }
    IEnumerator waiter()
        // Coroutine that changes 'gunon' bool to false, waits 0.2 seconds, then changes it back to true
    {
        gunon = false;
        yield return new WaitForSeconds(0.2f);
        gunon = true;
            
    }
    void Shoot()
        // Raycast function for actual gun functionality
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

    }
}
