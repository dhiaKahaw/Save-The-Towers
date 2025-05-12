using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform castle; // Reference to the castle (cube)
    public float speed = 3f;
    public float stopDistance = 0.005f; // Distance threshold to destroy the enemy
    public int damage = 10;

    void Start()
    {
      
        GameObject castleObject = GameObject.FindWithTag("castle");

  
        
            castle = castleObject.transform;
        
    }

    void Update()
    {
        if (castle != null)
        {
            // Make the enemy face the castle
            Vector3 direction = (castle.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            // Move the enemy toward the castle's position
            transform.position = Vector3.MoveTowards(transform.position, castle.position, speed * Time.deltaTime);

            // Check if the enemy has reached the castle
            if (Vector3.Distance(transform.position, castle.position) <= stopDistance)
            {
                DamageCastle();
                Destroy(gameObject);
            }
        }
    }
    void DamageCastle()
    {
        CastleHealth castleHealth = castle.GetComponent<CastleHealth>();
        if (castleHealth != null)
        {
            castleHealth.TakeDamage(damage); // Damage the castle
            AudioManager.instance.PlayEnemyReachedCastleSound();
        }
        else
        {
            Debug.LogError("CastleHealth component not found on the castle!");
        }
    }
}
