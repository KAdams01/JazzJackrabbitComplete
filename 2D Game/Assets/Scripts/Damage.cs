using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    private Animator anim;
    private SoundManager sm;
    private bool alive;
    private EndGameManager EGManager;

    [SerializeField] public static float Health { get; private set; }
	// Use this for initialization
	void Start ()
    {
        sm = SoundManager.Instance;
        EGManager = EndGameManager.Instance;
        anim = GetComponent<Animator>();
        Health = 50;
        alive = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //if hit by a projectile, lose health and play a sound
        if (col.gameObject.tag == "Projectile")
        {
            Health -= 10;
            sm.PlaySoundEffect("WitchDamage");
        }
    }

    void Update()
    {
        if (Health <= 0)
        {
            anim.SetBool("isEnabled", false);
            //to fix a bug with sound playing many times
            if (alive)
            {
                sm.PlaySoundEffect("WitchDeath");
            }
            //Destroys the game object after death animation
            StartCoroutine(DestroyAfterDeathAnimation());
            alive = false;
        }
    }
    //temporary sub routine. Could be replaces with one that takes time as argument
    IEnumerator DestroyAfterDeathAnimation()
    {
        yield return new WaitForSeconds(3.25f);
        Destroy(gameObject);
        EGManager.TriggerEndGame(Score.score);
    }
}
