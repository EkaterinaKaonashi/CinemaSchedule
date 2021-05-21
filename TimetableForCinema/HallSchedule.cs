using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimetableForCinema
{
    public partial class HallSchedule : Form
    {
        Schedule schedule;
        List<MovieInfo> inputMovie = new List<MovieInfo>();
        List<MovieInfo> scheduleDone = new List<MovieInfo>();
        Font fontForPrint { get; set; }
        Point nameLocation { get; set; }
        Point startLocation { get; set; }
        Point endLocation { get; set; }

        public string movieName  { get; set; }
        public string startMovie  { get; set; }
        public string endMovie { get; set; }
        SizeF parameteOfName { get; set; }
        SizeF parameteOfNamePlusStart { get; set; }
        int width { get; set; }
        int widthUntilEnd { get; set; }

        //int _countLine = 10;
        private int x = 10;
        private int y = 10;



        public HallSchedule(List<MovieInfo> inputMovie)
        {
            InitializeComponent();
            this.inputMovie = inputMovie;


        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            createSchedule();
            ShowSchedule(e);

        }

        private void ShowSchedule(PaintEventArgs e)
        {
            СalculatePositionOfText(e);
            DrawFirstMovieInList(e);
            scheduleDone.RemoveAt(0);
            while (scheduleDone.Count != 0)
            {
                ShowSchedule(e);
            }
        }

        private void DrawFirstMovieInList(PaintEventArgs e)
        {
            e.Graphics.DrawString(movieName, fontForPrint, Brushes.Black, nameLocation);

            e.Graphics.DrawString(startMovie, fontForPrint, Brushes.Black, startLocation);
            e.Graphics.DrawString(endMovie, fontForPrint, Brushes.Black, endLocation);
        }

        private void СalculatePositionOfText(PaintEventArgs e)
        {
            fontForPrint = new Font(this.Font.FontFamily, 15);
            movieName = (Convert.ToString(scheduleDone.First().nameOfMovie));
            startMovie = (Convert.ToString(scheduleDone.First().startMovie));
            endMovie = (Convert.ToString(scheduleDone.First().endMovie));

            parameteOfName = e.Graphics.MeasureString(movieName, fontForPrint);
            parameteOfNamePlusStart = e.Graphics.MeasureString(movieName + startMovie, fontForPrint);
            width = (int)((float)parameteOfName.Width);
            widthUntilEnd = (int)((float)parameteOfNamePlusStart.Width);



            nameLocation = new Point(x, y);
            startLocation = new Point(width + 20, y);
            endLocation = new Point(widthUntilEnd + 40, startLocation.Y);
            y += fontForPrint.Height;
        }

        private void createSchedule()
        {
            schedule = new Schedule(inputMovie);
            scheduleDone = schedule.SetTime();
        }
    }
}
