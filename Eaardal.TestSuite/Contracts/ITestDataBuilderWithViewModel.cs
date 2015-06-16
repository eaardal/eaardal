namespace Eaardal.TestSuite.Contracts
{
    public interface ITestDataBuilderWithViewModel<out TDomain, out TViewModel> : ITestDataBuilder<TDomain>
    {
        TViewModel BuildAsViewModel();
    }
}