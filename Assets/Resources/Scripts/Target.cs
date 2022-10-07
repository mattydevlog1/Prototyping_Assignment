using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 5;

    public GameObject[] gameObjects = new GameObject[9];

    public GameObject zombie;
    public GameObject me;
    
    

    

    void Update()
    {
        //  Debug.Log(health);

        if (health <= 0)
        {

            GameManager.instance.highScore += 1;
            Destroy(zombie);
            Instantiate(gameObjects[Random.Range(0, gameObjects.Length)], me.transform.position, Quaternion.identity);
           




        }
    }

    /// 'Hits' the target for a certain amount of damage
    public void Hit(float damage)
    {
        health -= Gun.damage;
       // Debug.Log(health);




    }

}