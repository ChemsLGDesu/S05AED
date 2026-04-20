using System.Collections.Generic;
using UnityEngine;

public class SnapshotNode 
{
    public int Turn;

    public Vector3 playerPosition;
    public Vector3 playerRotation;
    public int str;
    public int dtx;
    public int spd;

    public List<Vector3> enemiesPositions;

    public SnapshotNode(Player player , int turn, List<GameObject> enemies)
    {
        Turn = turn;

        playerPosition = player.transform.position;
        playerRotation = player.transform.rotation.eulerAngles;
        str = player.str;
        dtx = player.dtx;
        spd = player.spd;

        enemiesPositions = new List<Vector3>();
        foreach (var enemy in enemies)
        {
            enemiesPositions.Add(enemy.transform.position);
        }
    }

    
}
