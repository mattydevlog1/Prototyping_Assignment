using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 5;



    void Update()
    {
        //  Debug.Log(health);

        if (health <= 0)
        {

            Destroy(gameObject);

        }
    }

    /// 'Hits' the target for a certain amount of damage
    public void Hit(float damage)
    {
        health -= Gun.damage;
        Debug.Log(health);
    }

}