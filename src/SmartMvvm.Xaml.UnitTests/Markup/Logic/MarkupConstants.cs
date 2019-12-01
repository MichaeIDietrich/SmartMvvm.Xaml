using System.Windows.Markup;

namespace SmartMvvm.Xaml.UnitTests.Markup.Logic
{
    public class MarkupConstants
    {
        public const bool True = true;

        public const bool False = false;

        public static readonly StaticExtension StaticTrue = new StaticExtension(nameof(True)) { MemberType = typeof(MarkupConstants) };

        public static readonly StaticExtension StaticFalse = new StaticExtension(nameof(False)) { MemberType = typeof(MarkupConstants) };
    }
}
