using UnityEngine;
using System.Collections;

public class Player {
    private string PlayerName;
    private int playerNumper;
    private GameObject playerModel;
    private ArrayList shots;
    private int xPosition;
    private int yPosition;
    private int power;
    private int taklPoWer;
    private int passPower;
    private int m7wrhPower;
    private int shotPower;



    public Player(string Pname, int number, int x , int y, int Power, int tPower,
        int sPower, int mPower, int pPower, GameObject model)
    {
        PlayerName = Pname;
        PlayerNumper = number;
        XPosition = x;
        YPosition = y;
        this.Power = Power;
        TaklPoWer = tPower;
        PassPower = pPower;
        M7wrhPower = mPower;
        ShotPower = sPower;
        PlayerModel = model;
    }

    public string Name
    {
        get
        {
            return PlayerName;
        }

        set
        {
            PlayerName = value;
        }
    }

    public int XPosition
    {
        get
        {
            return xPosition;
        }

        set
        {
            xPosition = value;
        }
    }

    public int YPosition
    {
        get
        {
            return yPosition;
        }

        set
        {
            yPosition = value;
        }
    }

    public int Power
    {
        get
        {
            return power;
        }

        set
        {
            power = value;
        }
    }

    public int TaklPoWer
    {
        get
        {
            return taklPoWer;
        }

        set
        {
            taklPoWer = value;
        }
    }

    public int PassPower
    {
        get
        {
            return passPower;
        }

        set
        {
            passPower = value;
        }
    }

    public int M7wrhPower
    {
        get
        {
            return m7wrhPower;
        }

        set
        {
            m7wrhPower = value;
        }
    }

    public int ShotPower
    {
        get
        {
            return shotPower;
        }

        set
        {
            shotPower = value;
        }
    }

    public int PlayerNumper
    {
        get
        {
            return playerNumper;
        }

        set
        {
            playerNumper = value;
        }
    }

    public GameObject PlayerModel
    {
        get
        {
            return playerModel;
        }

        set
        {
            playerModel = value;
        }
    }

    public ArrayList Shots
    {
        get
        {
            return shots;
        }

        set
        {
            shots = value;
        }
    }
}
