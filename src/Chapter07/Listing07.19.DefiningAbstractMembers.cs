﻿namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter07.Listing07_19
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using static System.Environment;

    // Define an abstract class
    public abstract class PdaItem
    {
        public PdaItem(string name)
        {
            Name = name;
        }

        public virtual string Name { get; set; }
        public abstract string GetSummary();
    }
    public class Contact : PdaItem
    {
        public Contact(string name)
            : base(name)
        {
        }

        public override string Name
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }

            set
            {
                string[] names = value.Split(' ');
                // Error handling not shown
                FirstName = names[0];
                LastName = names[1];
            }
        }

        [NotNull][DisallowNull]
        public string? FirstName { get; set; }
        [NotNull][DisallowNull]
        public string? LastName { get; set; }
        public string? Address { get; set; }

        public override string GetSummary()
        {
            return $"FirstName: { FirstName + NewLine }"
            + $"LastName: { LastName + NewLine }"
            + $"Address: { Address + NewLine }";
        }

        // ...
    }

    public class Appointment : PdaItem
    {
        public Appointment(string name, 
            string location, DateTime startDateTime, DateTime endDateTime) :
            base(name)
        {
            Location = location;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Location { get; set; }

        // ...
        public override string GetSummary()
        {
            return $"Subject: { Name + NewLine }"
                + $"Start: { StartDateTime + NewLine }"
                + $"End: { EndDateTime + NewLine }"
                + $"Location: { Location }";
        }
    }
}
