namespace Eaardal.TestSuite.Contracts
{
    public interface ITestDataBuilder<out T>
    {
        T Build();
    }
}