using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW3
{
    
    public class Sefer
    {
        private string bookingId;
        private string from;
        private string to;
        private string date;
        private string hour;
        private string price;
        private int[] seat;

        public Sefer(string bookingId, string from, string to, string date, string hour, string price)
        {
            BookingId = bookingId;
            From = from;
            To = to;
            Date = date;
            Hour = hour;
            Price = price;
        }

        public string BookingId { get => bookingId; set => bookingId = value; }
        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
        public string Date { get => date; set => date = value; }
        public string Hour { get => hour; set => hour = value; }
        public string Price { get => price; set => price = value; }
        public int[] Seat { get => seat; set => seat = value; }

        public void set_Seat_0(int count)
        {
            Seat = new int[count];
            for (int i = 0; i < count; i++) 
            {
                Seat[i] = 0;
            }
        }

    }
}