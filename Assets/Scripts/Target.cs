using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Score score;

    private void Awake()
    {
        score = GameObject.FindGameObjectWithTag("Func").GetComponent<Score>();
    }

    public void TakeDamage(float amount)
    {
        score.count++;
        health -= amount;
        if (health <= 0f)
        {
            score.count += 5;
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
