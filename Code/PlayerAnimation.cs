using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anime;
    public bool isPlayer, isField, isBall, isGK;
    public int state;
    public bool isCurrent;
    public int stage = 0;
    public float timer;
    public int durection;


    public Vector3 PlayerP;
    public Quaternion PlayerR;

    public Vector3 PlayerP0;
    public Quaternion PlayerR0;
    public Vector3 PlayerPShot;

    public Vector3 ballPos, ballPos1, ballPos2;

    // Use this for initialization
    void Start()
    {
        timer = 10.0f;
        state = 0;
        anime = GetComponent<Animator>();

        PlayerR = Quaternion.Euler(-11.5f, 1f, 179.1f);
        PlayerP = new Vector3(0f, 180f, 0f);
        
        PlayerR0 = Quaternion.Euler(0f, 180f, 0f);
        PlayerP0 = new Vector3(0f, 1f, -64.9f);

        PlayerPShot = new Vector3(0f, -3.81f, -137.82f);
        ballPos1 = new Vector3(-1.99f, 1.3f, 210.94f);
        ballPos2 = new Vector3(-1.99f, 11.19545f, 196.22f);
        if (isGK)
        {
            anime.SetBool("isGK", true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Animating(h, v);
    }
    void Animating(float h, float v)
    {


        bool moving = h != 0f || v != 0f;

        if (state == 0)
        {
            stage = 0;
            if (isPlayer)
            {

                if (isCurrent)
                {

                    anime.SetBool("IsWalking", moving);

                }

            }
            else if(!isBall)
            {

                anime.enabled = moving;

                if (!isField)
                {
                    if (h > 0 && anime.GetFloat("Nspeed") < 0)
                    {
                        anime.SetFloat("Nspeed", +1f);

                    }
                    if (h < 0 && anime.GetFloat("Nspeed") > 0)
                    {
                        anime.SetFloat("Nspeed", -1f);
                    }
                }
                else
                {
                    if (v > 0 && anime.GetFloat("Nspeed") > 0)
                    {

                        anime.SetFloat("Nspeed", -1f);

                    }
                    if (v < 0 && anime.GetFloat("Nspeed") < 0)
                    {
                        anime.SetFloat("Nspeed", +1f);
                    }
                }
            }
            else
            {
               anime.SetBool("moving", moving);
            }
        }
        if (state == 1)
        {
            if (isBall)
            {
                anime.SetBool("moving", false);
            }
        }
        if (state == 2)
        {
            if (isPlayer)
            {

                if (isCurrent)
                {
                    anime.SetBool("IsWalking", false);
                }


            }
            else if(!isBall)
            {

                anime.enabled = false;


            }
            else
            {
                anime.SetBool("moving", false);
            }
        }
        //SHOT
        if (state == 5)
        {

            if(stage == -1)
            {
                if (isPlayer && isCurrent)
                {
                    anime.SetBool("powerUp", true);
                }
                timer = 0.11f;
                stage = -2;
            }
            if (stage == -2)
            {
                if (timer <= Time.deltaTime)
                {
                    if (isPlayer && isCurrent)
                    {
                        anime.SetBool("powerUp0", true);
                        anime.SetBool("powerUp", false);

                    }
                    timer = 2.0f;
                    stage = -3;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
            if (stage == -3)
            {
                if (timer <= Time.deltaTime)
                {
                    if (isPlayer && isCurrent)
                    {
                        anime.SetBool("powerUp1", true);
                        anime.SetBool("powerUp0", false);

                    }
                    timer = 0.17f;
                    stage = -4;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
            if (stage == -4)
            {
                if (timer <= Time.deltaTime)
                {
                    if (isPlayer && isCurrent)
                    {
                        anime.SetBool("powerUp2", true);
                        anime.SetBool("powerUp1", false);

                    }
                    timer = 2.0f;
                    stage = -5;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
            if (stage == -5)
            {
                if (timer <= Time.deltaTime)
                {
                    if (isPlayer && isCurrent)
                    {
                        anime.SetBool("powerUp2", false);

                    }
                    
                    stage = 0;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }

            if (stage == 0)
            {
                timer = 5.0f;
                stage = 1;
            }
            if (stage == 1)
            {
                if (isPlayer)
                {
                    anime.SetBool("IsWalking", true);
                    anime.SetBool("shot0", true);
                }
                if (timer <= Time.deltaTime)
                {
                    if (isPlayer)
                    {
                        anime.SetBool("shot1", true);
                    }
                    stage = 2;
                    timer = 0.16f;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }

            if (stage == 2)
            {
                if (timer <= 0)
                {
                    if (isPlayer)
                    {
                        anime.SetBool("shot2", true);
                    }
                    stage = 3;
                    timer = 0.16f;
                }
                else
                {
                    timer -= Time.deltaTime;
                }

            }
            if (stage == 3)
            {
                if (timer <= 0)
                {
                    if (isPlayer)
                    {
                        anime.SetBool("shot3", true);
                    }
                    if (isBall)
                    {
                        anime.SetBool("spin", true);
                        

                    }
                    stage = 4;
                    timer = 1.0f;
                }
                else
                {
                    timer -= Time.deltaTime;
                }

            }
            if (stage == 4)
            {
                if (timer <= 0)
                {
                    if (isBall)
                    {
                        transform.position = Vector3.Lerp(transform.position, ballPos2, 6f * Time.deltaTime);
                    }
                }
                else
                {
                    if (isBall)
                    {

                        //transform.position = Vector3.Lerp(transform.position, ballPos1, 1f * Time.deltaTime);
                        transform.position = Vector3.Lerp(transform.position, ballPos2, 2f * Time.deltaTime);
                    }
                    timer -= Time.deltaTime;
                }
                if (isPlayer && isCurrent)
                {
                    transform.position = Vector3.Lerp(transform.position, PlayerPShot, .1f * Time.deltaTime);

                }
                if (isField)
                {
                    anime.enabled = true;

                    anime.SetFloat("Nspeed", .5f);
                }

            }




        }
        if (state == 3 || state == 4)
        {
            if (isPlayer)
            {
                anime.SetBool("IsWalking", true);
                if (stage == 0)
                {
                    timer = 6f;
                    stage = 1;

                }
                if (stage == 1)
                {
                    if (timer > 0)
                    {
                        timer -= Time.deltaTime;
                    }
                    else
                    {
                        if (!isCurrent)
                        {
                            anime.SetBool("tackle", true);

                        }
                        timer = 0.20f;
                        stage = 2;
                    }
                }
                if (stage == 2)
                {
                    if (timer > 0)
                    {
                        timer -= Time.deltaTime;
                    }
                    else
                    {
                        if (!isCurrent)
                        {
                            anime.SetBool("tackle0", true);

                        }
                        timer = 1f;
                        stage = 3;
                    }
                }
                if (stage == 3)
                {
                    if (timer > 0)
                    {
                        timer -= Time.deltaTime;
                    }
                    else
                    {
                        if (isCurrent)
                        {
                            anime.SetBool("m7wrh", true);
                        }

                        stage = 4;
                        timer = 1.0f;
                    }
                }
                if (stage == 4)
                {
                    if (!isCurrent)
                    {
                        transform.position = Vector3.Lerp(transform.position, PlayerP0, 1f * Time.deltaTime);
                        transform.rotation = Quaternion.Slerp(transform.rotation, PlayerR0, Time.deltaTime * 1f);
                    }
                    if (timer > 0)
                    {
                        timer -= Time.deltaTime;
                    }
                    else
                    {
                        anime.SetBool("m7wrh", false);
                    }
                }
            }

            else if(!isBall)
            {
                anime.enabled = true;


            }
            else
            {
                anime.SetBool("moving", true);

            }

        }


        if (state == 99 || state == 97)
        {
            if (isPlayer)
            {

                if (isCurrent)
                {
                    anime.SetBool("IsWalking", true);
                }

            }
            else if(!isBall)
            {

                anime.enabled = true;

                if (!isField)
                {
                    if (h > 0 && anime.GetFloat("Nspeed") < 0)
                    {
                        anime.SetFloat("Nspeed", +1f);
                    }
                    if (h < 0 && anime.GetFloat("Nspeed") > 0)
                    {
                        anime.SetFloat("Nspeed", -1f);
                    }
                }
                else
                {
                    if (durection == 1)
                    {
                        anime.SetFloat("Nspeed", -1f);
                    }
                    if (durection == 0)
                    {
                        anime.SetFloat("Nspeed", +1f);
                    }
                }
            }
            else
            {
                anime.SetBool("moving", true);

            }
        }



    }
    public void setState(int i)
    {
        state = i;
    }
    public int getState()
    {
        return state;
    }
    public void setCurrent(bool h)
    {
        isCurrent = h;
    }

}
