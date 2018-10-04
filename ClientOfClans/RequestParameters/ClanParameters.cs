using ClientOfClans.Objects;
using System.Collections.Generic;

namespace ClientOfClans.RequestParameters
{
    public class ClanParameters : IRequestParameters
    {
        public int? Limit { get; set; } = null;
        public int? After { get; set; } = null;
        public int? Before { get; set; } = null;

        public string Name { get; set; }
        public WarFrequency? WarFrequency { get; set; } = null;
        public int? LocationId { get; set; } = null;
        public int? MinMembers { get; set; } = null;
        public int? MaxMembers { get; set; } = null;
        public int? MinClanPoints { get; set; } = null;
        public int? MinClanLevel { get; set; } = null;

        public ParameterResult VerifyParameters()
        {
            if(After.HasValue && Before.HasValue)
                return new ParameterResult(true, $"{nameof(After)} and {nameof(Before)} can't be both specified at the same time.");

            if(Limit < 0)
                return new ParameterResult(true, $"{nameof(Limit)} cannot be negative.");

            if(MaxMembers < MinMembers)
                return new ParameterResult(true, $"{nameof(MaxMembers)} must be greater than or equal to {nameof(MinMembers)}.");

            //TODO add LocationId check

            if(LocationId < 0 || MinMembers < 0 || MaxMembers < 0 || MinClanPoints < 0 || MinClanLevel < 0)
                return new ParameterResult(true, "Value cannot be negative.");

            if(MaxMembers > 50)
                return new ParameterResult(true, $"{nameof(MaxMembers)} cannot be greater than 50.");

            if(string.IsNullOrWhiteSpace(Name) && !WarFrequency.HasValue && !LocationId.HasValue && !MinMembers.HasValue && !MaxMembers.HasValue && !MinClanLevel.HasValue && !MinClanPoints.HasValue)
                return new ParameterResult(true, "Must specify at least one search parameter.");

            return new ParameterResult(false, string.Empty);
        }

        public string GenerateQuery()
        {
            var queryList = new List<string>();

            if(!string.IsNullOrWhiteSpace(Name))
                queryList.Add($"name={Name}");

            if(Limit.HasValue)
                queryList.Add($"limit={Limit}");

            if(After.HasValue)
                queryList.Add($"after={After}");

            if(Before.HasValue)
                queryList.Add($"before={Before}");

            if(WarFrequency.HasValue)
                queryList.Add($"warFrequency={WarFrequency.GetStringValue()}");

            if(LocationId.HasValue)
                queryList.Add($"locationId={LocationId}");

            if(MinMembers.HasValue)
                queryList.Add($"minMembers={MinMembers}");

            if(MaxMembers.HasValue)
                queryList.Add($"maxMembers={MaxMembers}");

            if(MinClanPoints.HasValue)
                queryList.Add($"minClanPoints={MinClanPoints}");

            if(MinClanLevel.HasValue)
                queryList.Add($"minClanLevel={MinClanLevel}");

            return $"?{string.Join("&", queryList)}";
        }
    }
}
