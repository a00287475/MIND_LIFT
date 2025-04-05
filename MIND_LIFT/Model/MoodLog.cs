using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIND_LIFT.Model
{
    /// <summary>
    /// The Moodlog class represents a user's mood entry for a specific date.
    /// It tracks the user's mood, the intensity of the mood, additional notes,
    /// and associates it with a specific user through their UserId.
    /// </summary>
    public class Moodlog
    {
        /// <summary>
        /// Gets or sets the UserId for the person this moodlog entry belongs to.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the mood that the user is feeling (e.g., Happy, Sad, Angry, etc.).
        /// </summary>
        public string Mood { get; set; }

        /// <summary>
        /// Gets or sets the date when the moodlog was created. 
        /// This helps track the history of mood logs.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the intensity of the user's mood on a scale from 1 to 10.
        /// This helps quantify the severity of the mood.
        /// </summary>
        public int Intensity { get; set; }

        /// <summary>
        /// Gets or sets any additional notes or thoughts the user has about their mood 
        /// for the specific day. This allows for personal reflections.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// A constructor that initializes a new Moodlog instance with values.
        /// </summary>
        /// <param name="userId">The UserId of the person logging the mood.</param>
        /// <param name="mood">The mood the user is feeling.</param>
        /// <param name="date">The date of the mood entry.</param>
        /// <param name="intensity">The intensity of the mood on a scale of 1-10.</param>
        /// <param name="notes">Any additional notes about the mood.</param>
        public Moodlog(string userId, string mood, DateTime date, int intensity, string notes)
        {
            UserId = userId;
            Mood = mood;
            Date = date;
            Intensity = intensity;
            Notes = notes;
        }

        /// <summary>
        /// A default constructor for the Moodlog class, which initializes the properties to default values.
        /// </summary>
        public Moodlog()
        {
            UserId = string.Empty;
            Mood = string.Empty;
            Date = DateTime.Now;
            Intensity = 0;
            Notes = string.Empty;
        }
    }
}

