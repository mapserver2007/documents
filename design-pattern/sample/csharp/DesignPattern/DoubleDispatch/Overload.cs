namespace DesignPattern.DoubleDispatch
{
    public interface IAnimal { }
    public class Dog : IAnimal { }
    public class Cat : IAnimal { }

    public class Overload
    {
        public void execute(Dog obj)
        {
            System.Diagnostics.Debug.WriteLine("dog");
        }

        public void execute(Cat obj)
        {
            System.Diagnostics.Debug.WriteLine("cat");
        }
    }
}
