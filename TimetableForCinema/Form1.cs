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
    public partial class Form1 : Form
    {
        List<MovieInfo> moviesAdded = new List<MovieInfo>();
        List<MovieInfo> TestMovieAdded = new List<MovieInfo>();
        
        string _name;
        int _duration;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            _name = textBoxName.Text;
        }

        private void textBoxDuration_TextChanged(object sender, EventArgs e)
        {
            _duration = Convert.ToInt32(textBoxDuration.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MovieInfo movie = new MovieInfo(_name, _duration);
            moviesAdded.Add(movie);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TestMovieAdded.Add(new MovieInfo("qqq", 167));
            TestMovieAdded.Add(new MovieInfo("www", 74));
            TestMovieAdded.Add(new MovieInfo("eee", 92));
            //Schedule schedule = new Schedule(TestMovieAdded);
           // var scHall = new HallSchedule(moviesAdded);
            var scHall = new HallSchedule(moviesAdded);
            scHall.Show();


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
