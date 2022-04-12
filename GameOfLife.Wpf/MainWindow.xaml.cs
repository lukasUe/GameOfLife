using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameOfLife.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //m x n Matrix
        const int m = 37, n = 60;
        Rectangle[,] cells = new Rectangle[m, n];
        DispatcherTimer timer = new();

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Rectangle cell = new();
                    cell.Width = matrix.ActualWidth / n - 2.0;       //nicht aktuelle sondern tatsächlich Breite
                    cell.Height = matrix.ActualHeight / m - 2.0;
                    cell.Fill = Brushes.Black;

                    matrix.Children.Add(cell);

                    Canvas.SetLeft(cell, j * matrix.ActualWidth / n);
                    Canvas.SetTop(cell, i * matrix.ActualHeight / m);

                    cell.MouseDown += Cell_MouseDown;

                    cells[i, j] = cell;
                }
            }
        }

        private void Cell_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ((Rectangle)sender).Fill = ((Rectangle)sender).Fill == Brushes.Black ? Brushes.White : Brushes.Black;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            int[,] neighborCells = CountingLivingNeighborCells(m, n);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (cells[i, j].Fill == Brushes.Black && Rule1(neighborCells, i, j))
                        cells[i, j].Fill = Brushes.White;

                    else if (cells[i, j].Fill == Brushes.White && Rule2(neighborCells, i, j))
                        cells[i, j].Fill = Brushes.Black;

                    else if (cells[i, j].Fill == Brushes.White && Rule3(neighborCells, i, j))
                        cells[i, j].Fill = Brushes.White;

                    else if (cells[i, j].Fill == Brushes.White && Rule4(neighborCells, i, j))
                        cells[i, j].Fill = Brushes.Black;

                    else
                        cells[i, j].Fill = Brushes.Black;
                }
            }
        }

        private int[,] CountingLivingNeighborCells(int m, int n)
        {
            int[,] livingNeighbors = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int neighbors = 0;

                    int above_i = i - 1;
                    int under_i = i + 1;
                    int left_j = j - 1;
                    int right_j = j + 1;

                    if (above_i < 0)
                        above_i = m - 1;

                    if (under_i >= m)
                        under_i = 0;

                    if (left_j < 0)
                        left_j = n - 1;

                    if (right_j >= n)
                        right_j = 0;


                    if (cells[above_i, left_j].Fill == Brushes.White)
                    {
                        neighbors++;
                    }
                    if (cells[above_i, j].Fill == Brushes.White)
                    {
                        neighbors++;
                    }
                    if (cells[above_i, right_j].Fill == Brushes.White)
                    {
                        neighbors++;
                    }
                    if (cells[i, left_j].Fill == Brushes.White)
                    {
                        neighbors++;
                    }
                    if (cells[i, right_j].Fill == Brushes.White)
                    {
                        neighbors++;
                    }
                    if (cells[under_i, left_j].Fill == Brushes.White)
                    {
                        neighbors++;
                    }
                    if (cells[under_i, j].Fill == Brushes.White)
                    {
                        neighbors++;
                    }
                    if (cells[under_i, right_j].Fill == Brushes.White)
                    {
                        neighbors++;
                    }

                    livingNeighbors[i, j] = neighbors;
                }
            }

            return livingNeighbors;
        }

        private bool Rule1(int[,] counter, int i, int j)
        {
            bool valid = false;

            if (counter[i, j] == 3)
                valid = true;


            return valid;
        }

        private bool Rule2(int[,] counter, int i, int j)
        {
            bool valid = false;

            if (counter[i, j] < 2)
                valid = true;


            return valid;
        }

        private bool Rule3(int[,] counter, int i, int j)
        {
            bool valid = false;

            if (counter[i, j] == 3 || counter[i, j] == 2)
                valid = true;


            return valid;
        }

        private bool Rule4(int[,] counter, int i, int j)
        {
            bool valid = false;

            if (counter[i, j] > 3)
                valid = true;


            return valid;
        }

        private void StopAnimation_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cells[i, j].Fill = Brushes.Black;
                }
            }
        }

        private void NextStepButton_Click(object sender, RoutedEventArgs e)
        {
            int[,] neighborCells = CountingLivingNeighborCells(m, n);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (cells[i, j].Fill == Brushes.Black && Rule1(neighborCells, i, j))
                        cells[i, j].Fill = Brushes.White;

                    else if (cells[i, j].Fill == Brushes.White && Rule2(neighborCells, i, j))
                        cells[i, j].Fill = Brushes.Black;

                    else if (cells[i, j].Fill == Brushes.White && Rule3(neighborCells, i, j))
                        cells[i, j].Fill = Brushes.White;

                    else if (cells[i, j].Fill == Brushes.White && Rule4(neighborCells, i, j))
                        cells[i, j].Fill = Brushes.Black;

                    else
                        cells[i, j].Fill = Brushes.Black;
                }
            }
        }

        private void StartAnimation_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

    }
}

