﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayerInterfaces;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/29
    /// Approver: Awaab Elamin, 2020/03/03
    /// 
    ///
    /// This Class for testing all public methods in the Adoption Interviewer
    /// Manager class.
    ///
    /// </summary>
    [TestClass]
    public class AdoptionInterviewerManagerTestes
    {
        private IAdoptionInterviewerAccessor _fakeAdoptionInterviewerAccessor;
        private AdoptionInterviewerManager _adoptionInterviewerManager;


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:Awaab Elamin,2020/03/03
        /// 
        /// This is the Setup for tests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeAdoptionInterviewerAccessor = new FakeAdoptionInterviewerAccessor();
            _adoptionInterviewerManager = new AdoptionInterviewerManager(_fakeAdoptionInterviewerAccessor);
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/03/03
        /// 
        /// This is the test for Select Select Adoption Applications Aappointments
        /// By Appointment Type method.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        [TestMethod]
        public void TestSelectAdoptionAappointmentsByAppointmentType()
        {
            // Arrangge 
            List<AdoptionAppointment> SelectAdoptionAappointmentsByAppointmentType;
            // Act
            SelectAdoptionAappointmentsByAppointmentType = _adoptionInterviewerManager
                .SelectAdoptionAappointmentsByAppointmentType();
            // Assert
            Assert.AreEqual(1, SelectAdoptionAappointmentsByAppointmentType.Count);

        }
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/03/03
        /// 
        /// This is the test for Edit Appointment of Adoption Applications 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        [TestMethod]
        public void TestEditAppointment()
        {
            bool expected = true;
            bool result;
            AdoptionAppointment oldAdoptionAppointment
                = new AdoptionAppointment()
                {
                    AppointmentID = 100001,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "facilitator",
                    AppointmentDateTime = DateTime.Now,
                    Notes = "This is a my notes",
                    Decision = "facilitator",
                    LocationID = 12033
                };
            AdoptionAppointment newAdoptionAppointment
                = new AdoptionAppointment()
                {
                    AppointmentID = 100001,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "facilitator",
                    AppointmentDateTime = DateTime.Now,
                    Notes = "This is a my notes",
                    Decision = "Deny",
                    LocationID = 12033

                };
            result = _adoptionInterviewerManager.EditAppointment(oldAdoptionAppointment, newAdoptionAppointment);
            Assert.AreEqual(expected, result);

        }

    }
}