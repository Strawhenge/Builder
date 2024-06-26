﻿using System;

namespace Strawhenge.Builder
{
    public sealed class Component : IEquatable<Component>
    {
        public static bool operator ==(Component first, Component second) =>
            (ReferenceEquals(first, null) && ReferenceEquals(second, null)) ||
            (!ReferenceEquals(second, null) && (first?.Equals(second) ?? false));

        public static bool operator !=(Component first, Component second) => !(first == second);

        public Component(string identifier)
        {
            Identifier = string.IsNullOrWhiteSpace(identifier)
                ? string.Empty
                : identifier.Trim();
        }

        public string Identifier { get; }

        public bool Is(Component component) =>
            Identifier.Equals(component.Identifier, StringComparison.OrdinalIgnoreCase);

        public bool Equals(Component other) => Is(other);

        public override bool Equals(object obj) => obj is Component other && Equals(other);

        public override int GetHashCode() => Identifier.GetHashCode();
    }
}