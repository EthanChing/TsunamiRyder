using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    Animator CharacterStates;

    
	// Use this for initialization
	void Start () {
        CharacterStates = GetComponent<Animator>();
        CharacterStates.GetAnimatorTransitionInfo(0);
        CharacterStates.SetTrigger(Animator.StringToHash("DamageTrigger"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
