using System.Collections.Generic;

namespace ClientOfClans.RequestParameters
{
    public class ClanMembersParameters : IRequestParameters
    {
        public int? Limit { get; set; } = null;
        public int? After { get; set; } = null;
        public int? Before { get; set; } = null;

        public ParameterResult VerifyParameters()
        {
            if(Limit < 0)
                return new ParameterResult(true, $"{nameof(Limit)} cannot be a negative value.");

            if(After.HasValue && Before.HasValue)
                return new ParameterResult(true, $"{nameof(Before)} and {nameof(After)} can't both be defined at the same time.");

            return new ParameterResult(false, string.Empty);
        }

        public string GenerateQuery()
        {
            var queryList = new List<string>();

            if (Limit.HasValue)
                queryList.Add($"limit={Limit}");

            if (After.HasValue)
                queryList.Add($"after={After}");

            if (Before.HasValue)
                queryList.Add($"before={Before}");

            return $"?{string.Join("&", queryList)}";
        }
    }
}
