﻿namespace Wpm.SharedKernel;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; protected set; }
    public override bool Equals(object obj)
    {
        return Equals(obj as Entity);
    }
    public bool Equals(Entity? other)
    {
        return other?.Id == Id;
    }
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    public static bool operator ==(Entity? left, Entity? right)
    {
        return left?.Id == right?.Id;
    }
    public static bool operator !=(Entity? left, Entity? right)
    {
        return left?.Id != right?.Id;
    }
}
