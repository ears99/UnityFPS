using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 50f;

    public void takeDamage(float amount) {
        health -= amount;
        if(amount == 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("Target Destroyed.");
        Destroy(gameObject);
    }
}
