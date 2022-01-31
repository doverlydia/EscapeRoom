using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public abstract class AbsTask
{
    [SerializeField] protected string taskName;
    [SerializeField] protected string taskDescription;
    public abstract bool completed { get; }
}

[System.Serializable]
public class Task : AbsTask
{
    #region subtasks
    [System.Serializable]
    private class SubTask : AbsTask
    {
        [SerializeField] private CollectableObject collectableObject;
        public override bool completed
        {
            get => collectableObject.collected;
        }
    }
    #endregion

    [SerializeField] List<SubTask> taskDependeciesByOrder;
    public override bool completed
    {
        get => taskDependeciesByOrder.All(t => t.completed);
    }



}