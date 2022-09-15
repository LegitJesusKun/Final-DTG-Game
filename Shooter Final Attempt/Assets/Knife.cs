using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Knife : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject ThrowingKnife;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.E;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    // Start is called before the first frame update
    private  void Start()
    {
        readyToThrow = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
    }

    private void Throw()
    {
        readyToThrow = false;

        //instantiate object to throw
        GameObject projectile = Instantiate(ThrowingKnife, attackPoint.position, cam.rotation);

        //gets rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

       
            
        //add force
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        //implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
