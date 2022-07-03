using SmartMvvm.Avalonia.Xaml.Markup;

namespace SmartMvvm.Avalonia.Xaml.UnitTests.Markup.Logic
{
    public class MarkupConstants
    {
        public const bool True = true;

        public const bool False = false;

        public static readonly Bool StaticTrue = new Bool(True);

        public static readonly Bool StaticFalse = new Bool(False);
    }
}
