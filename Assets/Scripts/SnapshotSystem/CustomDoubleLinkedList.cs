using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class CustomDoubleLinkedList : DoubleLinkedList<SnapshotNode>
{
    public Node<SnapshotNode> pointer;

    public void SaveTurn(List<GameObject> enemies)
    {
        //base.Add(value);

        if(pointer == tail)
        {
            RemoveFromPosition(pointer);
        }
        SnapshotNode snapshot = new SnapshotNode(GameManager.instance.player, Count, enemies);
        base.Add(snapshot);
        ResetPointer();

    }   

    public void ResetPointer()
    {
        pointer = tail;
    }


    public void MoveBackwards()
    {
        if(pointer.Prev == null) return;

        pointer = pointer.Prev;
    }
    public void MoveForward()
    {
        if (pointer.Next == null) return;

        pointer = pointer.Next;
    }

    public void LoadTurn(Player player, List<GameObject> enemies)
    {
        Debug.Log("Cargando el turno: "+ pointer.Value.Turn);
        player.transform.position = pointer.Value.playerPosition;
        player.transform.eulerAngles =  pointer.Value.playerRotation;
        player.str = pointer.Value.str;
        player.dtx = pointer.Value.dtx; 
        player.spd = pointer.Value.spd;

        for (int i = 0; i < enemies.Count; i++)
        {
            if (i < pointer.Value.enemiesPositions.Count)
            {
                enemies[i].transform.position = pointer.Value.enemiesPositions[i];
            }
        }
    }


}
