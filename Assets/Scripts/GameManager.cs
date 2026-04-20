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
        foreach (var enemy in enemies)
        {

            Vector3 direction = (player.transform.position - enemy.transform.position).normalized;
            Vector3 move = new Vector3(Mathf.Round(direction.x), 0, Mathf.Round(direction.z));
            enemy.transform.position += move;
        }
        snapshotSystem.SaveTurn(enemies);

        Debug.Log("Turno registrado: Movimiento de entidades y guardado de Snapshot completo.");
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
        snapshotSystem.pointer = snapshotSystem.head;

        while (snapshotSystem.pointer != null)
        {
            LoadTurn();
            yield return new WaitForSeconds(0.5f); 

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