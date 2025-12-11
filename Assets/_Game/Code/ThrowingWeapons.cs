using TMPro;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform firePoint;   // Reference to the fire point
    public float bulletSpeed = 20f; // Speed of the bullet
    [SerializeField] GameObject AimIndicator;
    [SerializeField] TextMeshProUGUI HammerCountUI;
    private int HammerCount = 30;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Aim();
            AimIndicator.SetActive(true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            AimIndicator.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1)) // Throw weapon
        {
            if  (HammerCount >= 1)
            {
                Shoot();
                HammerCount -= 1;
                HammerCountUI.text = "x" + HammerCount.ToString();
            }
        }
    }

    void Aim()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ignore the Z-axis

        // Calculate the direction to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the gun to face the mouse position
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot()
    {
        // Instantiate the bullet at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Calculate the shoot direction from the fire point to the mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ignore the Z-axis
        Vector2 shootDirection = (mousePosition - firePoint.position).normalized;

        // Set bullet velocity in the direction of the mouse position
        rb.linearVelocity = shootDirection * bulletSpeed;

        
    }
}