using System;

namespace Strawhenge.Builder
{
    public class Component
    {
        public Component(string identifier)
        {
            Identifier = string.IsNullOrWhiteSpace(identifier)
                ? string.Empty
                : identifier.Trim();
        }

        public string Identifier { get; }

        public bool Is(Component component) =>
            Identifier.Equals(component.Identifier, StringComparison.OrdinalIgnoreCase);
    }
}
