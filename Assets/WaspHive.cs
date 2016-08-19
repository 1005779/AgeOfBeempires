using UnityEngine;
using System.Collections;

public class WaspHive : MonoBehaviour {

    public float timer = 10;
    public GameObject Wasp;
    public GameObject spawn;
    public Vector3 SpawnLocation;

    float health = 40;

	// Use this for initialization
	void Start () {
        SpawnLocation = spawn.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
            Destroy(this.gameObject);
	
	}

    public void Spawn()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(Wasp, SpawnLocation, transform.rotation);
            timer = 10;
        }
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage * Time.deltaTime;
    }
}
