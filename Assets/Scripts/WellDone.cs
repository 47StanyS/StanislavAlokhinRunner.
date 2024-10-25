using UnityEngine;
using UnityEngine.SceneManagement;

public class WellDone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Well Done!!!!");
            SceneManager.LoadScene(0);
        }
    }
}
