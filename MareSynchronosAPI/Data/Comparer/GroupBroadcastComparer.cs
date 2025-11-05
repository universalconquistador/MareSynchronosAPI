using MareSynchronos.API.Dto.Group;

namespace MareSynchronos.API.Data.Comparer
{
    public class GroupBroadcastComparer : IEqualityComparer<GroupBroadcastDto>
    {
        private static readonly GroupBroadcastComparer _instance = new();

        public static GroupBroadcastComparer Instance => _instance;

        public bool Equals(GroupBroadcastDto? x, GroupBroadcastDto? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;

            if (!Equals(x.Group, y.Group)) return false;
            if (!Equals(x.Owner, y.Owner)) return false;

            if (x.CurrentMemberCount != y.CurrentMemberCount) return false;
            if (x.Passwordless != y.Passwordless) return false;
            if (x.IsGuestModeEnabled != y.IsGuestModeEnabled) return false;

            var xb = x.Broadcasters;
            var yb = y.Broadcasters;
            if (xb == null || yb == null) return xb == yb;

            return xb.SequenceEqual(yb);
        }

        public int GetHashCode(GroupBroadcastDto obj)
        {
            var hc = new HashCode();
            hc.Add(obj.Group);
            hc.Add(obj.Owner);
            hc.Add(obj.CurrentMemberCount);
            hc.Add(obj.Passwordless);
            hc.Add(obj.IsGuestModeEnabled);
            if (obj.Broadcasters != null)
                foreach (var b in obj.Broadcasters) hc.Add(b);
            return hc.ToHashCode();
        }
    }

}
