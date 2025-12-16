using System.Collections;
using UnityEngine;

public class KillBorder : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Rigidbody2D Rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn() // Respawns the player and freezes their movement to allow readjustment and prevent clipping
    {
        Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        Player.transform.position += new Vector3(-2, 5, 0);
        yield return new WaitForSeconds(1);
        Rigidbody.constraints = RigidbodyConstraints2D.None;
        Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
