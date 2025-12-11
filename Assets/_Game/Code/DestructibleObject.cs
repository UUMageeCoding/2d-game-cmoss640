using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class DestructibleObject : MonoBehaviour

{

    public int MaxObjectHealth;
    public int CurrentObjectHealth;
    [SerializeField] private TextMeshPro HealthNumber;
    [SerializeField] GameObject DestroyParticle;
    [SerializeField] GameObject JuggleBonusText;
    [SerializeField] AudioSource SoundEffect;
    [SerializeField] AudioClip Clip;
    private Rigidbody2D rb;
    private Animator anim;
    private bool JuggleBonus = false;
    private int JuggleCounter = 4;

    

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
                Debug.Log("Juggle");
                Instantiate(JuggleBonusText, transform.position, Quaternion.Euler(0f, 0f, 0f));
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
            PlatformerController.Score += 5;
            Destroy(gameObject);
            SoundEffect.clip = Clip;
            SoundEffect.Play();
        }
    }
}
