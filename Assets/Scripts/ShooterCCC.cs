using UnityEngine;

public class ShooterCCC : MonoBehaviour
{
    public GameObject bullet;
    public Transform originBullet;

    public float bulletForce;

    public int maxBulletAllowed = 10;

    public int bullets;

    private GameObject tmpBullet;
    // Update is called once per frame

    private void Start()
    {
        bullets = maxBulletAllowed;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            if (bullets > 0) {
                tmpBullet = Instantiate(bullet, originBullet.position, Quaternion.identity);

                tmpBullet.transform.up = originBullet.forward;

                tmpBullet.GetComponent<Rigidbody>().AddForce(originBullet.forward * bulletForce, ForceMode.Impulse);
                bullets--;
                Debug.Log("Balas disponibles: " + bullets);
            }
            
        }
    }
}
