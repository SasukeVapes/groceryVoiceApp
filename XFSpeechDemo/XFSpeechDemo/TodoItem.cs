using System;
using System.Collections.Generic;
using System.Text;

namespace XFSpeechDemo
{
    public class TodoItem
    {
        public string ToDoText { get; set; }
        public bool Complete { get; set; }
        public double Price { get; set; }
        public TodoItem(string ToDoText, bool Complete, double Price)
        {
            this.ToDoText = ToDoText;
            this.Complete = Complete;
            this.Price = Price;
        }
    }

}
