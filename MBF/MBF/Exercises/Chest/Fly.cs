using MBF.Enums;
using Xamarin.Forms;

namespace MBF.Exercises
{
    public class Fly : ChestExercise
    {
        public override int AmountPerRepetition => 12;
        public override string BarType => EBarType.Dumbell;
        public override int Kilograms => 20;
        public override ImageSource Image => ImageSource.FromFile("no_image_found.png");
        public override int Repetitions => 3;
        public override string Name => EExercise.Fly;
    }
}
