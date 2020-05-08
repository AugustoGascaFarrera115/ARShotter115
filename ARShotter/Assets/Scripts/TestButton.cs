using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{

    public Image fillWaitImage_1;


    private int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0 };

    private Animator animator;
    private bool canAttack = true;
    public Animation animation;

    private PlayerController playerMove;
    public void TurnOnPower2(Animator anim)
    {

        anim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerController>();
        animation = GetComponent<Animation>();


        if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        CheckToFade();
        CheckInput();


    }


    public void CheckInput()
    {
        if (animator.GetInteger("Atk") == 0)
        {
            playerMove.FinishedMovement = false;

            if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                playerMove.FinishedMovement = true;
            }

        }

       
            playerMove.TargetPosition = transform.position;


            //fade images 0 meaning image thats at index 0 e.g the first image
            if (playerMove.FinishedMovement && fadeImages[0] != 1 && canAttack)
            {
                fadeImages[0] = 1;
                animator.SetInteger("Atk", 1);
            }

        //{
        //    animator.SetInteger("Atk", 0);
        //}


        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 targetPosition = Vector3.zero;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;

            if (Physics.Raycast(ray, out rayHit))
            {
                targetPosition = new Vector3(rayHit.point.x, transform.position.y, rayHit.point.z);
            }


            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPosition - transform.position), 15f * Time.deltaTime);

        }


    } //check input



    bool FadeAndWait(Image fadeImage, float fadeTime)
    {
        bool faded = false;


        if (fadeImage == null)
            return faded;

        if (!fadeImage.gameObject.activeInHierarchy)
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.fillAmount = 1f;
        }

        fadeImage.fillAmount -= fadeTime * Time.deltaTime;


        if (fadeImage.fillAmount <= 0.0f)
        {
            fadeImage.gameObject.SetActive(false);
            faded = true;
        }

        return faded;
    }

    private void CheckToFade()
    {
        if (fadeImages[0] == 1)
        {
            if (FadeAndWait(fillWaitImage_1, 15.0f))
            {
                fadeImages[0] = 0;
            }
        }


    }
}
