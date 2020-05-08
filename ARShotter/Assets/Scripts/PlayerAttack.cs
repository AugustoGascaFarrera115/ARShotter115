using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Image fillWaitImage_1;
    public Image fillWaitImage_2;
    public Image fillWaitImage_3;
    

    private int[] fadeImages = new int[] { 0, 0, 0 };

    private Animator animator;
    private bool canAttack = true;

    private PlayerController playerMove;


    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
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

    public  void CheckInput()
    {
        if (animator.GetInteger("Atk") == 0)
        {
            playerMove.FinishedMovement = false;

            if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                playerMove.FinishedMovement = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerMove.TargetPosition = transform.position;


            //fade images 0 meaning image thats at index 0 e.g the first image
            if (playerMove.FinishedMovement && fadeImages[0] != 1 && canAttack)
            {
                fadeImages[0] = 1;
                animator.SetInteger("Atk", 1);
            }

        }
        else if (Input.GetMouseButton(1))
        {
            if (playerMove.FinishedMovement && fadeImages[1] != 1 && canAttack)
            {
                fadeImages[1] = 1;
                animator.SetInteger("Atk", 2);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
           if(playerMove.FinishedMovement && fadeImages[2] != 1 && canAttack)
            {
                fadeImages[2] = 1;
                animator.SetInteger("Atk", 6);
            }
        }
        else
        {
            animator.SetInteger("Atk", 0);
        }


        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Vector3 targetPosition = Vector3.zero;

        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit rayHit;

        //    if (Physics.Raycast(ray, out rayHit))
        //    {
        //        targetPosition = new Vector3(rayHit.point.x, transform.position.y, rayHit.point.z);
        //    }


        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPosition - transform.position), 15f * Time.deltaTime);

        //}


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
            if (FadeAndWait(fillWaitImage_1, 0.5f))
            {
                fadeImages[0] = 0;
            }
        }

        if(fadeImages[1] == 1)
        {
            if(FadeAndWait(fillWaitImage_2,0.5f))
            {
                fadeImages[1] = 0;
            }
        }

        if(fadeImages[2] == 1)
        {
            if(FadeAndWait(fillWaitImage_3,0.5f))
            {
                fadeImages[2] = 0;
            }
        }
       
    }
}
