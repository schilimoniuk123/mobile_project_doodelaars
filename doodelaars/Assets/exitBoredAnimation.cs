using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitBoredAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public void ExitBored()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isBored", false);
    }
}
