using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour {

    [SerializeField]
    private CameraFollow cf;
    private PlayerController pc;
    private Animator anim;

	// Use this for initialization
	void Start () {
        pc = gameObject.GetComponent<PlayerController>();
        anim = gameObject.GetComponentInChildren<Animator>();
	}
	
	public void Activate () {
        StartCoroutine(PlayScene());
	}

    IEnumerator PlayScene()
    {
        yield return new WaitForSeconds(0.5f);
        cf.enabled = false;
        yield return new WaitForSeconds(1.0f);
        pc.moving = false;
        anim.SetBool("transform", true);
        int lev = anim.GetInteger("level");
        anim.SetInteger("level", lev + 1);
        yield return new WaitForEndOfFrame();
        anim.SetBool("transform", false);
    }
}
