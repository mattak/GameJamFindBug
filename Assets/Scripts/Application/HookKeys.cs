using UnityEngine;
using UnityHooks;

namespace FindBug.Application
{
    public static class HookKeys
    {
        public static readonly HookKey<bool?> IsOkNg = new HookKey<bool?>("is_ok_ng", null);
        public static readonly HookKey<int> SlidePosition = new HookKey<int>("slide_position", 0);
        public static readonly HookKey<int> SlideMax = new HookKey<int>("slide_max", 1);
        public static readonly HookKey<RectTransform> BottomSheet = new HookKey<RectTransform>("bottom_sheet", null);
    }
}