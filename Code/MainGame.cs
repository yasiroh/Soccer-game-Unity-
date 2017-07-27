using UnityEngine;
using System.Collections;
using System.Timers;

public class MainGame : MonoBehaviour
{
    public GameObject test, test2;
    public GameObject vsRed, vsBlue,Up,Down;
    public GameObject field, stadum, mainCamera;
    public GameObject secondCamera;
    public GameObject menu1, menu2, ml3bMap;
    public GameObject ball;
    private GameObject currentModel, otherModel;
    public GameObject eff, ballEff;
    private Player currentPlayer, tempPlayer;
    private Team team1,team2, currentTeam, otherTeam;
    private AudioSource audioSource;
    public AudioClip Tclip17, Tclip18;
    public int state = 0;
    public int stage = 0;

    private Quaternion vsR1, vsR2, vsUpR, vsDownR;
    private Vector3 vsP1,vsP2, orgS,otherS, vsUpP, vsDownP, vsUpS,vsDownS;
    public int durection;
    
    public bool musicIsPlaying;
    private bool win;
    private Player[][] mapBoard = new Player[10][];

    public float oneS =1.0f;
    public float timer;


    void Awake()
    {


        durection = 0;
        //Positions
        vsP1 = new Vector3(9.3f, 493.9f, -13.2f);
        vsR1 = Quaternion.Euler(0f, -90f, 0f);
        orgS = new Vector3(7f, 7f, 7f);

        vsDownP = new Vector3(0f, 498.8f, -4.8f);
        vsDownR = Quaternion.Euler(180f, 0f, 0f);
        vsDownS = new Vector3(12.805f, 3.2773f, 0.2066f);

        vsUpP = new Vector3(0f, 508.1f, -29.2f);
        vsUpR = Quaternion.Euler(180f, 0f, 180f);
        vsUpS = new Vector3(79.90238f, 17.50422f, 1f);

        vsP2 = new Vector3(-2.46f, 496.32f, -3.04f);
        vsR2 = Quaternion.Euler(0f, 90f, 0f);
        otherS = new Vector3(2f, 2f, 2f);

        mapboaerIn();

        // Intliizing field, stadum, Cameras, Menus 
        field = Instantiate(field, field.transform.position, field.transform.rotation) as GameObject;
        stadum = Instantiate(stadum, stadum.transform.position, stadum.transform.rotation) as GameObject;
        mainCamera = Instantiate(mainCamera, mainCamera.transform.position, mainCamera.transform.rotation) as GameObject;
        secondCamera = Instantiate(secondCamera, secondCamera.transform.position, secondCamera.transform.rotation) as GameObject;
        menu1 = Instantiate(menu1, menu1.transform.position, menu1.transform.rotation) as GameObject;
        menu2 = Instantiate(menu2, menu2.transform.position, menu2.transform.rotation) as GameObject;
        ml3bMap = Instantiate(ml3bMap, ml3bMap.transform.position, ml3bMap.transform.rotation) as GameObject;


        //Players
        Player t1 = new Player("Shen", 9, 5, 10, 500, 10, 10, 10, 10, test);
        Player t2 = new Player("Azula", 10, 5, 11, 500, 10, 10, 10, 10, test2);
        currentPlayer = t1;
        currentPlayer.PlayerModel.GetComponent<PlayerAnimation>().setCurrent(true);
        t2.PlayerModel.GetComponent<PlayerAnimation>().setCurrent(false);

        //setting player info on the menu

        //Creating teams
        team1 = new Team();
        team1.addPlayer(t1);
        team1.setTeamMusic(Tclip18);
        currentTeam = team1;
        team1.teamColor = "Red";

        team2 = new Team();
        team2.addPlayer(t2);
        team2.setTeamMusic(Tclip17);
        team2.teamColor = "Blue";
        otherTeam = team2;


        //Music
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = currentTeam.getTeamMusic();
        if (musicIsPlaying)
        {
            audioSource.Play();
        }

        //team.setTeamMusic(audio17);

        //Setting Map Board
        mapBoard[currentPlayer.XPosition][currentPlayer.YPosition] = currentPlayer;
        mapBoard[t2.XPosition][t2.YPosition] = t2;

        //testing
        //otherModel = Instantiate(test2, test2.transform.position, test2.transform.rotation) as GameObject;
        currentModel = Instantiate(currentPlayer.PlayerModel, currentPlayer.PlayerModel.transform.position, currentPlayer.PlayerModel.transform.rotation) as GameObject;
        //otherModel = Instantiate(t2.PlayerModel, t2.PlayerModel.transform.position, t2.PlayerModel.transform.rotation) as GameObject;
        ball = Instantiate(ball, ball.transform.position, ball.transform.rotation) as GameObject;
        //change current player
        //Destroy(currentModel);
        //currentModel = Instantiate(test, transform.position, transform.rotation) as GameObject;
        //currentModel.transform.parent = transform;
        //currentModel = thisModel;

    }
    public MainGame()
    {

    }
    void Update()
    {


        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (state == 0)
        {
            ml3bMap.GetComponent<MenuC>().text.text = updateMap(team1);
            ml3bMap.GetComponent<MenuC>().text2.text = updateMap(team2);
            string temp = currentPlayer.Name + "\nPower:      " + currentPlayer.Power + "\nTackle\n";
            menu2.GetComponent<MenuC>().text.text = temp;
            if (h > 0)
            {


            }
            if (h < 0)
            {


            }
            if (v < 0)
            {
                if (canMove1("Down"))
                {
                    if (canMove2("Down"))
                    {
                        move("Down");
                        changeState(99, false);
                        durection = 0;
                        field.GetComponent<PlayerAnimation>().durection = durection;
                        stadum.GetComponent<PlayerAnimation>().durection = durection;

                    }
                    else
                    {
                        tempPlayer = canMove3("Down");

                        Vector3 PlayerP = new Vector3(-11.5f, 1f, 179.1f);

                        Quaternion PlayerR = Quaternion.Euler(0f, 180f, 0f);
                        otherModel = Instantiate(tempPlayer.PlayerModel, PlayerP, PlayerR) as GameObject;
                        changeState(2, true);



                    }
                }
                Quaternion R = Quaternion.Euler(0f, 0f, 0f);
                currentModel.transform.rotation = Quaternion.Slerp(currentModel.transform.rotation, R, Time.deltaTime * 5f);
                ball.transform.rotation = Quaternion.Slerp(ball.transform.rotation, R, Time.deltaTime * 5f);

            }
            if (v > 0)
            {

                if (canMove1("Up"))
                {
                    if (canMove2("Up"))
                    {
                        move("Up");
                        changeState(99, false);
                        durection = 1;
                        field.GetComponent<PlayerAnimation>().durection = durection;
                        stadum.GetComponent<PlayerAnimation>().durection = durection;

                    }
                    else
                    {
                        tempPlayer = canMove3("Up");
                        changeState(2, true);
                        Vector3 PlayerP = new Vector3(-11.5f, 1f, 179.1f);

                    }
                }
                Quaternion R2 = Quaternion.Euler(0f, 180f, 0f);
                currentModel.transform.rotation = Quaternion.Slerp(currentModel.transform.rotation, R2, Time.deltaTime * 5f);
                ball.transform.rotation = Quaternion.Slerp(ball.transform.rotation, R2, Time.deltaTime * 5f);

            }
            if (Input.GetKey("z"))
            {
                changeState(1, false);
            }

        }
        if (state == 1)
        {
            if (v > 0)
            {
                menu1.GetComponent<MenuC>().text.text = "\nContinue";
            }
            if (v < 0)
            {
                menu1.GetComponent<MenuC>().text.text = "\n1-2";
            }
            if (h > 0)
            {
                menu1.GetComponent<MenuC>().text.text = "\nShot";

            }
            if (h < 0)
            {
                menu1.GetComponent<MenuC>().text.text = "\nPass";

            }
            if (h == 0 && v == 0)
            {
                menu1.GetComponent<MenuC>().text.text = "\n-------------";

            }
            if (v > 0 && Input.GetKey("x"))
            {
                oneS = .5f;
                changeState(98, false);
            }
            if (h > 0 && Input.GetKey("x"))
            {
                timer = 2.5f;
                changeStage(-1);
                changeState(5, false);


            }
        }
        if (state == 2)
        {
            if (v > 0)
            {
                menu1.GetComponent<MenuC>().text.text = "\nContinue";
            }
            if (v < 0)
            {
                menu1.GetComponent<MenuC>().text.text = "\n1-2";
            }
            if (h > 0)
            {
                menu1.GetComponent<MenuC>().text.text = "\nShot";

            }
            if (h < 0)
            {
                menu1.GetComponent<MenuC>().text.text = "\nPass";

            }
            if (h == 0 && v == 0)
            {
                menu1.GetComponent<MenuC>().text.text = "\n-------------";

            }
            if (v > 0 && Input.GetKey("x"))
            {
                changeState(3, true);
            }
        }
        if (state == 3)
        {
            timer = 12.0f;
            win = tackle();
            changeState(4, true);
        }
        if (state == 4)
        {
            if (timer <= Time.deltaTime)
            {
                int x, y, tempX, tempY;

                x = currentPlayer.XPosition;
                y = currentPlayer.YPosition;
                tempX = tempPlayer.XPosition;
                tempY = tempPlayer.YPosition;

                currentPlayer.XPosition = tempX;
                currentPlayer.YPosition = tempY;
                tempPlayer.XPosition = x;
                tempPlayer.YPosition = y;
                mapBoard[x][y] = tempPlayer;
                mapBoard[tempX][tempY] = currentPlayer;


                if (win)
                {
                    //change current player 
                    currentPlayer.PlayerModel.GetComponent<PlayerAnimation>().isCurrent = false;
                    currentPlayer = tempPlayer;
                    currentPlayer.PlayerModel.GetComponent<PlayerAnimation>().isCurrent = true;
                    Destroy(currentModel);
                    currentModel = Instantiate(currentPlayer.PlayerModel, currentPlayer.PlayerModel.transform.position, currentPlayer.PlayerModel.transform.rotation) as GameObject;
                    if (field.GetComponent<PlayerAnimation>().anime.GetFloat("Nspeed") == -1)
                    {
                        currentModel.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    }
                    else
                    {
                        currentModel.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

                    }
                    //change current tame
                    Team t = currentTeam;
                    currentTeam = otherTeam;
                    otherTeam = t;

                    //change music
                    audioSource.Stop();
                    audioSource = GetComponent<AudioSource>();
                    audioSource.clip = currentTeam.getTeamMusic();
                    if (musicIsPlaying)
                    {
                        audioSource.Play();
                    }
                }
                Destroy(otherModel);
                changeState(97, true);

            }
            else
            {

                timer -= Time.deltaTime;
            }
        }
        if(state == 5)
        {
            if (stage == 0)
            {
                if (timer <= Time.deltaTime)
                {

                    eff = Instantiate(eff, eff.transform.position, eff.transform.rotation) as GameObject;
                    stage = 1;
                    timer = 2.5f;

                }
                else
                {
                    timer -= Time.deltaTime;

                }
            }
            if (stage == 1)
            {
                if (timer <= Time.deltaTime)
                {
                    ballEff = Instantiate(ballEff, ballEff.transform.position, ballEff.transform.rotation) as GameObject;
                    ballEff.transform.parent = ball.transform;
                    stage = 2;
                }
                else
                {
                    timer -= Time.deltaTime;

                }
            }

        }
        if (state == 97)
        {
            if (oneS > 0)
            {
                oneS -= Time.deltaTime;
            }
            else
            {
                changeState(0, false);
                oneS = 1.0f;
            }
        }
        if (state == 98)
        {
            if (oneS > 0)
            {
                oneS -= Time.deltaTime;
            }
            else
            {
                changeState(0, false);
                oneS = 1.0f;
            }
        }
        if (state == 99)
        {
            if (oneS > 0)
            {
                oneS -= Time.deltaTime;
            }
            else
            {
                changeState(0, false);
                oneS = 1.0f;
                ml3bMap.GetComponent<MenuC>().text.text = updateMap(team1);
                ml3bMap.GetComponent<MenuC>().text2.text = updateMap(team2);


            }
            if (durection == 0)
            {
                Quaternion R = Quaternion.Euler(0f, 0f, 0f);
                currentModel.transform.rotation = Quaternion.Slerp(currentModel.transform.rotation, R, Time.deltaTime * 5f);
                ball.transform.rotation = Quaternion.Slerp(ball.transform.rotation, R, Time.deltaTime * 5f);

            }
            if (durection == 1)
            {
                Quaternion R2 = Quaternion.Euler(0f, 180f, 0f);
                currentModel.transform.rotation = Quaternion.Slerp(currentModel.transform.rotation, R2, Time.deltaTime * 5f);
                ball.transform.rotation = Quaternion.Slerp(ball.transform.rotation, R2, Time.deltaTime * 5f);

            }
        }


    }
    public void changeState(int s, bool p )
    {
        currentModel.GetComponent<PlayerAnimation>().setState(s);
        menu1.GetComponent<MenuC>().setState(s);
        menu2.GetComponent<MenuC>().setState(s);
        ml3bMap.GetComponent<MenuC>().setState(s);
        state = s;
        field.GetComponent<PlayerAnimation>().setState(s);
        stadum.GetComponent<PlayerAnimation>().setState(s);
        mainCamera.GetComponent<CameraPos>().setState(s);
        ball.GetComponent<PlayerAnimation>().setState(s);
        if (p)
        {
            otherModel.GetComponent<PlayerAnimation>().setState(s);
        }
    }
    public void changeStage(int s)
    {
        currentModel.GetComponent<PlayerAnimation>().stage = s;
        mainCamera.GetComponent<CameraPos>().stage = s;
        field.GetComponent<PlayerAnimation>().stage = s;
        stadum.GetComponent<PlayerAnimation>().stage = s;
        ball.GetComponent<PlayerAnimation>().stage = s;
    }
    public void move(string s )
    {
        int x = currentPlayer.XPosition;
        int y = currentPlayer.YPosition;
        if (s.Equals("Right"))
        {
            mapBoard[currentPlayer.XPosition + 1][currentPlayer.YPosition] = currentPlayer;
            currentPlayer.XPosition = currentPlayer.XPosition + 1;
        }
        if (s.Equals("Left"))
        {
           mapBoard[currentPlayer.XPosition - 1][currentPlayer.YPosition] = currentPlayer;
            currentPlayer.XPosition = currentPlayer.XPosition -1;
        }
        if (s.Equals("Up"))
        {
            mapBoard[currentPlayer.XPosition][ currentPlayer.YPosition - 1] = currentPlayer;
            currentPlayer.YPosition = currentPlayer.YPosition - 1;
        }
        if (s.Equals("Down"))
        {
            mapBoard[currentPlayer.XPosition][ currentPlayer.YPosition + 1] = currentPlayer;
            currentPlayer.YPosition = currentPlayer.YPosition + 1;

        }
        mapBoard[x][ y] = null;
    }
    public bool canMove1(string s)
    {
       if (s.Equals("Right"))
        {
            if (currentPlayer.XPosition+1 <10)
            {
                return true;
            }
        }
        if (s.Equals("Left"))
        {
            if (currentPlayer.XPosition - 1 >= 0)
            {
                return true;
            }
        }
        if (s.Equals("Up"))
        {
            if (currentPlayer.YPosition - 1 >= 0)
            {
                return true;
            }
        }
        if (s.Equals("Down"))
        {
            if (currentPlayer.YPosition + 1 < 30)
            {
                return true;
            }
        }
        return false;
    }
    public bool canMove2(string s)
    {

        if (s.Equals("Right"))
        {
            if (mapBoard[currentPlayer.XPosition + 1][ currentPlayer.YPosition] == null)
            {
                return true;
            }

        }
        if (s.Equals("Left"))
        {
            if (mapBoard[currentPlayer.XPosition - 1][ currentPlayer.YPosition] == null)
            {
                return true;
            }
        }
        if (s.Equals("Up"))
        {
            if (mapBoard[currentPlayer.XPosition][ currentPlayer.YPosition - 1] == null)
            {
                return true;
            }
        }
        if (s.Equals("Down"))
        {
            if (mapBoard[currentPlayer.XPosition][ currentPlayer.YPosition + 1] == null)
            {
                return true;
            }
        }
       
        return false;
    }
    public Player canMove3(string s)
    {
        if (s.Equals("Right"))
        {
            return mapBoard[currentPlayer.XPosition + 1][ currentPlayer.YPosition]; 
        }
        if (s.Equals("Left"))
        {
            return mapBoard[currentPlayer.XPosition - 1][ currentPlayer.YPosition];
        }
        if (s.Equals("Up"))
        {
            return mapBoard[currentPlayer.XPosition][ currentPlayer.YPosition - 1];
        }
        if (s.Equals("Down"))
        {
            return mapBoard[currentPlayer.XPosition][ currentPlayer.YPosition + 1];
        }
        return null;
    }
    public void mapboaerIn()
    {
        for (int r = 0; r < 10; r++)
        {
            mapBoard[r] = new Player[30];
        }
        for (int r = 0; r < 10; r++)
        {
            for (int c = 0; c < 30; c++)
            {
                mapBoard[r][c] = null;
            }
        }
    }
    public bool tackle()
    {
        
        
        int currentpp = currentPlayer.M7wrhPower;
        int otherpp = tempPlayer.TaklPoWer;

        int diff = currentpp - otherpp;
        int rnd;
        /*************************************************
		  * If current Player power == other Player power
		  ************************************************/
        if (diff ==0)
        {
            rnd = Random.Range(0,2);
            if (rnd == 1)
            {
                return true;
            }
        }

        /***************************************
		  * If current Player > other Player
		  **************************************/
        if (diff <= 10 && diff > 0)
        {
            rnd = Random.Range(0, 100);
            if (rnd <= 40)
            {
                return true;
            }
        }
        if (diff <= 20 && diff > 10)
        {
            rnd = Random.Range(0, 100);
            if (rnd <= 30)
            {
                return true;
            }
        }
        if (diff <= 30 && diff > 20)
        {
            rnd = Random.Range(0, 100);
            if (rnd <= 25)
            {
                return true;
            }
        }
        if (diff <= 40 && diff > 30)
        {
            rnd = Random.Range(0, 100);
            if (rnd <= 20)
            {
                return true;
            }
        }
        if (diff > 40)
        {
            rnd = Random.Range(0, 100);
            if (rnd <= 10)
            {

                return true;
            }
        }
        /***************************************************
		 * If other Player > Current Player
		 **************************************************/
        if (diff >= -10 && diff < 0)
        {
            rnd = Random.Range(0, 100);
            if (rnd <= 60)
            {
                return true;
            }
        }
        if (diff >= -20 && diff < -10)
        {
            rnd = Random.Range(0, 100);
            if (rnd <= 70)
            {
                return true;
            }
        }
        if (diff >= -30 && diff < -20)
        {
            rnd = Random.Range(0, 100);
            if (rnd <= 75)
            {
                return true;
            }
        }
        if (diff >= -40 && diff < -30)
        {
            rnd = Random.Range(0, 100);
            if (rnd <= 80)
            {
                return true;
            }
        }
        if (diff < -40)
        {
            rnd = Random.Range(0, 100);
            if (rnd <= 90)
            {
                return true;
            }
        }

        return false;
    }
    public string updateMap(Team t)
    {
        string s = "";
        for (int c = 0; c < 30; c++)
        {
            for (int r = 0; r < 10; r++)
            {
                if(mapBoard[r][c] != null && t.players.Contains(mapBoard[r][c]))
                {
                    if (mapBoard[r][c] == currentPlayer)
                    {
                        s += "C";
                    }
                    else
                    {
                        s += mapBoard[r][c].PlayerNumper;
                        s += "  ";
                    }
                }else
                {
                    s += "  ";
                }
            }
            s += "\n";
        }
        return s;
    }

}
