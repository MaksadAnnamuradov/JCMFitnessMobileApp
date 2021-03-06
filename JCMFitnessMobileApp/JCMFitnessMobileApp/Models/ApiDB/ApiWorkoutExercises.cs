using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JCMFitnessMobileApp.Models
{
    public class ApiWorkoutExercises
    {
      
        public string Id { get; set; }
        public string ExerciseID { get; set; }
        public ApiExercise Exercise { get; set; }

        public string WorkoutID { get; set; }
        public ApiWorkout Workout { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsPublic { get; set; }
        

    }
}
