using System;
namespace App1
{
    public class Data
    {
        public String name { get; set; }
        public int score { get; set; }
        public int index { get; set; }
		public int state { get; set; }

		public Data(String name, int score , int index, int state)
        {
            this.name = name;
            this.score = score;
            this.index = index;
			this.state = state;

		}
    }
}
