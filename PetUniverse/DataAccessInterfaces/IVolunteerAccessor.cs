﻿using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Josh Jackson
    /// DATE: 02/07/2020
    /// Checked By: Ethan H, Gabi L
    /// This is an inteface for Volunteer accessor methods
    /// </summary>
    /// <remarks>
    /// UPDATED BY: Josh Jackson
    /// UPDATE DATE: 02/13/2020
    /// WHAT WAS CHANGED: Added GetVolunteerByName() method definition
    /// </remarks>
    public interface IVolunteerAccessor
    {
        int InsertVolunteer(Volunteer volunteer);
        List<string> SelectAllSkills();
        List<Volunteer> GetVolunteerByName(string firstName, string lastName);
        List<Volunteer> SelectVolunteersByActive(bool active = true);
    }
}
