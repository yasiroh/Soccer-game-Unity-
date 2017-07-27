using UnityEngine;

using System.Collections;

public class MenuC : MonoBehaviour {

    public float smothing = 50f;
    public bool menuAction, ml3b;
    public GameObject textObj, textObj2;
    public TextMesh text,text2;



    private int state;
    public Vector3 CameraP, CameraP2 , CameraP3, CameraP4, CameraP5, textP,textP2, textP3;

  


    // Use this for initialization
    void Start () {
        CameraP = new Vector3(255.3575f, 104.3f, 30f);
        CameraP2 = new Vector3(250.6f, 104.9005f, 36.3f);
        CameraP3 = new Vector3(255.3575f, 93.31073f, 30.04414f);
        CameraP4 = new Vector3(232f, 104.9005f, 17.60842f);
        CameraP5 = new Vector3(266.91f, 107.16f, 35.1f);

        textP = new Vector3(254.07f, 105.65f, 27.53f);
        textP2 = new Vector3(248.26f, 108.15f, 34.97f);
        textP3 = new Vector3(265.52f, 112.14f, 36.87f);

        state = 0;
        textObj = new GameObject();
        text = textObj.AddComponent<TextMesh>();
        
        text.fontSize = 100;
        text.lineSpacing = 1.5f;
        if (menuAction)
        {
            textObj.transform.position = textP;
            textObj.transform.localScale = new Vector3(0.08121814f, 0.06145653f, 1f);
            text.color = Color.yellow;

        }
        else if (!ml3b)
        {
            textObj.transform.position = textP2;
            textObj.transform.localScale = new Vector3(0.08121814f, 0.06145653f, 1f);
            text.color = Color.yellow;


        }
        else
        {

            text.lineSpacing = 0.7f;
            textObj.transform.position = textP3;
            textObj2 = new GameObject();
            textObj2.transform.position = textP3;

            text2 = textObj2.AddComponent<TextMesh>();
            text2.fontSize = 100;
            text2.lineSpacing = 0.7f;
            text2.color = Color.red;
            
            textObj.transform.localScale = new Vector3(0.04325687f, 0.04039292f, 0.01042466f);
            textObj2.transform.localScale = new Vector3(0.04325687f, 0.04039292f, 0.01042466f);
            textObj2.transform.rotation = transform.rotation;


        }
        textObj.transform.rotation = transform.rotation;
        
        



    }

    // Update is called once per frame
    void Update()
    {



        if (state == 1 || state == 2)
        {
            if (menuAction)
            {
                transform.position = Vector3.Lerp(transform.position, CameraP, smothing * Time.deltaTime);
                textObj.transform.position = textP;
            }

        }

        if (state == 0)
        {
            if (menuAction)
            {
                transform.position = Vector3.Lerp(transform.position, CameraP3, smothing * Time.deltaTime);
                textObj.transform.position = Vector3.Lerp(transform.position, CameraP3, smothing * Time.deltaTime);
            }
            else if (!ml3b)
            {

                transform.position = Vector3.Lerp(transform.position, CameraP2, smothing * Time.deltaTime);
                textObj.transform.position = textP2;


            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, CameraP5, smothing * Time.deltaTime);
                textObj.transform.position = textP3;
                textObj2.transform.position = textP3;

            }

        }

        if (state == 3 || state == 4)
        {
            transform.position = Vector3.Lerp(transform.position, CameraP3, smothing * Time.deltaTime);
            textObj.transform.position = CameraP3;
            if (!menuAction && ml3b)
            {
                textObj2.transform.position = CameraP3;

            }
        }
        if (state == 5)
        {
            transform.position = Vector3.Lerp(transform.position, CameraP3, smothing * Time.deltaTime);
            textObj.transform.position = CameraP3;
            if (!menuAction && ml3b)
            {
                textObj2.transform.position = CameraP3;

            }

        }


    }
    public int getState()
    {
        return state;
    }
    public void setState(int s)
    {
        state = s;
    }
}
