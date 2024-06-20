using UnityEngine;
using UnityEngine.UI;

public class ShootProjectile : MonoBehaviour
{
    public GameObject enemyBullet;

    public GameObject objBullet;

    public float projectileSpeed = 100.0f;

    public AudioClip shootSFX;

    //public Image reticleImage;

    public Color projectileColor;

    public Color diffuserColor;

    Color originalReticleColor;

    GameObject currentProjectilePrefab;
    public GameObject gun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //originalReticleColor = reticleImage.color;
        currentProjectilePrefab = enemyBullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenuBehavior.isGamePaused)
        {
            if (gun.activeSelf && Input.GetButtonDown("Fire1") && !LevelManager.isGameOver)
            {
                GameObject projectile = Instantiate(currentProjectilePrefab, transform.position + transform.forward, transform.rotation) as GameObject;

                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);

                projectile.transform.SetParent(GameObject.FindGameObjectWithTag("ProjectileParent").transform);

                AudioSource.PlayClipAtPoint(shootSFX, transform.position);
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (!LevelManager.isGameOver) {
            //ReticleEffect();
        }
        
    }
}