using MBF.Exercises;
using System.Linq;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

namespace MBF.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HamburgerMenu : MasterDetailPage
    {
        private ObservableCollection<ExerciseGroup> _allExerciseGroups = ExerciseGroup.All;
        private ObservableCollection<ExerciseGroup> _expandedExerciseGroups= new ObservableCollection<ExerciseGroup>();;
        public HamburgerMenu()
        {
            InitializeComponent();
            Detail = new NavigationPage(new MainPage());
            //List<MenuItem> menuItems = new List<MenuItem>
            //{
            //    new MenuItem { MenuTitleText = "Arms", GotoPage = null, MenuIcon = ImageSource.FromFile("cheeseburger2.jpg") },
            //    new MenuItem { MenuTitleText = "Chest", GotoPage = null, MenuIcon = ImageSource.FromFile("cheeseburger2.jpg") },
            //    new MenuItem { MenuTitleText = "Shoulder", GotoPage = null, MenuIcon = ImageSource.FromFile("cheeseburger2.jpg") },
            //    new MenuItem { MenuTitleText = "Legs", GotoPage = null, MenuIcon = ImageSource.FromFile("cheeseburger2.jpg") }
            //};
            //lvMenu.ItemsSource = menuItems;
            GroupedView.ItemsSource = ExerciseGroup.All;
        }
        private void UpdateHamburgerMenu()
        {
            foreach (ExerciseGroup exerciseGroup in _allExerciseGroups)
            {
                ExerciseGroup group = new ExerciseGroup(exerciseGroup.Title, exerciseGroup.IsExpanded);
                if (exerciseGroup.IsExpanded)
                {
                    foreach (Exercise exercise in exerciseGroup)
                    {
                        group.Add(exercise);
                    }
                }
                _expandedExerciseGroups.Add(group);
            }
            GroupedView.ItemsSource = _expandedExerciseGroups;
        }
        private void HeaderTapped(object sender, EventArgs args)
        {
            int selectedIndex = _expandedExerciseGroups.IndexOf((ExerciseGroup)((Button)sender).CommandParameter);
            _allExerciseGroups[selectedIndex].IsExpanded = true;//!_allExerciseGroups[selectedIndex].IsExpanded;
            UpdateHamburgerMenu();
            GroupedView.ItemsSource = _allExerciseGroups[selectedIndex];
        }
        public class MenuItem
        {
            public string MenuTitleText { get; set; }
            public ImageSource MenuIcon { get; set; }
            public Page GotoPage { get; set; }
        }


        private void SettingMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MenuItem menuItem = e.SelectedItem as MenuItem;
            if (menuItem != null)
            {
                DisplayAlert("Test", menuItem.MenuTitleText, "OK");
            }
        }
    }
}