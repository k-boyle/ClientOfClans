namespace ClientOfClans.RequestParameters
{
    internal interface IRequestParameters
    {
        ParameterResult VerifyParameters();
        string GenerateQuery();
    }
}
