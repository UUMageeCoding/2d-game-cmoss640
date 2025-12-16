using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class DestructibleObject : MonoBehaviour

{

    public int MaxObjectHealth;
    public int CurrentObjectHealth;
    public int Reward;
    [SerializeField] private TextMeshPro HealthNumber;
    [SerializeField] GameObject DestroyParticle;
    [SerializeField] GameObject JuggleBonusText;
    [SerializeField] AudioSource SoundEffect;
    [SerializeField] GameObject DestructionSound;
    [SerializeField] GameObject Pickup;
    private Rigidbody2D rb;
    private Animator anim;
    private bool JuggleBonus = false;
    private int JuggleCounter = 4;
    private int PickupChance;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentObjectHealth <= 0)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            JuggleBonus = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            CurrentObjectHealth -= 30;
            anim.SetTrigger("Struck");
            anim.SetTrigger("Reset");

            SoundEffect.pitch = Random.Range(0.8f, 1.2f);
            SoundEffect.Play();

            if (JuggleBonus == true)
            {
                Instantiate(JuggleBonusText, transform.position, Quaternion.Euler(0f, 0f, 0f));
                Destroy(JuggleBonusText, 2);
                PlatformerController.Score += 2;
                Debug.Log(PlatformerController.Score);
                JuggleCounter -= 1;
                if (JuggleCounter <= 0)
                {
                    Explode();
                }
            }

        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Explode();
        }

    void Explode()
        {
            Instantiate(DestroyParticle, transform.position, transform.rotation);
            PlatformerController.Score += Reward;
            Destroy(gameObject);
            Instantiate(DestructionSound, transform.position, transform.rotation);

            PickupChance = Random.Range(1, 2);
            if (PickupChance == 1)
            {
                Instantiate(Pickup, transform.position, transform.rotation);
            }
        }
    }
}
