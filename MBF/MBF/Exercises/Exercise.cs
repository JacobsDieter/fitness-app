using Xamarin.Forms;
namespace MBF
{
    public class Exercise
    {
        public virtual string Category { get; }
        public virtual string Name { get; }
        public virtual int AmountPerRepetition { get; set; }
        public virtual int Repetitions { get; set; }
        public virtual int Kilograms { get; set; }
        public virtual ImageSource Image { get; set; }
        public virtual string BarType { get; set; }
    }
}
