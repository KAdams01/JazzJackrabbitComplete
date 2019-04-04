using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private SoundManager sm;
    public int jumpForce;

	// Use this for initialization
	void Start ()
    {
        sm = SoundManager.Instance;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            sm.PlaySoundEffect("Jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
