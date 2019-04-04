using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastASpell : MonoBehaviour
{

    private Animator anim;
    [SerializeField] private Transform spawnTransform;

    [SerializeField] private GameObject spawnObject;
    private SoundManager sm;

	// Use this for initialization
	void Start ()
    {
        sm = SoundManager.Instance;
        anim = GetComponent<Animator>();
        sm.PlaySoundEffect("WitchCackle");
        StartCoroutine(CastSpellEveryFiveSeconds());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CastSpellEveryFiveSeconds()
    {
        while (true)
        {
            if (Damage.Health > 0)
            {
                anim.SetTrigger("CastSpell");
                yield return new WaitForSeconds(1.333f);
                Instantiate(spawnObject, spawnTransform.position, spawnTransform.rotation);
                yield return new WaitForSeconds(5);
            }

            yield return null;
        }
    }

    void PlaySpellSound()
    {
        sm.PlaySoundEffect("SpellCast");
    }
}
