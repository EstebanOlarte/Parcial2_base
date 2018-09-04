using UnityEngine;

public class KillVolume : MonoBehaviour
{
    [SerializeField]


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {

            GameObject.Find("Canvas").GetComponent<GameOver>().gameOver();
        }

        Destroy(collision.gameObject);
    }
}