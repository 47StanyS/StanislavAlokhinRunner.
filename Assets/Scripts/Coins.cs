using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>()._coins++;
            Destroy(gameObject);
        }
    }
}
