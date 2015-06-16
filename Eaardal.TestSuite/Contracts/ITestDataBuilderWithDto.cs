namespace Eaardal.TestSuite.Contracts
{
    public interface ITestDataBuilderWithDto<out TDomain, out TDto> : ITestDataBuilder<TDomain>
    {
        TDto BuildAsDto();
    }
}