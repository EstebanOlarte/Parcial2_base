using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private Collider2D myCollider;
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float force = 10F;

    [SerializeField]
    private float autoDestroyTime = 5F;

    public int bulletType;

    // Use this for initialization
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);

        Invoke("AutoDestroy", autoDestroyTime);
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard" && bulletType==2)
        {
            
        }
        else if(bulletType==1)
        {
            AutoDestroy();
        }
        else if (collision.gameObject.layer==8)
        {
            AutoDestroy();
        }
    }

}