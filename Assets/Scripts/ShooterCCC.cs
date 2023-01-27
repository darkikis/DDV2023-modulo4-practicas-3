using UnityEngine;

public class ShooterCCC : MonoBehaviour
{
    public GameObject bullet;
    public Transform originBullet;

    public float bulletForce;

    public int maxBullet = 6;

    private GameObject tmpBullet;
    // Update is called once per frame

    private void Start()
    {
        maxBullet = 6;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {

            if (maxBullet > 0) {
                tmpBullet = Instantiate(bullet, originBullet.position, Quaternion.identity);

                tmpBullet.transform.up = originBullet.forward;

                tmpBullet.GetComponent<Rigidbody>().AddForce(originBullet.forward * bulletForce, ForceMode.Impulse);
                maxBullet--;
                Debug.Log("Balas disponibles: " + maxBullet);
            }
            
        }
    }
}
