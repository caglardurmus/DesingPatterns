﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book { Isbn = "1234", Title = "Sefiller", Author = "Victor Hugo" };
            book.ShowBook();
            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "4321";
            book.Title = "asdasd";

            book.ShowBook();

            book.RestoreFromUndo(history.Memento);

            book.ShowBook();

            Console.ReadKey();
        }
    }

    class Book
    {
        private string _title;
        private string _isbn;
        private string _author;
        private DateTime _lastEdited;


        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                SetLastEdited();
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                SetLastEdited();
            }
        }
        public string Isbn
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn, _title, _author, _lastEdited);
        }
        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Ispn;
            _lastEdited = memento.LastEdited;
        }
        public  void ShowBook()
        {
            Console.WriteLine("{0},{1},{2} edited: {3}", Isbn, Title, Author, _lastEdited);
        }
    }
    class Memento
    {
        public string Ispn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string ispn,string title,string author,DateTime lastEdit)
        {
            Ispn = ispn;
            Title = title;
            Author = author;
            LastEdited = lastEdit;
        }

    }
    class CareTaker
    {
        public Memento Memento { get; set; }
    }

}
