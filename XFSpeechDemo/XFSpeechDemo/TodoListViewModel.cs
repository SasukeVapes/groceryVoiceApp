using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
namespace XFSpeechDemo
{
    public class TodoListViewModel : INotifyPropertyChanged 
    {

        public ObservableCollection<TodoItem> TodoItems { get; set; }
        public TodoListViewModel()
        {
            TodoItems = new ObservableCollection<TodoItem>();
            TodoItems.Add(new TodoItem("todo 1", false, 0));
            TodoItems.Add(new TodoItem("todo 2", false, 0));
            TodoItems.Add(new TodoItem("todo 3", false, 0));
        }

        public ICommand AddTodoCommand => new Command(AddTodoItem);
        public string NewTodoInputValue { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        
        double name=0;
        public double TotalPrice
        {
            get => name;
            set
            {
                if (name == value)
                {
                    return;
                }
                name = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(DisplayName));
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        void AddTodoItem()
        {

            TodoItems.Add(new TodoItem(NewTodoInputValue, false, Price));
            TotalPrice += Price;

        }

        public ICommand RemoveTodoCommand => new Command(RemoveTodoItem);
        void RemoveTodoItem(object o)
        {
            TodoItem todoItemBeingRemoved = o as TodoItem;
            TotalPrice -= todoItemBeingRemoved.Price;
            TodoItems.Remove(todoItemBeingRemoved);
            
        }

        public string DisplayName => $"Total: {TotalPrice} Blr";
    }

}
