using MBF.Enums;
using Xamarin.Forms;

namespace MBF.Exercises
{
    public class InclineBenchPress : BenchPress
    {
        public override ImageSource Image => ImageSource.FromFile("incline_benchpress.png");
        public override string Name => EExercise.Incline_Benchpress;
    }
}
