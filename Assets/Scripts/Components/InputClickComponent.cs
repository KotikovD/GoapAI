using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
[Event(EventTarget.Self)]
public sealed class InputClickComponent : IComponent
{
    public Vector3 ClickPoint;
}