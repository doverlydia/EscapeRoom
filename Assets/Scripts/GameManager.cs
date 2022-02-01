using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text tasksUI;
    [SerializeField] List<Task> tasks;
    private bool gameWon => tasks.All(t => t.completed);

    private void Start()
    {
        foreach (Task task in tasks)
        {
            tasksUI.text += $"<b><u>{task.taskName}</b></u>";
            tasksUI.text += "\n";
            tasksUI.text += task.taskDescription;
            tasksUI.text += "\n";
            foreach (SubTask subTask in task.taskDependeciesByOrder)
            {
                tasksUI.text += "\t" + $"<b> - {subTask.taskName}</b>";
                tasksUI.text += "\n\t\t" + subTask.taskDescription;
                tasksUI.text += "\n";
            }
            tasksUI.text += "---------------------";
            tasksUI.text += "\n";
        }
    }

    private void Update()
    {
        if (gameWon)
            Debug.Log("Game Won!");
    }
}
