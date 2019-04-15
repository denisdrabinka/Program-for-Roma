
using System;
using System.Windows;
using System.Windows.Controls;

namespace DoorStorage
{
    public class UIPrinter
    {
        #region Properties

        public Int32 VerticalOffset { get; set; }
        public Int32 HorizontalOffset { get; set; }
        public String Title { get; set; }
        public UIElement Content { get; set; }

        #endregion

        #region Initialization

        public UIPrinter()
        {
            HorizontalOffset = 20;
            VerticalOffset = 20;
            Title = "Print " + DateTime.Now;
        }

        #endregion

        #region Methods

        public Int32 Print()
        {
            var dlg = new PrintDialog();
            if (dlg.ShowDialog() == true)
            {
                //---FIRST PAGE---//
                // Size the Grid.
                Content.Measure(new Size(Double.PositiveInfinity,
                                     Double.PositiveInfinity));


                Size sizeGrid = Content.DesiredSize;

                //check the width
                if (sizeGrid.Width > dlg.PrintableAreaWidth)
                {
                    MessageBoxResult result = MessageBox.Show(Properties.Resources.s_EN_Question_PrintWidth, "Print", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.No)
                        throw new Exception(Properties.Resources.s_EN_Info_PrintingAborted);
                }

                // Position of the grid 
                var ptGrid = new Point(HorizontalOffset, VerticalOffset);

                // Layout of the grid
                Content.Arrange(new Rect(ptGrid, sizeGrid));

                //print
                dlg.PrintVisual(Content, Title);

                //---MULTIPLE PAGES---//
                double diff;
                int i = 1;
                while ((diff = sizeGrid.Height - (dlg.PrintableAreaHeight - VerticalOffset * i) * i) > 0)
                {
                    //Position of the grid 
                    var ptSecondGrid = new Point(HorizontalOffset, -sizeGrid.Height + diff + VerticalOffset);

                    // Layout of the grid
                    Content.Arrange(new Rect(ptSecondGrid, sizeGrid));

                    //print
                    int k = i + 1;
                    dlg.PrintVisual(Content, Title + ("Page " + k + ""));

                    i++;
                }

                return i;
            }

            throw new Exception(Properties.Resources.s_EN_Info_PrintingAborted);
        }

        #endregion
    }
}