using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;

    public AudioSource Shatter;

    public void TakeDamage(float amount)
    // If the object's health becomes equal or less than zero it calls the die function and plays the shatter sound
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
            Shatter.Play();
        }
    }


    void Die()
    //Destroys itself
    {
        Destroy(gameObject);
    }
} 