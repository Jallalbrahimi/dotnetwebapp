namespace WebApp.Application.Common;

// https://chtenb.dev/?page=unit-cs#
public struct Unit : IEquatable<Unit>
{
    public static readonly Unit unit;
    public override bool Equals(object? obj) => obj is Unit;
    public override int GetHashCode() => 0;
    public static bool operator ==(Unit left, Unit right) => left.Equals(right);
    public static bool operator !=(Unit left, Unit right) => !(left == right);
    public bool Equals(Unit other) => true;
    public override string ToString() => "()";
}