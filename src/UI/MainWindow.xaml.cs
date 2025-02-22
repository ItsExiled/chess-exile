using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CoolChessGame.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int BoardSize = 8; // Standard chessboard size

        public MainWindow()
        {
            InitializeComponent();
            InitializeChessBoard();
        }

        private void InitializeChessBoard()
        {
            // Clear any existing children
            ChessBoardGrid.Children.Clear();
            ChessBoardGrid.RowDefinitions.Clear();
            ChessBoardGrid.ColumnDefinitions.Clear();

            // Set up rows and columns
            for (int i = 0; i < BoardSize; i++)
            {
                ChessBoardGrid.RowDefinitions.Add(new RowDefinition());
                ChessBoardGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Create squares
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    Rectangle square = new Rectangle
                    {
                        Fill = (row + col) % 2 == 0 ? Brushes.LightGray : Brushes.DarkGray,
                        Stretch = Stretch.Fill // Ensures it fills the grid cell
                    };

                    Grid.SetRow(square, row);
                    Grid.SetColumn(square, col);
                    ChessBoardGrid.Children.Add(square);
                }
            }
        }
    }
}