using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIND_LIFT.Model
{
    /// <summary>
    /// The MIND_LIFT.Model class represents a user's mood logs and energy level.
    /// It tracks the user's mood and calculates their energy level based on these logs.
    /// </summary>
    public class Model
    {
        /// <summary>
        /// Gets or sets the UserId for the person whose mood and energy levels are being tracked.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// A list of mood logs for the user, used to calculate their energy levels.
        /// </summary>
        public List<Moodlog> MoodLogs { get; set; }

        /// <summary>
        /// Gets the calculated energy level based on the user's mood history.
        /// The energy level is calculated based on the average intensity of the moods, adjusted by mood type.
        /// </summary>
        public double EnergyLevel
        {
            get
            {
                if (MoodLogs == null || MoodLogs.Count == 0)
                {
                    return 0; // No mood logs available, energy level is zero
                }

                double totalEnergy = 0;
                foreach (var moodlog in MoodLogs)
                {
                    totalEnergy += CalculateEnergyFromMood(moodlog.Mood, moodlog.Intensity);
                }

                return totalEnergy / MoodLogs.Count;
            }
        }

        /// <summary>
        /// Constructor to initialize the MIND_LIFT.Model class with user ID and mood logs.
        /// </summary>
        /// <param name="userId">The UserId for the person whose mood and energy levels are being tracked.</param>
        /// <param name="moodLogs">The list of mood logs for calculating energy levels.</param>
        public Model(string userId, List<Moodlog> moodLogs)
        {
            UserId = userId;
            MoodLogs = moodLogs ?? new List<Moodlog>();
        }

        /// <summary>
        /// Default constructor for MIND_LIFT.Model.
        /// </summary>
        public Model()
        {
            MoodLogs = new List<Moodlog>();
        }

        /// <summary>
        /// Calculates the energy level based on the mood and its intensity.
        /// </summary>
        /// <param name="mood">The mood type (e.g., Happy, Sad, etc.).</param>
        /// <param name="intensity">The intensity of the mood on a scale of 1-10.</param>
        /// <returns>The calculated energy level for that mood log.</returns>
        private double CalculateEnergyFromMood(string mood, int intensity)
        {
            double energy = 0;

            // Adjust energy based on the mood type
            switch (mood.ToLower())
            {
                case "happy":
                    energy = intensity * 1.2; // Happy mood increases energy level
                    break;
                case "sad":
                    energy = intensity * 0.5; // Sad mood decreases energy level
                    break;
                case "angry":
                    energy = intensity * 0.7; // Angry mood slightly decreases energy level
                    break;
                case "neutral":
                    energy = intensity; // Neutral mood has no major effect
                    break;
                default:
                    energy = intensity * 0.8; // Default behavior for other moods
                    break;
            }

            return energy;
        }
    }

    /// <summary>
    /// Moodlog class represents an individual mood entry of a user.
    /// </summary>
    public class MoodLog
    {
        /// <summary>
        /// Gets or sets the UserId of the person whose mood is logged.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the mood (e.g., Happy, Sad, etc.) the user is feeling.
        /// </summary>
        public string Mood { get; set; }

        /// <summary>
        /// Gets or sets the date when the mood log was created.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the intensity of the mood on a scale of 1-10.
        /// </summary>
        public int Intensity { get; set; }

        /// <summary>
        /// Gets or sets any additional notes the user wants to include about their mood.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Constructor for creating a new Moodlog entry.
        /// </summary>
        public MoodLog(string userId, string mood, DateTime date, int intensity, string notes)
        {
            UserId = userId;
            Mood = mood;
            Date = date;
            Intensity = intensity;
            Notes = notes;
        }
    }
}