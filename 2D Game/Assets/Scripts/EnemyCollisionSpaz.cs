using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyCollisionSpaz : MonoBehaviour
{
    private Vector3 startPosition;
    private SpriteRenderer sprRend;
    private SoundManager sm;
    private EndGameManager EGManager;

    void Start()
    {
        sm = SoundManager.Instance;
        startPosition = transform.position;
        sprRend = GetComponent<SpriteRenderer>();
        EGManager = EndGameManager.Instance;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit by: " + col.gameObject.name);
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Spell")
        {
            LivesText.livesRemaining -= 1;
            transform.position = startPosition;
            sm.PlaySoundEffect("Death");
            StartCoroutine(FlashSprites(sprRend, 10, 0.1f));
            if (LivesText.livesRemaining == 0)
            {
                EGManager.TriggerEndGame(Score.score);
            }

        }
    }
    IEnumerator FlashSprites(SpriteRenderer sprites, int numTimes, float delay, bool disable = false)
    {
        // number of times to loop
        for (int loop = 0; loop < numTimes; loop++)
        {
            // cycle through all sprites
            if (disable)
            {
                // for disabling
                sprites.enabled = false;
            }
            else
            {
                // for changing the alpha
                sprites.color = new Color(sprites.color.r, sprites.color.g, sprites.color.b, 0.5f);
            }

            // delay specified amount
            yield return new WaitForSeconds(delay);

            // cycle through all sprites
            if (disable)
            {
                // for disabling
                sprites.enabled = true;
            }
            else
            {
                // for changing the alpha
                sprites.color = new Color(sprites.color.r, sprites.color.g, sprites.color.b, 1);
            }

            // delay specified amount
            yield return new WaitForSeconds(delay);
        }
    }
}
