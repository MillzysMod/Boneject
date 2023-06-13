﻿using System;
using System.Reflection;
using MelonLoader;

namespace Boneject.MelonLoader;

internal readonly struct TypedInjector : IEquatable<TypedInjector>
{
    public readonly Type Type;
    private readonly InjectParameter _injector;

    public TypedInjector(Type type, InjectParameter injector)
    {
        Type = type;
        _injector = injector;
    }

    public object? Inject(object? previous, ParameterInfo parameter, MelonInfoAttribute info)
        => _injector(previous, parameter, info);

    public bool Equals(TypedInjector other)
        => Type == other.Type && _injector == other._injector;

    public override bool Equals(object obj)
        => obj is TypedInjector other && Equals(other);

    public override int GetHashCode()
        => Type.GetHashCode() ^ _injector.GetHashCode();

    public static bool operator ==(TypedInjector left, TypedInjector right) => left.Equals(right);
    public static bool operator !=(TypedInjector left, TypedInjector right) => !left.Equals(right);
}