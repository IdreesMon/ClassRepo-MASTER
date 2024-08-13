﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace SE256_MasterPages.App_Code
{
    public class Book
    {

        private string title;
        private string authorFirst;
        private string authorLast;
        private string email;
        private DateTime datePublished;
        private int pages;
        private double price;

        protected string feedback;

        public string Title
        {
            get { return title; }

            set
            {
                if (!ValidationLibrary.GotBadWords(value))
                {
                    title = value;
                }
                else
                {
                    feedback += "\nERROR: Title has a bad word in it.";
                }
            }
        }

        public string AuthorFirst
        {
            get { return authorFirst; }

            set
            {
                if (!ValidationLibrary.GotBadWords(value))
                {
                    authorFirst = value;
                }
                else
                {
                    feedback += "\nERROR: Author First Name has a bad word in it.";
                }
            }
        }

        public string AuthorLast
        {
            get { return authorLast; }

            set
            {
                if (!ValidationLibrary.GotBadWords(value))
                {
                    authorLast = value;
                }
                else
                {
                    feedback += "\nERROR: Author Last Name has a bad word in it.";
                }
            }
        }

        public string Email
        {
            get { return email; }

            set
            {
                if (ValidationLibrary.IsValidEmail(value))
                {
                    email = value;
                }
                else
                {
                    feedback += "\nERROR: Not a valid email address.";
                }
            }
        }

        public DateTime DatePublished
        {
            get { return datePublished; }

            set
            {
                if(ValidationLibrary.IsAFutureDate(value) == false)
                {
                    datePublished = value;
                }
                else
                {
                    feedback += "\nERROR: Not a valid past date.";
                }
            }
        }

        public int Pages
        {
            get { return pages; }

            set
            {
                if (ValidationLibrary.IsMinimumAmount(value, 100))
                {
                    pages = value;
                }
                else
                {
                    feedback += "\nERROR: Does not meet the page requirements.";
                }
            }
        }

        public double Price
        {
            get { return price; }

            set
            {
                if(ValidationLibrary.IsMinimumAmount(value, 1.00))
                {
                    price = value;
                }
                else
                {
                    feedback += "\nERROR: Must enter price greater than $1.00";
                }
            }
        }

        public string Feedback
        {
            get { return feedback; }
        }

        public Book()
        {
            title = "";
            authorFirst = "";
            authorLast = "";
            email = "";
            pages = 0;
            datePublished = DateTime.Parse("1/1/1500");
            price = 0.0;
            feedback = "";
        }

    }
}