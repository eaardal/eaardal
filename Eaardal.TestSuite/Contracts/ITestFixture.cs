namespace Eaardal.TestSuite.Contracts
{
    public interface ITestFixture<out T>
    {
        T CreateSut();
    }
}
