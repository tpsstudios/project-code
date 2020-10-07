using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private Vector2 mouseInput;
    public float mouseSensitiviy = 1f;
    public Camera viewCam;


    public Animator anim;
    private int currentHealth;
    public int maxHealth = 100;
    private bool hasDied;
    public Text healthText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString() + "%";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasDied)
        {
            //player movement
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;
            rb.velocity = (moveHorizontal + moveVertical) * moveSpeed;

            //player view control
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitiviy;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);
            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

            //player shooting
            

            if (moveInput != Vector2.zero)
            {
                //anim.SetBool("isMoving", true);
            }
            else
            {
                //anim.SetBool("isMoving", false);
            }



        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {

            hasDied = true;
            currentHealth = 0;
            SceneManager.LoadScene("Startup");

        }

        healthText.text = currentHealth.ToString() + "%";

        AudioController.instance.PlayerHurt();
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthText.text = currentHealth.ToString() + "%";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Weapon")
        {
            AudioController.instance.PlayWeaponPickup();

        }
    }
}
