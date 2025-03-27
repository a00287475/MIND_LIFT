using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIND_LIFT.Model
{

    // This class is used to Represent the entries that the user inputs to the system.

    public class MoodEntry
    {
        public string EntryId { get; set; }  // Unique identifier for mood entry
        public string UserId { get; set; }  // Links to User model
        public DateTime Date { get; set; }  // Date of the mood entry
        public int MoodScore { get; set; }  // Mood score from 1-10
        public List<string> Emotions { get; set; }  // List of emotions (e.g., happy, anxious)
        public string Notes { get; set; }  // Additional details about mood

        // Constructor to initialize the list
        public MoodEntry()
        {
            Emotions = new List<string>();
        }
    }
}
