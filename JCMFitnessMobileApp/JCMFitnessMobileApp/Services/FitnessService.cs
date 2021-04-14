﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JCMFitnessMobileApp.Models;


namespace JCMFitnessMobileApp.Services
{

    public class FitnessService : IFitnessService
    {
        private readonly IFitApi fitApi;


        public FitnessService(IFitApi newsApi)
        {
            this.fitApi = newsApi;
        }

        public async Task EditExercise(Exercise exercise)
        {
            try
            {
                await fitApi.EditExerciseAsync(exercise);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task EditWorkout(Workout workout)
        {
            try
            {
                await fitApi.EditWorkoutAsync(workout);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<User> LoginUser(string id, string password)
        {
            try
            {
                return await fitApi.UserLoginAsync(id, password);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<Workout>> GetUserWorkouts(string id)
        {
            try
            {
                return await fitApi.GetUserWorkoutsAsync(id);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task AddNewUserWorkout(string id, Workout workout)
        {
            try
            {
                 await fitApi.AddNewUserWorkoutAsync(id, workout);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task DeleteUserWorkoutById(string userID, string workoutID)
        {
            try
            {
                await fitApi.DeleteUserWorkoutAsync(userID, workoutID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<Exercise>> GetWorkoutExercises(string workoutID)
        {
            try
            {
                return await fitApi.GetWorkoutExercisesAsync(workoutID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task AddWorkoutExercise(string workoutID, Exercise exercise)
        {
            try
            {
                 await fitApi.PostNewWorkoutExerciseAsync(workoutID, exercise);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task DeleteWorkoutExercise(string workoutID, string exerciseID)
        {
            try
            {
                await fitApi.DeleteWorkoutExerciseAsync(workoutID, exerciseID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task DeleteExercise(string exercise)
        {
            try
            {
                await fitApi.DeleteExerciseAsync(exercise);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }

}


