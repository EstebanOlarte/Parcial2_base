using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float movementFactor;
    private bool canFire = true;
    private float coolDownTime = 0.5F;
    private Collider2D myCollider;

    [SerializeField]
    private GameObject bulletGO;
    [SerializeField]
    private GameObject apBulletGo;

    protected bool InsideCamera(bool positive)
    {
        float direction = positive ? 1F : -1F;
        Vector3 cameraPoint = Camera.main.WorldToViewportPoint(
            new Vector3(
                myCollider.bounds.center.x + myCollider.bounds.extents.x * direction,
                0F,
                0F));
        return cameraPoint.x >= 0F && cameraPoint.x <= 1F;
    }

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        movementFactor = Input.GetAxis("Horizontal");

        if (InsideCamera(movementFactor > 0F) && movementFactor != 0F)
        {
            transform.position += new Vector3(movementFactor * speed * Time.deltaTime, 0F, 0F);
        }

        if (bulletGO != null && Input.GetAxis("Fire1") != 0 && canFire)
        {
            GameObject bullet = Instantiate(bulletGO, transform.position + (transform.up * 0.5F), Quaternion.identity);
            bullet.GetComponent<Bullet>().bulletType = 1;
            //print("Fiyah!");
            StartCoroutine("FireCR");
        }
        if (apBulletGo != null && Input.GetAxis("Fire2") != 0 && canFire)
        {
            GameObject bullet = Instantiate(apBulletGo, transform.position + (transform.up * 0.5F), Quaternion.identity);
            bullet.GetComponent<Bullet>().bulletType = 2;
            //print("Fiyah!");
            StartCoroutine("FireCR");
        }
    }

    private void OnDestroy()
    {
        StopCoroutine("FireCR");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            GameObject.Find("Canvas").GetComponent<GameOver>().gameOver();
        }
    }

    private IEnumerator FireCR()
    {
        canFire = false;
        yield return new WaitForSeconds(coolDownTime);
        canFire = true;
    }
}