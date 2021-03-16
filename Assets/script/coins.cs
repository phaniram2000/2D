using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coins : MonoBehaviour
{
    public GameObject coins_prefab;
    public TextMeshProUGUI coin_score;
    private float score;
    private AudioSource coin_audio;
    public AudioClip coin;
    private void Start()
    {
        score = 0;
        coin_audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coins"))
        {
            
            score = score + 1;
            coin_audio.PlayOneShot(coin, 1.0f);
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        coin_score.text = " " + score.ToString();
    }
    
}
