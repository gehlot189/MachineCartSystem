using System;
using System.Collections.Generic;
using System.Linq;

namespace MachineCartSystem.Configuration
{
    public static class JoinExtension
    {
        public static IEnumerable<KeyValuePair<TLeft, TRight>> FullOuterJoin<TLeft, TRight>(this IEnumerable<TLeft> leftItems, Func<TLeft, object> leftIdSelector, IEnumerable<TRight> rightItems, Func<TRight, object> rightIdSelector)
        {
            var leftOuterJoin = from left in leftItems
                                join right in rightItems on leftIdSelector(left) equals rightIdSelector(right) into temp
                                from right in temp.DefaultIfEmpty()
                                select new { left, right };

            var rightOuterJoin = from right in rightItems
                                 join left in leftItems on rightIdSelector(right) equals leftIdSelector(left) into temp
                                 from left in temp.DefaultIfEmpty()
                                 select new { left, right };

            var fullOuterJoin = leftOuterJoin.Union(rightOuterJoin);

            return fullOuterJoin.Select(x => new KeyValuePair<TLeft, TRight>(x.left, x.right));
        }
    }

}
