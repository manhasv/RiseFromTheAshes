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
        
        if (gun.activeSelf && Input.GetButtonDown("Fire1") && !LevelManager.isGameOver)
        {
            GameObject projectile = Instantiate(currentProjectilePrefab, transform.position + transform.forward, transform.rotation) as GameObject;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);

            projectile.transform.SetParent(GameObject.FindGameObjectWithTag("ProjectileParent").transform);

            AudioSource.PlayClipAtPoint(shootSFX, transform.position);
        }
    }

    private void FixedUpdate()
    {
        if (!LevelManager.isGameOver) {
            //ReticleEffect();
        }
        
    }

    // void ReticleEffect()
    // {
    //     RaycastHit hit;

    //     if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
    //     {
    //         if (hit.collider.CompareTag("Enemy"))
    //         {
    //             currentProjectilePrefab = enemyBullet;

    //             reticleImage.color = Color.Lerp(reticleImage.color, projectileColor, 2 * Time.deltaTime);
    //             reticleImage.transform.localScale = Vector3.Lerp(reticleImage.transform.localScale, new Vector3(0.7f, 0.7f, 1), 2 * Time.deltaTime);
    //         }
    //         else if (hit.collider.CompareTag("Interactable"))
    //         {
    //             currentProjectilePrefab = objBullet;

    //             reticleImage.color = Color.Lerp(reticleImage.color, diffuserColor, 2 * Time.deltaTime);
    //             reticleImage.transform.localScale = Vector3.Lerp(reticleImage.transform.localScale, new Vector3(0.7f, 0.7f, 1), 2 * Time.deltaTime);
    //         }
    //         else
    //         {
    //             currentProjectilePrefab = enemyBullet;

    //             reticleImage.color = Color.Lerp(reticleImage.color, originalReticleColor, 2 * Time.deltaTime);
    //             reticleImage.transform.localScale = Vector3.Lerp(reticleImage.transform.localScale, Vector3.one, 2 * Time.deltaTime);
    //         }
    //     }
    //     else
    //     {
    //         currentProjectilePrefab = enemyBullet;

    //         reticleImage.color = Color.Lerp(reticleImage.color, originalReticleColor, 2 * Time.deltaTime);
    //         reticleImage.transform.localScale = Vector3.Lerp(reticleImage.transform.localScale, Vector3.one, 2 * Time.deltaTime);
    //     }
    // }
}