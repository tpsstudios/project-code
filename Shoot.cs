using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public static Shoot instance;
    public Animator gunAnim;
    public GameObject bulletImpact;
    public int currentAmmo;
    public Text  ammoText;
    Camera viewCam;
    public int maxAmmo;

    private void Awake()
    {
        instance = this;
        ammoText.text = currentAmmo.ToString();
        gunAnim = GetComponent<Animator>();
        viewCam = Camera.main;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {
                Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("I'm Looking at " + hit.transform.name);
                    Instantiate(bulletImpact, hit.point, transform.rotation);

                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                    }

                    //AudioController.instance.PlayGunshot();
                }
                else
                {
                    Debug.Log("I'm Looking at nothing");
                }
                currentAmmo--;
                gunAnim.SetTrigger("Shoot");
                UpdateAmmoUI();
            }
        }
    }

    public void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo.ToString();
    }
}
