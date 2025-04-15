namespace AnimalType
{
    public class Cat : Animal
    {
        public override string MakeSound()
        {
            throw new NotImplementedException("Cats don't make sounds in this context.");
        }
    }
}
