﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessInterfaces;
using DataAccessFakes;
using System.Collections.Generic;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/6/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This class is used to unit test the AdopterApplicationManager class
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>

    [TestClass]
    public class AdoptionAppointmentManagerTests
    {
        IAdoptionAppointmentAccessor _adoptionAppointmentAccessor;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This is the no-argument constructor for this class.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AdoptionAppointmentManagerTests()
        {
            _adoptionAppointmentAccessor = new FakeAdoptionAppointmentAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/6/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This method test the TestAdoptionApplicationRetrievesActiveAdoptionAppointments method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void TestAdoptionApplicationRetrievesActiveAdoptionAppointments()
        {
            // arange
            List<AdoptionAppointmentVM> adoptionAppointmentVMs;
            IAdoptionAppointmentManager adoptionAppointmentManager = new AdoptionAppointmentManager(_adoptionAppointmentAccessor);

            // act
            adoptionAppointmentVMs = adoptionAppointmentManager.RetrieveAdoptionApplicationsByActiveAndType(true, "Meet and Greet");

            // assert
            Assert.AreEqual(1, adoptionAppointmentVMs.Count);
        }
    }
}