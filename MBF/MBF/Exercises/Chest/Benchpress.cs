using MBF.Enums;
using Xamarin.Forms;

namespace MBF.Exercises
{
    public class BenchPress : ChestExercise
    {
        public override int AmountPerRepetition => 12;
        public override string BarType => EBarType.Straight;
        public override int Kilograms => 50;
        public override ImageSource Image => ImageSource.FromFile("no_image_found.png");
        public override int Repetitions => 3;
        public override string Name => EExercise.Benchpress;
    }
}
