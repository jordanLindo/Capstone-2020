﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/18/2020
    /// Approver: Carl Davis, 2/7/2020
    /// Approver: Chuck Baxter, 2/7/2020
    /// 
    /// no argument constructor
    /// </summary>
    /// <remarks>
    /// Updater: Ethan Murphy
    /// Updated: 4/2/2020
    /// Update: Added methods for retrieving activity records
    /// by activity type and retrieving a list of activity types
    /// </remarks>

    public interface IAnimalActivityManager
    {
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/18/2020
        /// Approver: Carl Davis, 2/7/2020
        /// Approver: Chuck Baxter, 2/7/2020
        /// 
        /// Retrieves the animal feeding records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        List<AnimalActivity> RetrieveAnimalFeedingRecords();

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Retrieves animal activities by activity type
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="activityType">Activity type ID</param>
        /// <returns>List of animal activities</returns>
        List<AnimalActivity> RetrieveAnimalActivitiesByActivityType(string activityType);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Retrieves list of animal activity types
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <returns>List of animal activity types</returns>
        List<AnimalActivityType> RetrieveAllAnimalActivityTypes();


        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Searches the list of animal activity records with the
        /// specified animal name and returns results with similar names
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="animalName">The name of the animal</param>
        /// <param name="activityType">The activity type to search</param>
        /// <returns>List of animal activity types</returns>
        List<AnimalActivity> RetrieveAnimalActivitiesByPartialAnimalName(string animalName, string activityType);

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Adds an animal activity record to the DB
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="animalActivity">Activity record to be added</param>
        /// <returns>Result of insert</returns>
        bool AddAnimalActivityRecord(AnimalActivity animalActivity);
    }
}
