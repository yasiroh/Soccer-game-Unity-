using UnityEngine;
using System.Collections;

public class CameraPos : MonoBehaviour {
    public float smothing = 1f;
    public  float timer = 10.0f;
    public int state = 0;
    public int stage = 0;

    public Vector3 CameraP;
    public Vector3 CameraP2;
    public Vector3 CameraP3, vsPosP, vsPosP0, vsPosP1, powerUpP, powerUpP1, powerUpP2;
    public Vector3 CameraP4;
    public Vector3 CameraP5;
    public Vector3 CameraP6;
    public Vector3 CameraP7;


    public Quaternion CameraR;
    public Quaternion CameraR2;
    public Quaternion CameraR3, vsPosR, vsPosR0, vsPosR1, powerUpR, powerUpR2;
    public Quaternion CameraR4;
    public Quaternion CameraR5;
    public Quaternion CameraR6;
    public Quaternion CameraR7;








    void Start ()
    {
        //
        vsPosR = Quaternion.Euler(0.072f, 725.97f, 2.599f);
        vsPosR0 = Quaternion.Euler(11.349f, 366.816f, -3.641f);
        vsPosR1 = Quaternion.Euler(0.923f, 264.41f, -2.61f);


        vsPosP = new Vector3(-4.5f, 7.4f, -7.8f);
        vsPosP0 = new Vector3(-14.3f, 9.1f, 151.1f);
        vsPosP1 = new Vector3(52.5f, 8.1f, 47.1f);

        //
        powerUpP = new Vector3(0f, 8.46f, 18.27f);
        powerUpP1 = new Vector3(0f, 8.46f, 14.41f);
        powerUpP2 = new Vector3(0f, 16.42f, 29.96f);

        powerUpR = Quaternion.Euler(0f, 180f, 0f);
        powerUpR2 = Quaternion.Euler(25.668f, 180f, 0f);




        //shot rotation
        CameraR4 = Quaternion.Euler(14.592f, -446.333f, -10.448f);
        //CameraR5 = Quaternion.Euler(-0.693f, 170.76f, 4.366f);
        CameraR5 = Quaternion.Euler(-0.6850001f, 171f, 4.241f);
        CameraR6 = Quaternion.Euler(15.922f, 207.069f, 28.24f);
        CameraR7 = Quaternion.Euler(8.695001f, 52.901f, -34.511f);


        CameraR3 = Quaternion.Euler(-1.619f, 174.25f, -3.162f);
        CameraR2 = Quaternion.Euler(4.27144f, 161.1334f, 4.996613f);
        CameraR = Quaternion.Euler(9.2926f, 219.4501f, 1.2271f);

        
        CameraP4 = new Vector3(10.3f, 11.7f, 4f);
        //CameraP5 = new Vector3(-1f, 12.00001f, 149.9995f);
        CameraP5 = new Vector3(-1f, 12f, 194.8f);
        CameraP6 = new Vector3(1f, 21.5f, 25.5f);
        CameraP7 = new Vector3(-27.2f, 3.9f, -13.6f);


        CameraP3 = new Vector3(-6.5f, 12f, 189.5f);
        CameraP2 = new Vector3(-10.1f, 8.7f, 22.6f);
        CameraP = new Vector3(10.1f, 8.7f, 22.6f);

    }
	
	// Update is called once per frame
	void Update ()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (state == 0 || state == 99)
        {
            stage = 0;
            timer = 10.0f;
            if (h > 0)
            {
                transform.position = Vector3.Lerp(transform.position, CameraP, smothing * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, CameraR, Time.deltaTime * smothing);
            }
            if (h < 0)
            {
                transform.position = Vector3.Lerp(transform.position, CameraP2, smothing * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, CameraR2, Time.deltaTime * smothing);
            }
        }
        if(state == 1)
        {

        }
        if(state == 2)
        {
             transform.position = Vector3.Lerp(transform.position, CameraP3, smothing * Time.deltaTime);
             transform.rotation = Quaternion.Slerp(transform.rotation, CameraR3, Time.deltaTime * smothing);
            
        }
        //BATTLE STATE
        if(state == 3 || state ==  4)
        {
            if (stage == 0)
            {
                transform.position = CameraP;
                transform.rotation = CameraR;
                stage = 1;
                timer = 3.0f;
            }
            if (stage == 1)
            {
                if (timer > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, vsPosP, 0.5f * Time.deltaTime);
                    transform.rotation = Quaternion.Slerp(transform.rotation, vsPosR, Time.deltaTime * 0.5f);
                    timer -= Time.deltaTime;
                }
                else
                {
                    stage = 2;
                    timer = 3.7f;
                }
            }
            if(stage == 2)
            {
                if (timer > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, vsPosP0, 1f * Time.deltaTime);
                    transform.rotation = Quaternion.Slerp(transform.rotation, vsPosR0, Time.deltaTime * 1f);
                    timer -= Time.deltaTime;
                }
                else
                {
                    stage = 3;

                }
            }
            if (stage ==3)
            {
                transform.position = Vector3.Lerp(transform.position, vsPosP1, 2f * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, vsPosR1, Time.deltaTime * 2f);
            }
        }
        //SHOT STATE
        if (state == 5)
        {
            if (stage == -1)
            {
                transform.position = powerUpP;
                transform.rotation = powerUpR;

                timer = 2.0f;
                stage = -2;
            }
            else if (stage ==-2)
            {
                if (timer <= Time.deltaTime)
                {
                    timer = 2.28f;
                    stage = -3;
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, powerUpP1, .5f * Time.deltaTime);
                    timer -= Time.deltaTime;
                }
            }
            else if (stage == -3)
            {
                if (timer <= Time.deltaTime)
                {
                    timer = 5.0f;
                    stage = 0;
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, powerUpP2, 2f * Time.deltaTime);
                    transform.rotation = Quaternion.Slerp(transform.rotation, powerUpR2, Time.deltaTime * 2f);
                    timer -= Time.deltaTime;
                }
            }
            else 
            {

                if (timer <= Time.deltaTime)
                {
                    transform.position = Vector3.Lerp(transform.position, CameraP5, 5.0f * Time.deltaTime);
                    transform.rotation = Quaternion.Slerp(transform.rotation, CameraR5, Time.deltaTime * 5.0f);

                }
                else
                {
                    if (stage == 0)
                    {
                        transform.position = CameraP7;
                        transform.rotation = CameraR7;
                        stage = 1;
                    }
                    if (timer <= 2.5f && stage == 1)
                    {
                        transform.position = CameraP6;
                        transform.rotation = CameraR6;
                        stage = 2;
                    }

                    transform.position = Vector3.Lerp(transform.position, CameraP4, 1f * Time.deltaTime);
                    transform.rotation = Quaternion.Slerp(transform.rotation, CameraR4, Time.deltaTime * 1f);

                    timer -= Time.deltaTime;
                }
            }
            
        }
        if(state == 97)
        {
            transform.position = Vector3.Lerp(transform.position, CameraP, smothing * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, CameraR, Time.deltaTime * smothing);
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
}
