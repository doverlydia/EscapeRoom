using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Task> tasks;
    private bool gameWon => tasks.All(t => t.completed);

    private void Update()
    {
        if (gameWon)
            Debug.Log("Game Won!");
    }
}
