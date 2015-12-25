namespace DesignPattern.DoubleDispatch
{
    public interface IAnimal2
    {
        void execute(DoubleDispatch obj);
    }

    public class Bird : IAnimal2
    {
        public void execute(DoubleDispatch obj)
        {
            obj.execute(this);
        }
    }

    public class Rabbit : IAnimal2
    {
        public void execute(DoubleDispatch obj)
        {
            obj.execute(this);
        }
    }

    public class DoubleDispatch
    {
        public void execute(Bird obj)
        {
            System.Diagnostics.Debug.WriteLine("bird");
        }

        public void execute(Rabbit obj)
        {
            System.Diagnostics.Debug.WriteLine("rabbit");
        }
    }
}
