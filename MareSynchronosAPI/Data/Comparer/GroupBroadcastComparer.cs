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

        public static bool MultisetEquals(IEnumerable<GroupBroadcastDto> a, IEnumerable<GroupBroadcastDto> b)
        {
            if (a is ICollection<GroupBroadcastDto> ac &&
                b is ICollection<GroupBroadcastDto> bc &&
                ac.Count != bc.Count)
                return false;

            var counts = new Dictionary<GroupBroadcastDto, int>(Instance);
            foreach (var x in a)
                counts[x] = counts.TryGetValue(x, out var c) ? c + 1 : 1;

            foreach (var y in b)
            {
                if (!counts.TryGetValue(y, out var c)) return false;
                if (c == 1) counts.Remove(y);
                else counts[y] = c - 1;
            }
            return counts.Count == 0;
        }
    }
}
