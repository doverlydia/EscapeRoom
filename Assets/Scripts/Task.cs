using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class AbsTask
{
    public string taskName;
    public string taskDescription;
    public abstract bool completed { get; }
}

#region subtasks
[System.Serializable]
public class SubTask : AbsTask
{
    [SerializeField] private CollectableObject collectableObject;
    public override bool completed
    {
        get => collectableObject.collected;
    }
}
#endregion

#region task
[System.Serializable]
public class Task : AbsTask
{
    public List<SubTask> taskDependeciesByOrder;
    public override bool completed
    {
        get => taskDependeciesByOrder.All(t => t.completed);
    }
}
#endregion