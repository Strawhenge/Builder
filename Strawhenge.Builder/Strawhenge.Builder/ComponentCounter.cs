namespace Strawhenge.Builder
{
    internal class ComponentCounter
    {
        public ComponentCounter(Component component)
        {
            Component = component;
        }

        public Component Component { get; }

        public int CurrentCount { get; private set; }

        public void Add(int quantity)
        {
            if (quantity < 0) return;

            CurrentCount += quantity;
        }

        public void Substract(int quantity)
        {
            if (quantity < 0) return;

            var newQuantity = CurrentCount - quantity;

            if (newQuantity < 0)
                newQuantity = 0;

            CurrentCount = newQuantity;
        }
    }
}
