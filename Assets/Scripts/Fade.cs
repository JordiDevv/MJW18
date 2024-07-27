using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        Invoke("FadeOut", 10);
    }

    public void FadeOut()
    {
        animator.Play("FadeOut");
    }

    public void FadeIn()
    {
        animator.Play("FadeIn");
    }
}
