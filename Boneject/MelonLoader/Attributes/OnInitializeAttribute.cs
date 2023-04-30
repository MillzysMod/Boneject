﻿using System;

namespace Boneject.MelonLoader.Attributes;

/// <summary>
/// Marks the method to be called and injected to when your mod initialises.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class OnInitializeAttribute : Attribute
{
}