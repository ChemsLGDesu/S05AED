using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void MoveTowardsPlayer(Vector3 playerPos)
    {

        Vector3 direction = (playerPos - transform.position).normalized;
        transform.position += new Vector3(Mathf.Round(direction.x), 0, Mathf.Round(direction.z));

    }
}
