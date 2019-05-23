using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource SEaudio;
    Rigidbody rbody;
    const float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        SEaudio = GetComponent<AudioSource>();
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SEaudio.Play();
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        var mov = new Vector3(x, 0, y);

        if (mov.magnitude > 0)
        {
            mov.Normalize();
            
        }
        rbody.velocity = mov * speed;
    }
}
