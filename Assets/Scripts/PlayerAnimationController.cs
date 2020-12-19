using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ResetAnims();
        IdleAnim();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetAnims()
    {
        animator.StopPlayback();
    }

    public void JogAnim()
    {
        ResetAnims();
        animator.Play("Jog");
    }
    public void ThrowAnim()
    {
        ResetAnims();
        animator.Play("Throw");
    }
    public void IdleAnim()
    {
        ResetAnims();
        animator.Play("Idle");
    }


}
