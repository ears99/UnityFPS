using UnityEngine;

public class Gun : MonoBehaviour {
	//global variables
	public float damage = 10f;
	public float range = 100f;
	public float impactForce = 60f;
	public float fireRate = 15f;

	private float nextTimeToFire = 0f;
	//object references
	public Camera fpsCam;
	public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update() {
		if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire) {
			nextTimeToFire = Time.time + 1f / fireRate;
			Shoot();
		}
    }
	void Shoot() {
		//add the muzzle flash particle system to add a muzzle flash to the gun.
		muzzleFlash.Play();
		RaycastHit hit;
		//cast a ray starting from our camera, going forward, with the info stored in hit. Anything 
		//beyond 100 units will not be hit.
		if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
			//check to see if the ray hit a target
			//if we hit something, log it to the debug console.
			Debug.Log(hit.transform.name);

			//allow the target to take damage...
			Target target = hit.transform.GetComponent<Target>();
			//...but only do this if we found a Target component on the thing we want to take damage.
			if(target != null) {
				target.takeDamage(damage);
				}
			if(hit.rigidbody != null){
				hit.rigidbody.AddForce(-hit.normal * impactForce);
				}
			}
	}
}
