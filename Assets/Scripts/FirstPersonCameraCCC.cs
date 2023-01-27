using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraCCC : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;

    public float speedRotation;

    public Transform cameraTransform;

    public Rigidbody firstPersonRigidBody;

    private Vector3 movement;
    private float yVel;

    public float jumpForce = 5f;

    private bool locked;

    public GameObject weaponDetector;

    private void Start()
    {

        locked = true;
        firstPersonRigidBody = GetComponent<Rigidbody>();
    }

    //O usar FixedUpdate();
    private void Update()
    {
        CmaeraMachine();
       
    }

    private void Move() {
        //Movimiento
        //con FixedUodate()
        //transform.Translate(Vector3.forward * speed * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));

        transform.Translate(Vector3.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));


        //Mira
        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime * Input.GetAxis("Mouse X"));

        //arrastrar ka camara en el editor
        //cameraTransform.Rotate(Vector3.right * speedRotation * -Input.GetAxis("Mouse Y"));


        //por jerarquia
        //transform.GetChild(0).Rotate(Vector3.right * speedRotation * -Input.GetAxis("Mouse Y"));
        Camera.main.transform.Rotate(Vector3.right * speedRotation * Time.deltaTime * -Input.GetAxis("Mouse Y"));
    }



    private void Physics() {

        movement = Vector3.zero;
        yVel = firstPersonRigidBody.velocity.y;

        transform.Translate(transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));

        transform.Translate(transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));


        transform.Rotate(transform.up * speedRotation * Time.deltaTime * Input.GetAxis("Mouse X"));

        Camera.main.transform.Rotate(Vector3.right * speedRotation * Time.deltaTime * -Input.GetAxis("Mouse Y"));
        
        //movimiento en z
        movement = transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        movement += transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal");

        movement.y = yVel;

        firstPersonRigidBody.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space)) {
            firstPersonRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void CmaeraMachine() {

        if (locked) {
            return;
        }
              
        movement = Vector3.zero;
        yVel = firstPersonRigidBody.velocity.y;

        //transform.Translate(transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));

        //transform.Translate(transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));


        //transform.Rotate(transform.up * speedRotation * Time.deltaTime * Input.GetAxis("Mouse X"));

        //Camera.main.transform.Rotate(Vector3.right * speedRotation * Time.deltaTime * -Input.GetAxis("Mouse Y"));

        //movimiento en z
        //movement = transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        //movement += transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal");

        movement = Camera.main.transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        movement += Camera.main.transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal");

        movement.y = yVel;

        firstPersonRigidBody.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            firstPersonRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    public void unlockCOntrol() {
        locked = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameObject weapCollision = collision.gameObject;
        if (weapCollision.tag == "Weapon") {
            int weaponRecharge = weapCollision.GetComponent<WeaponCCC>().getWeapon();
            Debug.Log("Recargando...[" + weaponRecharge + "] balas");

            ShooterCCC shooter = FindObjectOfType<ShooterCCC>();

            if (shooter.bullets < shooter.maxBulletAllowed) {
                int rechargeBullets = shooter.bullets + weaponRecharge;
                if (rechargeBullets > shooter.maxBulletAllowed)
                {
                    rechargeBullets = shooter.maxBulletAllowed;
                    shooter.bullets = rechargeBullets;
                } else {
                    shooter.bullets = rechargeBullets;
                }
                Debug.Log("Balas disponibles [" + shooter.bullets + "]");

                weapCollision.SetActive(false);
            }
            
        }
        


    }

}
