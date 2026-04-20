using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CustomDoubleLinkedList snapshotSystem = new();

    public Player player;

    public List<GameObject> enemies;

    private void Awake() => instance = this;
    

    void Start()
    {

    }
    [Button]
    public void SaveTurn()
    {
        snapshotSystem.SaveTurn(enemies);
    }
    //[Button]
    public void LoadTurn()
    {
        snapshotSystem.LoadTurn(player, enemies);
    }
    [Button]
    public void PlayReplay()
    {
        StartCoroutine(ReplayRoutine());
    }

    private System.Collections.IEnumerator ReplayRoutine()
    {
        // Empezamos desde el primer nodo
        snapshotSystem.pointer = snapshotSystem.head;

        while (snapshotSystem.pointer != null)
        {
            LoadTurn();
            yield return new WaitForSeconds(0.5f); // Velocidad de reproducción

            if (snapshotSystem.pointer.Next == null) break;
            snapshotSystem.MoveForward();
        }

        Debug.Log("Replay finalizado.");
    }
    [Button]
    public void NextTurn() { snapshotSystem.MoveForward(); LoadTurn(); }
    [Button]
    public void PrevTurn() { snapshotSystem.MoveBackwards(); LoadTurn(); }


}