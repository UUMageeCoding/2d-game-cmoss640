using TMPro;
using UnityEngine;

public class ThrowingWeapons : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the hammer prefab
    public Transform firePoint;   // Reference to the throwpoint
    public float bulletSpeed = 20f; // Speed of the hammer
    [SerializeField] GameObject AimIndicator;
    [SerializeField] TextMeshProUGUI HammerCountUI;
    public static int HammerCount = 30;


    private void Awake()
    {
        HammerCountUI.text = "x" + HammerCount.ToString(); // Update the amount of held hammers on the UI
    }

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
            if  (HammerCount >= 1) //  Prevents throwing hammers if the player has none
            {
                Shoot();
                HammerCount -= 1;
            }
        }

        HammerCountUI.text = "x" + HammerCount.ToString(); // Update the amount of held hammers on the UI
    }

    void Aim()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ignore the Z-axis

        // Calculate the direction to the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the throw indicator to face the mouse position
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot()
    {
        // Hammer spawns at throwpoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Calculate the throw direction from the throwpoint to the mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ignore the Z-axis
        Vector2 shootDirection = (mousePosition - firePoint.position).normalized;

        // Hammer throw speed
        rb.linearVelocity = shootDirection * bulletSpeed;

        
    }
}