namespace ClientOfClans.RequestParameters
{
    public class ParameterResult
    {
        public bool Failed { get; }
        public string Reason { get; }

        internal ParameterResult(bool failed, string reason)
        {
            Failed = failed;
            Reason = reason;
        }
    }
}
