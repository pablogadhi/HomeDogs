using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Perro : MonoBehaviour
{
	public Animator anim;
	public GameObject cilindro;
	// Start is called before the first frame update
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemigo")
			cilindro.SendMessage("attack");
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Enemigo")
			cilindro.SendMessage("attack");
	}
	public void EstaAtacando()
	{
		anim.SetBool("isAttacking", true);
	}
	public void EstaParado()
	{
		anim.SetBool("isAttacking", false);
	}
}