﻿namespace Hypercube.Shared.EventBus.Events.Broadcast;

public class BroadcastRegistration : IEquatable<BroadcastRegistration>
{
    public RefHandler Handler { get; }
    public object Equality { get; }

    public BroadcastRegistration(RefHandler refHandler, object equalityObj)
    {
        Handler = refHandler;
        Equality = equalityObj;
    }

    public bool Equals(BroadcastRegistration? other)
    {
        return other is not null && Equals(other.Equality, Equality);
    }

    public override bool Equals(object? obj)
    {
        return obj is not null && obj is BroadcastRegistration registration && Equals(registration.Equality, Equality);
    }

    public override int GetHashCode()
    {
        return Equality.GetHashCode();
    }
}