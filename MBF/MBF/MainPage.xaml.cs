using MBF.Exercises;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
namespace MBF
{
    public partial class MainPage : ContentPage
    {
        private Grid VerticalGrid;
        private Grid HorizontalGrid;
        private double width = 0;
        private double height = 0;
        private readonly List<StackLayout> exercises;
        private readonly StackLayout mainStacklayout;

        public MainPage()
        {
            ChestExercise fly = new Fly();
            ChestExercise inclineBenchpress = new InclineBenchPress();
            InitializeComponent();
            mainStacklayout = new StackLayout();
            exercises = new List<StackLayout> {
                CreateAndGetStackLayoutExercise(fly),
                CreateAndGetStackLayoutExercise(inclineBenchpress),
                CreateAndGetStackLayout("Ice Tea","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Fristi","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Cecemel","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Koffie","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Thee","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Cola","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Fanta","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Ice Tea","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Fristi","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Cecemel","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Koffie","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Thee","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Cola","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Fanta","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Ice Tea","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Fristi","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Cecemel","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Koffie","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Thee","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Cola","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Fanta","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Ice Tea","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Fristi","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Cecemel","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Koffie","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Thee","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Cola","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Fanta","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Ice Tea","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Fristi","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Cecemel","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Koffie","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Thee","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Cola","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Fanta","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Ice Tea","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Fristi","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Cecemel","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Koffie","cheeseburger2.jpg"),
                CreateAndGetStackLayout("Thee","cheeseburger2.jpg")

            };
            scrollview.Content = mainStacklayout;
            BackgroundColor = Color.White;
        }

        protected override void OnSizeAllocated(double pWidth, double pHeight)
        {
            base.OnSizeAllocated(pWidth, pHeight);
            if (width != pWidth || height != pHeight)
            {
                width = pWidth;
                height = pHeight;
                bool isVertical = pWidth < pHeight;
                Grid gridToAdd;
                if (VerticalGrid != null && HorizontalGrid != null)
                {
                    gridToAdd = isVertical ? VerticalGrid : HorizontalGrid;
                }
                else if (isVertical)
                {

                    FillGrid(exercises, pWidth, 80, 100, LayoutOptions.FillAndExpand, LayoutOptions.Center, out VerticalGrid);
                    gridToAdd = VerticalGrid;
                }
                else
                {
                    FillGrid(exercises, pWidth, 80, 100, LayoutOptions.FillAndExpand, LayoutOptions.Center, out HorizontalGrid);
                    gridToAdd = HorizontalGrid;
                }

                if (!mainStacklayout.Children.Contains(gridToAdd))
                {
                    mainStacklayout.Children.Add(gridToAdd);
                }

            }
        }

        private StackLayout CreateAndGetStackLayout(string pText, string pImageName)
        {
            StackLayout stackLayout = new StackLayout { BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand };
            stackLayout.Children.Add(new Label { Text = pText, TextColor = Color.Black });
            stackLayout.Children.Add(new Image { Source = ImageSource.FromFile(pImageName), HeightRequest = 80, WidthRequest = 80 });
            return stackLayout;
        }
        private StackLayout CreateAndGetStackLayoutExercise(Exercise pExercise)
        {
            StackLayout stackLayout = new StackLayout { BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand };
            stackLayout.Children.Add(new Label { Text = pExercise.Name, TextColor = Color.Black,LineBreakMode=LineBreakMode.TailTruncation,MaxLines=1 });
            stackLayout.Children.Add(new Image { Source = pExercise.Image, HeightRequest = 80, WidthRequest = 80 });
            return stackLayout;
        }
        // bij het laden bepalen hoeveel rijen en kolommen er moeten zijn obv data
        private void FillGrid<T>(List<T> pData, double pScreenWidth, double pItemWidth, double pItemHeight, LayoutOptions pHorizontalLayoutOptions, LayoutOptions pVerticalLayoutOptions, out Grid pGrid, int pRowSpacing = 15, int pColumnSpacing = 5) where T : StackLayout
        {

            int amountOfColumns = (int)Math.Floor((pScreenWidth - pItemWidth - 10) / pItemWidth);
            int amountOfRows = pData.Count / amountOfColumns;
            double stackLayoutMargin = Math.Floor(((pScreenWidth - ((amountOfColumns * pItemWidth) + (amountOfColumns * pColumnSpacing))) / 2) * 100) / 100;
            pGrid = new Grid
            {
                ColumnSpacing = pColumnSpacing,
                RowSpacing = pRowSpacing,
                HorizontalOptions = pHorizontalLayoutOptions,
                VerticalOptions = pVerticalLayoutOptions
            };

            if (amountOfColumns > pData.Count)
            {
                amountOfColumns = pData.Count;
                amountOfRows = 1;
            }


            for (int row = 0; row < amountOfRows; row++)
            {
                pGrid.RowDefinitions.Add(new RowDefinition
                {
                    Height = pItemHeight
                });
            }
            for (int column = 0; column < amountOfColumns; column++)
            {
                pGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = pItemWidth });
            }

            foreach (T item in pData)
            {
                CalculateLeftAndTop(pData.IndexOf(item), amountOfColumns, out int left, out int top);
                //todo: bug hier for some reason, als list is opgevuld en ie vult andere op doet ie andere +1 en vorige -1 :thinking:
                pGrid.Children.Add(item, left, top);
            }
            //pGrid.Margin = stackLayoutMargin;
            mainStacklayout.Margin = stackLayoutMargin;
        }

        private void CalculateLeftAndTop(int pIndex, int pColumns, out int pLeft, out int pTop)
        {
            pTop = (int)Math.Floor((decimal)pIndex / pColumns);
            pLeft = pIndex - (pTop * pColumns);
        }
    }
}
