using UnityEngine;
using System.Collections;

public class Team {

    private string teamName;
    public ArrayList players;
    private AudioClip teamMusic;
    public string teamColor;
    public Team num;
    public Team()
    {
        players = new ArrayList();


    }
    public void setTeamMusic(AudioClip t)
    {
        teamMusic = t;
    }
    public AudioClip getTeamMusic()
    {
        return teamMusic;
    }
    public void addPlayer(Player p)
    {
        players.Add(p);
    }
   

}
