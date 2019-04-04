using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnEnemy;
    private GameObject objectToChase;
    [SerializeField]
    private float speed;

    private SoundManager sm;

    private Vector2 direction;
	// Use this for initialization
	void Start ()
    {
        sm = SoundManager.Instance;
        objectToChase = GameObject.FindWithTag("Player");
        if (objectToChase == null)
        {
            Destroy(gameObject);
        }

        StartCoroutine(DestroyAfterTenSeconds());

    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(objectToChase.transform.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        sm.PlaySoundEffect("RocketEnd");
        if (col.gameObject.tag == "Ground")
        {
            var impactPoint = new Vector2(col.contacts[0].point.x, col.contacts[0].point.y+0.25f);
            
            SpawnEnemy(impactPoint);
        }
        Destroy(gameObject);
    }

    IEnumerator DestroyAfterTenSeconds()
    {
        
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    void SpawnEnemy(Vector2 location)
    {
        Instantiate(spawnEnemy, location, Quaternion.identity);
    }
}
