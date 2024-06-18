using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace MyForest
{
    
    //клас ігрового поля
    public class ForestMap : Canvas
    {
        public int forestMapSize { get; set; }
        
        private static readonly Color EvenCellColor = Colors.Green;
        private static readonly Color OddCellColor =  Color.FromArgb(255, 0, 115, 0);

        /*private static readonly BitmapImage gras1 = new BitmapImage(new Uri("./Resources/gras1", UriKind.Relative));
        private static readonly BitmapImage gras2 = new BitmapImage(new Uri("./Resources/gras2", UriKind.Relative));*/
       
        public Dictionary<Point, ForestMapCell> pointToCell;
        public static ForestMap ForestMapInstance;

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);

            ForestMapInstance = this;
            pointToCell = new Dictionary<Point, ForestMapCell>();

            uint cellId = 0;

            forestMapSize = 10;
            
            //визначення розмірів клітинки
            double cellWidth = sizeInfo.NewSize.Width / forestMapSize;
            double cellHeight = sizeInfo.NewSize.Height / forestMapSize;


            for (int y = 0; y < forestMapSize; y++)
            {
                for (int x = 0; x < forestMapSize; x++)
                {
                    ForestMapCell newCell = new ForestMapCell(cellId);
                    pointToCell.Add(new Point(x, y), newCell);
        
                    //вказання розмірів клітинки
                    newCell.ChangeSize(cellWidth, cellHeight);
                    
                    //визначення положення клітинки
                    newCell.SetValue(TopProperty, y * cellHeight);
                    newCell.SetValue(LeftProperty, x * cellWidth);
        
                    //встановлення кольору клітинки в шахматному порядку
                    if ((x + y) % 2 == 0)
                    {
                        newCell.CellBody.Fill = new SolidColorBrush(OddCellColor);
                        //.CellBodyGras.Source = new BitmapImage(new Uri("./Resources/gras1.png", UriKind.Relative));
                    }
                    else
                    {
                        newCell.CellBody.Fill = new SolidColorBrush(EvenCellColor);
                        //newCell.CellBodyGras.Source = new BitmapImage(new Uri("./Resources/gras2.png", UriKind.Relative));
                    }
        
                    cellId++;
        
                    ForestMapInstance.Children.Add(newCell);
                }
            }
        }
    }
}
