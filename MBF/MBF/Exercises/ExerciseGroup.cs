using MBF.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MBF.Exercises
{
    public class ExerciseGroup : ObservableCollection<Exercise>, INotifyPropertyChanged
    {
        private static readonly ExerciseGroup Arms = new ExerciseGroup(EExerciseGroup.Arms) { new BicepExercise(), new TricepExercise() };
        private static readonly ExerciseGroup Chest = new ExerciseGroup(EExerciseGroup.Chest) { new BenchPress(), new Fly(), new InclineBenchPress() };
        private static readonly ExerciseGroup Legs = new ExerciseGroup(EExerciseGroup.Legs) { };
        private static readonly ExerciseGroup Shoulder = new ExerciseGroup(EExerciseGroup.Shoulder) { };
        public static ObservableCollection<ExerciseGroup> All = new ObservableCollection<ExerciseGroup> { Arms, Chest, Legs, Shoulder };
        private bool _isExpanded;
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged("IsExpanded");
                    OnPropertyChanged("ExpandedIcon");
                }
            }
        }
        public string Title { get; set; }
        public string FirstChar { get { return Title?.Substring(0, 1); } }
        public string TitleWithItemCount { get { return $"{Title} ({ExerciseCount})"; } }
        public string ExpandedIcon { get { return IsExpanded ? "expanded.png" : "collapsed.png"; } }
        public int ExerciseCount => Count;
        public ExerciseGroup(string pTitle, bool pIsExpanded = false)
        {
            Title = pTitle;
            IsExpanded = pIsExpanded;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
