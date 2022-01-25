using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Events
{
    public static readonly Evt OnTaskCompleted = new Evt();
}

public class Evt
{
    public event Action Action = delegate { };

    public void Invoke()
    {
        Action.Invoke();
    }

    public void UpsertListener(Action listener)
    {
        Action -= listener;
        Action += listener;
    }

    public void RemoveListener(Action listener)
    {
        Action -= listener;
    }
}
