using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeping : MonoBehaviour
{
    public float scale;
    AudioSource audioSource;
    float timer;
    public float MAX;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Adjust the frequency and pitch of the pinging sound the closer the player is to an angler fish
        timer += Time.deltaTime;
        Vector3 angler = GameObject.FindGameObjectWithTag("AnglerFish").transform.position;
        Vector3 player = this.transform.position;

        float dist = Mathf.Sqrt(Mathf.Pow(angler.x-player.x,2)+Mathf.Pow(angler.y-player.y,2)+Mathf.Pow(angler.z-player.z,2));
        audioSource.pitch = 3 * (MAX - dist) / MAX;

        if (timer*scale >= dist)
        {
            audioSource.Play(0);
            timer = 0;
        }
    }

}
